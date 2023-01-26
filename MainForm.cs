using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RezervacijuSistema
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        RepositoryItemGridLookUpEdit SeatStructureAddGridLookUpEdit = new RepositoryItemGridLookUpEdit();
        public MainForm()
        {
            InitializeComponent();
            //Seatlist
            InitializeHallSelectDataSource(SeatListHallSelectLookUpEdit);
            //CreateEvent
            InitializeHallSelectDataSource(CreateEventHallSelect);
            //ReserveSeat
            InitializeHallSelectDataSource(ReserveSeatHallSelectLookUpEdit);
            //EventList
            InitializeEventList();
            //Scheduler
            InitializeScheduler();

            SeatListGridView.BeforeLeaveRow += SeatListGridView_BeforeLeaveRow;
            SeatListGridView.CustomRowCellEditForEditing += SeatListGridView_CustomRowCellEditForEditing;
            CreateEventNameTextEdit.EditValueChanging += CreateEventTextEdit_EditValueChanging;
        }



        /// INITIALIZATION BEHAVIOR ==========================================================================================================
        private void InitializeScheduler()
        {
            InitializeHallsToResources();
            InitializeHallGroupsToResources();
            InitializeSchedulerResources();
            InitializeSchedulerAppointments();
            InitializeSchedulerVisuals();

            foreach (TimeScale scale in ReservedSeatSchedulerControl.TimelineView.Scales)
            {
                scale.Width = 300;
            }

            resourcesTree1.NodesReloaded += ResourcesTree1_NodesReloaded;
        }

        private void InitializeHallsToResources()
        {
            DataTable hallGroups = SQLHelper.GetTable("prc_selectHalls", "all", new string[1]);
            DataTable reservedSeats = SQLHelper.GetTable("prc_selectReservedSeats", "all", new string[1]);

            foreach (DataRow row in hallGroups.Rows)
            {
                string[] details =
                {
                    row.Field<int>("hallid").ToString(),
                    row.Field<string>("hallname"),
                    "",
                    "0"
                };

                SQLHelper.InsertResources(details);
            }
        }
        private void InitializeSchedulerVisuals()
        {
            ReservedSeatSchedulerControl.ActiveViewType = SchedulerViewType.Gantt;
            ReservedSeatSchedulerControl.GroupType = SchedulerGroupType.Resource;
            ReservedSeatSchedulerControl.GanttView.CellsAutoHeightOptions.AutoHeightMode = DevExpress.XtraScheduler.SchedulerCellAutoHeightMode.Limited;
            // Hide unnecessary visual elements.
            ReservedSeatSchedulerControl.GanttView.ShowResourceHeaders = false;
            ReservedSeatSchedulerControl.GanttView.NavigationButtonVisibility = NavigationButtonVisibility.Never;
            // Disable user sorting in the Resource Tree (clicking the column will not change the sort order).
            colDescription.OptionsColumn.AllowSort = false;
        }
        private bool InitializeHallSelectDataSource(GridLookUpEdit lookup)
        {
            List<dataClass.Hall> halls = DataSourceControl.GetHallList();
            lookup.DataBindings.Add(new Binding("EditValue", halls, "hallid"));
            lookup.Properties.DataSource = halls;
            lookup.Properties.ValueMember = "hallid";
            lookup.Properties.DisplayMember = "name";
            lookup.Properties.PopulateViewColumns();
            lookup.Properties.View.Columns["hallid"].Visible = false;

            return true;
        }
        private bool InitializeEventList()
        {
            List <dataClass.Event> events = DataSourceControl.GetEventList();
            EventListGridControls.DataSource = events;

            EventListGridControlView.Columns[0].Visible = false;
            EventListGridControlView.Columns[6].Visible = false;

            return true;
        }
        private void InitializeSchedulerAppointments()
        {
            DataTable table = SQLHelper.GetTable("prc_selectReservedSeats", "all", new string[1]);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                //Select resource id by seat id and event id
                string[] seatDetails = {
                    table.Rows[i].Field<int>("seatid").ToString(),
                    table.Rows[i].Field<int>("hallid").ToString(),
                };

                DataTable resourceID = SQLHelper.GetTable("prc_getResourceID", "resources_eventid", seatDetails);

                if (resourceID.Rows.Count < 1)
                    continue;

                string[] details =
                {
                    table.Rows[i].Field<string>("eventname").ToString(),        //Description
                    table.Rows[i].Field<DateTime>("eventtimefrom").ToString(),  //Start
                    table.Rows[i].Field<DateTime>("eventtimeto").ToString(),    //End
                    resourceID.Rows[0].ItemArray[0].ToString()                  //ResourceID
                };

                SQLHelper.InsertAppointment(details);
            }

            this.appointmentsTableAdapter.Fill(this.ganttDataSet.Appointments);
        }
        private void InitializeSchedulerResources()
        {
            DataTable table = SQLHelper.GetTable("prc_selectReservedSeats", "all", new string[1]);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ///Resource Details
                ///IDsort -> seatid
                ///Description  -> Concat (seat details(row, number, letter...)) -> ParentID's set by hallgroups in Resources table
                ///             -> Could be hallgroup name, with parentID = NULL !!!!!!!!!!!!!!!
                ///CustomField1 -> EventID from reservedSeat Table
                ///.
                ///Appointment Details
                ///StartDate/EndDate -> Get from reservedSeatsTable
                ///Description       -> eventName from table
                ///ResourceID        -> Get from resource table by providing seatID and eventID
                ///                  -> seatID is in Resources as IDsort
                ///                  -> eventID is in Resources as CustomField

                ///Concat details
                string seatrow = table.Rows[i].Field<int>("seatrow").ToString();
                string seatrowletter = table.Rows[i].Field<string>("seatrowletter");
                string seatnumber = table.Rows[i].Field<int>("seatnumber").ToString();
                string seatnumberletter = table.Rows[i].Field<string>("seatnumberletter");

                //string description = "Eilė: " + seatrow + " " + seatrowletter + "- Vieta: " + seatnumber + " " + seatnumberletter;

                string description = string.Format("{0,-7}{1,-7} - {2,-7}{3,-7}","Eilė: ", seatrow + seatrowletter, "Vieta: ", seatnumber + seatnumberletter);

                string[] resourceIDdetails =
                {
                    table.Rows[i].Field<int>("hallgroupid").ToString(),
                    table.Rows[i].Field<int>("hallid").ToString()
                };

                DataTable resourceID = SQLHelper.GetTable("prc_getResourceID", "resources_eventid", resourceIDdetails);

                string[] details =
                {
                    table.Rows[i].Field<int>("seatid").ToString(),
                    description,
                    table.Rows[i].Field<int>("hallid").ToString(),
                    resourceID.Rows[0].ItemArray[0].ToString()

                };

                SQLHelper.InsertResources(details);
            }

            this.resourcesTableAdapter.Fill(this.ganttDataSet.Resources);
        }
        private void InitializeHallGroupsToResources()
        {
            DataTable hallGroups = SQLHelper.GetTable("prc_selectHallGroups", "all", new string[1]);
            DataTable reservedSeats = SQLHelper.GetTable("prc_selectReservedSeats", "all", new string[1]);

            foreach (DataRow row in hallGroups.Rows)
            {
                

                string[] resourceIDDetails =
                {
                    row.Field<int>("hallid").ToString(),
                    "0"
                };

                DataTable resourceID = SQLHelper.GetTable("prc_getResourceID", "resources_eventid", resourceIDDetails);

                string[] details =
                {
                    row.Field<int>("hallgroupid").ToString(),
                    row.Field<string>("hallgroupname"),
                    row.Field<int>("hallid").ToString(),
                    resourceID.Rows[0].ItemArray[0].ToString()
                };

                SQLHelper.InsertResources(details);
            }
        }

        /// SEAT TABLE WITH XML UPLOAD BEHAVIOR ==============================================================================================
        private void SeatListHallSelectLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            UpdateHallSeatList();
        }

        private void UpdateHallSeatList()
        {
            //Update Grid Control on changed value
            DataTable hallseats = SQLHelper.GetTable("prc_selectSeatsByHallID", "hallid", new string[] { SeatListHallSelectLookUpEdit.EditValue.ToString() });

            SeatListGridControl.DataSource = hallseats;
            SeatListGridView.AddNewRow();
            SeatListGridView.Columns["price"].Visible = false;
        }
        private void UploadXMLButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choose XML file!";
            OFD.InitialDirectory = "D";
            OFD.Filter = "XML files (*.xml)|*.xml";

            string filePath = string.Empty;

            if (OFD.ShowDialog().Equals(DialogResult.OK))
            {
                filePath = OFD.FileName;
                UploadXMLStatus.Text = filePath;
            }

            if (UploadXMLStatus.Text != string.Empty && File.Exists(UploadXMLStatus.Text))
            {
                DataSet TableSet = XMLHelper.ConvertXMLToDataSet(filePath);

                if (SQLHelper.InsertHallDataToDB(TableSet))
                {
                    UploadXMLStatus.Text = "Succcess!";
                    UploadXMLButton.BackColor = Color.Green;
                }
                else
                {
                    UploadXMLStatus.Text = "Failed to Upload!";
                    UploadXMLButton.BackColor = Color.Red;
                }
            }
            else
            {
                UploadXMLStatus.Text = "Failed to Upload!";
                UploadXMLButton.BackColor = Color.Red;
            }

            InitializeHallSelectDataSource(SeatListHallSelectLookUpEdit);
            InitializeHallSelectDataSource(CreateEventHallSelect);
            InitializeHallSelectDataSource(ReserveSeatHallSelectLookUpEdit);
        }

        /// ADD SEAT STRUCTURE BEHAVIOR ===========================================================================================

        ///TODO:
        ///     Apply validation for letter values
        ///     On seat added add new row for further additions
        /// ============================================================================  
        private void SeatListGridView_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            ComboBox_FillItems(e.RowHandle);
            if (e.Column.Name == "colhallgroupname")
                e.RepositoryItem = SeatStructureAddGridLookUpEdit;
        }
        private void ComboBox_FillItems(int rowHandle)
        {
            DataTable table = SQLHelper.GetTable("prc_selectHallGroupsByHallID", "hallid", new string[] {
                SeatListHallSelectLookUpEdit.EditValue.ToString()});
            SeatStructureAddGridLookUpEdit.RepositoryItems.Clear();

            SeatStructureAddGridLookUpEdit.DataSource = table;
            SeatStructureAddGridLookUpEdit.ValueMember = "hallgroupid";
            SeatStructureAddGridLookUpEdit.DisplayMember = "hallgroupname";
            SeatStructureAddGridLookUpEdit.PopulateViewColumns();
            SeatStructureAddGridLookUpEdit.View.Columns["hallgroupid"].Visible = false;
            SeatStructureAddGridLookUpEdit.View.Columns["hallid"].Visible = false;
            SeatStructureAddGridLookUpEdit.View.Columns["az"].Visible = false;
            SeatStructureAddGridLookUpEdit.NullText = "Pasirinkite grupę";
        }
        private void SeatListGridView_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            DataRow row = SeatListGridView.GetDataRow(e.RowHandle);

            if (row == null)
                return;

            if (row.RowState == DataRowState.Unchanged)
            {
                e.Allow = true;
            }
            else
            {
                SeatListGridView.OptionsBehavior.Editable = true;

                if (ValidateRowFields(row))
                {
                    DialogResult res = MessageBox.Show("Tikrai norite išsaugoti duomenis?", "Įkėlimas į duomenų bazę", MessageBoxButtons.OKCancel);

                    if (res == DialogResult.OK)
                    {
                        var hallgroupname = row.Field<string>("hallgroupname");
                        var color = row.Field<string>("color");
                        var seatrow = row.Field<Int32>("seatrow");
                        var seatrowletter = row.Field<string>("seatrowletter");
                        var seatnumber = row.Field<Int32>("seatnumber");
                        var seatnumberletter = row.Field<string>("seatnumberletter");
                        var price = row.Field<Decimal>("price");

                        if (seatrowletter == null)
                            seatrowletter = "";
                        if (seatnumberletter == null)
                            seatnumberletter = "";

                        //INSERT SEATS WITH SQL

                        //Check if seat exists

                        bool seatExists = DataSourceControl.SeatExists(SeatListHallSelectLookUpEdit.EditValue.ToString(), hallgroupname, seatrow.ToString(), seatrowletter, seatnumber.ToString(), seatnumberletter);

                        if (seatExists)
                        {
                            MessageBox.Show("Tokia vieta jau egzistuoja!");
                            return;
                        }

                        DataTable maxSeatID = SQLHelper.GetTable("prc_getMaxSeatID", "all", new string[1]);

                        int maxSeatIDint = int.Parse(maxSeatID.Rows[0].ItemArray[0].ToString()) + 1;

                        string[] details =
                        {
                            SeatListHallSelectLookUpEdit.EditValue.ToString(), hallgroupname, maxSeatIDint.ToString(), seatrow.ToString(),
                            seatrowletter, seatnumber.ToString(), seatnumberletter, color, price.ToString()
                        };

                        SQLHelper.InsertSeatData(details);
                        UpdateHallSeatList();

                    }
                    else
                    {
                        //row.SetField<string>("hallgroupname", " ");
                        //row.SetField<string>("color", " ");
                        //row.SetField<DBNull>("seatrow", DBNull.Value);
                        //row.SetField<string>("seatrowletter", " ");
                        //row.SetField<DBNull>("seatnumber", DBNull.Value);
                        //row.SetField<string>("seatnumberletter", " ");

                        //e.Allow = true;
                        //SeatListGridView.OptionsBehavior.Editable = false;
                        //SeatListGridView.Columns["price"].Visible = false;

                        //SeatListGridView.DeleteRow(e.RowHandle);
                        //SeatListGridView.AddNewRow();
                    }

                    e.Allow = true;
                    SeatListGridView.OptionsBehavior.Editable = false;
                    SeatListGridView.Columns["price"].Visible = false;
                }
                else
                {
                    e.Allow = false;
                    SeatListGridView.OptionsBehavior.Editable = true;
                    SeatListGridView.Columns["price"].Visible = true;
                }
            }


        }
        public bool ValidateRowFields(DataRow row)
        {
            bool allow = true;

            //foreach(var item in row.ItemArray)
            //{
            //    if (DBNull.Value.Equals(item))
            //    {

            //        return false;
            //    }
            //}

            //var hallgroupname = row.Field<string>("hallgroupname");
            //var color = row.Field<string>("color");
            //var seatrow = row.Field<Int32>("seatrow");
            //var seatrowletter = row.Field<string>("seatrowletter");
            //var seatnumber = row.Field<Int32>("seatnumber");
            //var seatnumberletter = row.Field<string>("seatnumberletter");

            if (row.Field<string>("hallgroupname") != null)
            {
                var hallgroupname = SeatStructureAddGridLookUpEdit.DisplayMember;
                if (hallgroupname.ToString().Any(char.IsDigit))
                {
                    allow = false;
                    MessageBox.Show("Negali būti skaičių salės grupės pavadinime");
                }
            }
            else
            {
                allow = false;
            }

            if (row.Field<string>("color") != null)
            {
                var color = row.Field<string>("color");
                if (color.ToString().Any(char.IsDigit))
                {
                    allow = false;
                    MessageBox.Show("Negali būti skaičių spalvos pavadinime");
                }
            }
            else
            {
                allow = false;
            }

            try
            {

                if (!DBNull.Value.Equals(row.Field<Int32>("seatrow")))
                {
                    var seatrow = row.Field<Int32>("seatrow");

                    var seatrowletter = "X";

                    if (!DBNull.Value.Equals(row.Field<string>("seatrowletter")))
                    {
                        seatrowletter = row.Field<string>("seatrowletter");
                    }

                    bool success = int.TryParse(seatrow.ToString(), out int seatrowINT);

                    if (!success)
                    {
                        allow = false;
                        MessageBox.Show("Kedės eilės numeris turi būti skaičius!");
                    }
                }
                else
                {
                    allow = false;
                }
            }
            catch
            {

            }


            try
            {
                if (!DBNull.Value.Equals(row.Field<Int32>("seatnumber")))
                {
                    var seatnumber = row.Field<Int32>("seatnumber");
                    var seatnumberletter = "X";

                    if (!DBNull.Value.Equals(row.Field<string>("seatnumberletter")))
                    {
                        seatnumberletter = row.Field<string>("seatnumberletter");
                    }

                    bool success = int.TryParse(seatnumber.ToString(), out int seatnumberINT);

                    if (!success)
                    {
                        allow = false;
                        MessageBox.Show("Kedės vietos numeris turi būti skaičius!");
                    }
                }
                else
                {
                    allow = false;
                }
            }
            catch
            {

            }

            return allow;
        }

        ///CREATE EVENT BEHAVIOR =============================================================================================================
        ///TODO: 
        ///     Read ticket count from halllist from DB by giving hallid as a parameter
        /// ============================================================================  
        private void CreateEventButton_Click(object sender, EventArgs e)
        {
            string eventName = CreateEventNameTextEdit.Text.ToString();
            string hallid = CreateEventHallSelect.EditValue.ToString();
            string date = EventStartDateTimeOffset.DateTimeOffset.Date.ToString("d");
            string from = TimeEditFrom.Time.ToString("HH:mm");
            string to = TimeEditTo.Time.ToString("HH:mm");
            string ticketCount = "1000";

            TimeSpan _timefrom = TimeSpan.Parse(from);
            TimeSpan _timeto = TimeSpan.Parse(to);
            DateTime _date = DateTime.Parse(date);

            DateTime dateFrom = _date.Date.Add(_timefrom);
            DateTime dateTo = _date.Date.Add(_timeto);

            if (dateTo < dateFrom)
            {
                MessageBox.Show("Neteisingai įvesta data");
                return;
            }   
            
            if(dateFrom < DateTime.Today.Date)
            {
                MessageBox.Show("Renginių atgaline data įvesti negalima!");
                return;
            }

            DataTable existingEvents = SQLHelper.GetTable("prc_selectEvents", "all", new string[1]);

            foreach(DataRow row in existingEvents.Rows)
            {
                if (row.Field<int>("hallid").ToString() == hallid &&
                    (row.Field<DateTime>("eventtimefrom") < dateTo && row.Field<DateTime>("eventtimeto") > dateFrom))
                {
                    MessageBox.Show("Laikas užimtas!");
                    return;
                }
                    
            }

            //Validate all enternances

            //Add to database
            string[] paramList =
            {
                hallid, eventName, dateFrom.ToString(), dateTo.ToString(), ticketCount
            };
            if (SQLHelper.InsertEventsToDB(paramList))
            {
                CreateEventButton.Text = "Įvykis įtrauktas į sąrašą!";
                CreateEventButton.ForeColor = Color.Green;
            }

            InitializeEventList();
        }

        private void CreateEventTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            CreateEventButton.Text = "Įtraukti renginį";
            CreateEventButton.ResetForeColor();
        }

        /// RESERVE SEAT BEHAVIOR =============================================================================================================
        /// TODO: 
        ///     Decrease ticket count in eventlist table in DB, when reservation occurs
        /// ============================================================================  
        private void ReserveSeatHallSelectLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ReserveSeatEventSelectLookUpEdit.DataBindings.Clear();
            ReserveSeatHallGroupSelectLookUpEdit.DataBindings.Clear();
            //Update both fields: event list and hallgrouplist
            string hallid = ReserveSeatHallSelectLookUpEdit.EditValue.ToString();
            //Query for hallGroup by hallid
            List<dataClass.HallGroup> hallGroups = DataSourceControl.GetHallGroupList(hallid);
            //Query for eventList by hallid
            List<dataClass.Event> eventList = DataSourceControl.GetEventList(hallid);

            ReserveSeatHallGroupSelectLookUpEdit.Properties.DataSource = hallGroups;
            ReserveSeatHallGroupSelectLookUpEdit.Properties.DisplayMember = "hallGroupName";
            ReserveSeatHallGroupSelectLookUpEdit.Properties.ValueMember = "hallGroupID";
            ReserveSeatHallGroupSelectLookUpEdit.Properties.PopulateViewColumns();
            ReserveSeatHallGroupSelectLookUpEdit.Properties.View.Columns[1].Visible = false;
            ReserveSeatHallGroupSelectLookUpEdit.Properties.View.Columns[0].Visible = false;
            ReserveSeatHallGroupSelectLookUpEdit.Properties.View.Columns[3].Visible = false;

            ReserveSeatEventSelectLookUpEdit.Properties.DataSource = eventList;
            ReserveSeatEventSelectLookUpEdit.Properties.DisplayMember = "eventName";
            ReserveSeatEventSelectLookUpEdit.Properties.ValueMember = "eventID";
            ReserveSeatEventSelectLookUpEdit.Properties.PopulateViewColumns();
            ReserveSeatEventSelectLookUpEdit.Properties.View.Columns[0].Visible = false;
            ReserveSeatEventSelectLookUpEdit.Properties.View.Columns[1].Visible = false;
            ReserveSeatEventSelectLookUpEdit.Properties.View.Columns[6].Visible = false;
            ReserveSeatEventSelectLookUpEdit.Properties.View.Columns[4].Visible = false;
            ReserveSeatEventSelectLookUpEdit.Properties.View.Columns[5].Visible = false;

            if (ReserveSeatHallGroupSelectLookUpEdit.EditValue != null && ReserveSeatEventSelectLookUpEdit.EditValue != null)
            {

                string hallgroupid = ReserveSeatHallGroupSelectLookUpEdit.EditValue.ToString();
                string eventid = ReserveSeatEventSelectLookUpEdit.EditValue.ToString();

                DataTable seatTable = SQLHelper.GetTable("prc_selectNotReservedSeats", "eventid", new string[] {
                    hallid, hallgroupid, eventid
                });

                seatTable.Columns.Add(new DataColumn("Rezervuoti?", typeof(Boolean)));

                NotReserverSeatListGridControl.DataSource = seatTable;

            }

        }
        public void UpdateReservedSeatsTable()
        {
            string hallid = ReserveSeatHallSelectLookUpEdit.EditValue.ToString();

            if (ReserveSeatHallGroupSelectLookUpEdit.EditValue != null && ReserveSeatEventSelectLookUpEdit.EditValue != null)
            {

                string hallgroupid = ReserveSeatHallGroupSelectLookUpEdit.EditValue.ToString();
                string eventid = ReserveSeatEventSelectLookUpEdit.EditValue.ToString();

                DataTable seatTable = SQLHelper.GetTable("prc_selectNotReservedSeats", "eventid", new string[] {
                    hallid, hallgroupid, eventid
                });

                seatTable.Columns.Add(new DataColumn("Rezervuoti?", typeof(Boolean)));

                NotReserverSeatListGridControl.DataSource = seatTable;

            }
        }
        private void ReserveSeatsButton_Click(object sender, EventArgs e)
        {
            string hallgroup = "-1";
            string eventid = "-1";
            string hallid = ReserveSeatHallSelectLookUpEdit.EditValue.ToString();

            if (ReserveSeatHallGroupSelectLookUpEdit.EditValue != null)
            {
                hallgroup = ReserveSeatHallGroupSelectLookUpEdit.EditValue.ToString();
            }
            else
            {
                string userException = "Pasirinkite salės grupę!";
                Reserve_responseLabel.Text = userException;
                return;
            }

            if (ReserveSeatEventSelectLookUpEdit.EditValue != null)
                eventid = ReserveSeatEventSelectLookUpEdit.EditValue.ToString();
            else
            {
                //Info on label
                string userException = "Pasirinkite renginį!";
                Reserve_responseLabel.Text = userException;
                return;
            }

            int rowCount = NotReserverSeatListGridControlView.RowCount;

            for(int i = 0; i < rowCount; i++)
            {
                var cellvalue = NotReserverSeatListGridControlView.GetRowCellValue(i, NotReserverSeatListGridControlView.Columns["Rezervuoti?"]);

                if (cellvalue == null)
                    continue;

                if (cellvalue.Equals(true))
                {
                    string seatid = NotReserverSeatListGridControlView.GetRowCellValue(i, NotReserverSeatListGridControlView.Columns["seatid"]).ToString();
                    string[] details = new string[]
                    {
                        hallid, seatid, eventid
                    };

                    SQLHelper.InsertReservedSeats(details);
                    
                }
            }

            UpdateReservedSeatsTable();
            InitializeSchedulerResources();
            InitializeSchedulerAppointments();
        }
        private void ExactSeatSearchButton_Click(object sender, EventArgs e)
        {
            Reserve_responseLabel.ForeColor = Color.Red;

            string seatrow = reserved_seatrow.Text;
            string seatrowletter = reserved_seatrowletter.Text;
            string seatnumber = reserved_seatnumber.Text;
            string seatnumberletter = reserved_seatnumberletter.Text;
            string hallid = ReserveSeatHallSelectLookUpEdit.EditValue.ToString();
            string eventid = "-1";
            string hallgroup = "-1";

            if(ReserveSeatHallGroupSelectLookUpEdit.EditValue != null)
            {
                hallgroup = ReserveSeatHallGroupSelectLookUpEdit.EditValue.ToString();
            }
            else
            {
                string userException = "Pasirinkite salės grupę!";
                Reserve_responseLabel.Text = userException;
                return;
            }

            if(ReserveSeatEventSelectLookUpEdit.EditValue != null)
                eventid = ReserveSeatEventSelectLookUpEdit.EditValue.ToString();
            else
            {
                //Info on label
                string userException = "Pasirinkite renginį!";
                Reserve_responseLabel.Text = userException;
                return;
            }
            if(seatnumber == "" || seatrow == "")
            {
                string userException = "Pasirinkite vietos eilę ir numerį!";
                Reserve_responseLabel.Text = userException;
                return;
            }

            string[] details = new string[] {
                eventid, hallid, hallgroup, seatrow, seatrowletter, seatnumber, seatnumberletter
            };

            DataTable reservedSeats = SQLHelper.GetTable("prc_selectExactReservedSeat", "seatdetails", details);

            details = new string[]
            {
                hallid, ReserveSeatHallGroupSelectLookUpEdit.EditValue.ToString(), seatrow,
                seatrowletter, seatnumber, seatnumberletter
            };

            DataTable seatIDTable = SQLHelper.GetTable("prc_selectSeatByDetails", "seatdetails+hallgroup", details);

            if(reservedSeats.Rows.Count > 0)
            {
                //Seat is reserved
                string userException = "Ši vieta jau rezervuota!";
                Reserve_responseLabel.Text = userException;
            }
            else
            {
                //Reserve Seat
                string[] reservedDetails = new string[] {
                    hallid, seatIDTable.Rows[0].Field<int>("seatid").ToString(), eventid
                };
                SQLHelper.InsertReservedSeats(reservedDetails);
                Reserve_responseLabel.ForeColor = Color.Green;
                Reserve_responseLabel.Text = "Vieta sėkmingai rezervuota!";
            }

            UpdateReservedSeatsTable();
            InitializeSchedulerResources();
            InitializeSchedulerAppointments();
        }

        ///RESERVATION SCHEDULER CONTROL BEHAVIOR ==============================================================================================
        ///TO DO:
        ///     Change width of appointments so subject text could be seen
        ///     Add hallgroups dependency -> Insert hallgroups into resources with their idsort set as hallgroupid
        ///                               -> By having hallgroupid add parent id of them to rehular resources parentid
        ///                               
        int id = 0;

        private void ResourcesTree1_NodesReloaded(object sender, EventArgs e)
        {
            resourcesTree1.BeginUpdate();
            this.BeginInvoke(new MethodInvoker(CollapseTree));
        }
        private void CollapseTree()
        {
            resourcesTree1.CollapseAll();
            resourcesTree1.EndUpdate();
        }
        private void appointmentsTableAdapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert)
            {
                id = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT @@IDENTITY", appointmentsTableAdapter.Connection))
                {
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    e.Row["UniqueId"] = id;
                }
            }
        }
        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            CommitTask();
        }
        private void schedulerStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            CommitTask();
        }
        private void schedulerStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {

            CommitTask();
            ReservedSeatSchedulerDataStorage.SetAppointmentId(((Appointment)e.Objects[0]), id);
        }
        void CommitTask()
        {

            appointmentsTableAdapter.Update(ganttDataSet.Appointments);
            this.ganttDataSet.Appointments.AcceptChanges();
        }

    }
}