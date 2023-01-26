
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace RezervacijuSistema
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeScaleYear timeScaleYear2 = new DevExpress.XtraScheduler.TimeScaleYear();
            DevExpress.XtraScheduler.TimeScaleQuarter timeScaleQuarter2 = new DevExpress.XtraScheduler.TimeScaleQuarter();
            DevExpress.XtraScheduler.TimeScaleMonth timeScaleMonth2 = new DevExpress.XtraScheduler.TimeScaleMonth();
            DevExpress.XtraScheduler.TimeScaleWeek timeScaleWeek2 = new DevExpress.XtraScheduler.TimeScaleWeek();
            DevExpress.XtraScheduler.TimeScaleDay timeScaleDay2 = new DevExpress.XtraScheduler.TimeScaleDay();
            DevExpress.XtraScheduler.TimeScaleHour timeScaleHour2 = new DevExpress.XtraScheduler.TimeScaleHour();
            DevExpress.XtraScheduler.TimeScale15Minutes timeScale15Minutes2 = new DevExpress.XtraScheduler.TimeScale15Minutes();
            DevExpress.XtraScheduler.TimeRuler timeRuler4 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler5 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler6 = new DevExpress.XtraScheduler.TimeRuler();
            this.xtraMaintabControl = new DevExpress.XtraTab.XtraTabControl();
            this.SeatListTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.UploadXMLStatus = new DevExpress.XtraEditors.LabelControl();
            this.UploadXMLButton = new DevExpress.XtraEditors.SimpleButton();
            this.SeatListHallSelectLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.SeatListHallSelectLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SeatListGridControl = new DevExpress.XtraGrid.GridControl();
            this.SeatListGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EventListTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.EventListGridControls = new DevExpress.XtraGrid.GridControl();
            this.EventListGridControlView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CreateEventTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.EventTimeToLabel = new DevExpress.XtraEditors.LabelControl();
            this.EventTimeFromLabel = new DevExpress.XtraEditors.LabelControl();
            this.EventDateLabel = new DevExpress.XtraEditors.LabelControl();
            this.EventHallLabel = new DevExpress.XtraEditors.LabelControl();
            this.EventNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.TimeEditTo = new DevExpress.XtraEditors.TimeEdit();
            this.TimeEditFrom = new DevExpress.XtraEditors.TimeEdit();
            this.CreateEventButton = new DevExpress.XtraEditors.SimpleButton();
            this.EventStartDateTimeOffset = new DevExpress.XtraEditors.DateTimeOffsetEdit();
            this.CreateEventHallSelect = new DevExpress.XtraEditors.GridLookUpEdit();
            this.CreateEventHallSelectView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CreateEventNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ReserveSeatTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.Reserve_responseLabel = new DevExpress.XtraEditors.LabelControl();
            this.ExactSeatSearchButton = new DevExpress.XtraEditors.SimpleButton();
            this.ExactSeatSearch = new DevExpress.XtraEditors.LabelControl();
            this.reserved_seatrowletter = new DevExpress.XtraEditors.TextEdit();
            this.reserved_seatnumber = new DevExpress.XtraEditors.TextEdit();
            this.reserved_seatnumberletter = new DevExpress.XtraEditors.TextEdit();
            this.reserved_seatrow = new DevExpress.XtraEditors.TextEdit();
            this.ReserveSeatsButton = new DevExpress.XtraEditors.SimpleButton();
            this.ReserveSeatEventSelectLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.ReserveSeatEventSelectLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ReserveSeatHallGroupSelectLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.ReserveSeatHallGroupSelectLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ReserveSeatHallSelectLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.ReserveSeatHallSelectLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NotReserverSeatListGridControl = new DevExpress.XtraGrid.GridControl();
            this.NotReserverSeatListGridControlView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ReservationSchedulerTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.resourcesTree1 = new DevExpress.XtraScheduler.UI.ResourcesTree();
            this.colIdSort = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.colId = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.colDescription = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.ReservedSeatSchedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.ReservedSeatSchedulerDataStorage = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.appointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ganttDataSet = new RezervacijuSistema.GanttDataSet();
            this.resourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReservationTabSplitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.appointmentsTableAdapter = new RezervacijuSistema.GanttDataSetTableAdapters.AppointmentsTableAdapter();
            this.resourcesTableAdapter = new RezervacijuSistema.GanttDataSetTableAdapters.ResourcesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.xtraMaintabControl)).BeginInit();
            this.xtraMaintabControl.SuspendLayout();
            this.SeatListTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeatListHallSelectLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatListHallSelectLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatListGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatListGridView)).BeginInit();
            this.EventListTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventListGridControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventListGridControlView)).BeginInit();
            this.CreateEventTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventStartDateTimeOffset.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateEventHallSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateEventHallSelectView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateEventNameTextEdit.Properties)).BeginInit();
            this.ReserveSeatTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reserved_seatrowletter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserved_seatnumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserved_seatnumberletter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserved_seatrow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatEventSelectLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatEventSelectLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatHallGroupSelectLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatHallGroupSelectLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatHallSelectLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatHallSelectLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotReserverSeatListGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotReserverSeatListGridControlView)).BeginInit();
            this.ReservationSchedulerTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservedSeatSchedulerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservedSeatSchedulerDataStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ganttDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationTabSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationTabSplitContainer.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationTabSplitContainer.Panel2)).BeginInit();
            this.ReservationTabSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraMaintabControl
            // 
            this.xtraMaintabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraMaintabControl.Location = new System.Drawing.Point(0, 0);
            this.xtraMaintabControl.Name = "xtraMaintabControl";
            this.xtraMaintabControl.SelectedTabPage = this.SeatListTabPage;
            this.xtraMaintabControl.Size = new System.Drawing.Size(1408, 905);
            this.xtraMaintabControl.TabIndex = 0;
            this.xtraMaintabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.SeatListTabPage,
            this.EventListTabPage,
            this.CreateEventTabPage,
            this.ReserveSeatTabPage,
            this.ReservationSchedulerTabPage});
            // 
            // SeatListTabPage
            // 
            this.SeatListTabPage.Controls.Add(this.UploadXMLStatus);
            this.SeatListTabPage.Controls.Add(this.UploadXMLButton);
            this.SeatListTabPage.Controls.Add(this.SeatListHallSelectLookUpEdit);
            this.SeatListTabPage.Controls.Add(this.SeatListGridControl);
            this.SeatListTabPage.Name = "SeatListTabPage";
            this.SeatListTabPage.Size = new System.Drawing.Size(1406, 880);
            this.SeatListTabPage.Text = "Salės vietos";
            // 
            // UploadXMLStatus
            // 
            this.UploadXMLStatus.Location = new System.Drawing.Point(432, 22);
            this.UploadXMLStatus.Name = "UploadXMLStatus";
            this.UploadXMLStatus.Size = new System.Drawing.Size(16, 13);
            this.UploadXMLStatus.TabIndex = 3;
            this.UploadXMLStatus.Text = "/...";
            // 
            // UploadXMLButton
            // 
            this.UploadXMLButton.Location = new System.Drawing.Point(294, 4);
            this.UploadXMLButton.Name = "UploadXMLButton";
            this.UploadXMLButton.Size = new System.Drawing.Size(119, 48);
            this.UploadXMLButton.TabIndex = 2;
            this.UploadXMLButton.Text = "Upload XML file";
            this.UploadXMLButton.Click += new System.EventHandler(this.UploadXMLButton_Click);
            // 
            // SeatListHallSelectLookUpEdit
            // 
            this.SeatListHallSelectLookUpEdit.Location = new System.Drawing.Point(21, 19);
            this.SeatListHallSelectLookUpEdit.Name = "SeatListHallSelectLookUpEdit";
            this.SeatListHallSelectLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SeatListHallSelectLookUpEdit.Properties.PopupView = this.SeatListHallSelectLookUpEditView;
            this.SeatListHallSelectLookUpEdit.Size = new System.Drawing.Size(249, 20);
            this.SeatListHallSelectLookUpEdit.TabIndex = 1;
            this.SeatListHallSelectLookUpEdit.EditValueChanged += new System.EventHandler(this.SeatListHallSelectLookUpEdit_EditValueChanged);
            // 
            // SeatListHallSelectLookUpEditView
            // 
            this.SeatListHallSelectLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SeatListHallSelectLookUpEditView.Name = "SeatListHallSelectLookUpEditView";
            this.SeatListHallSelectLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SeatListHallSelectLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // SeatListGridControl
            // 
            this.SeatListGridControl.Location = new System.Drawing.Point(4, 58);
            this.SeatListGridControl.MainView = this.SeatListGridView;
            this.SeatListGridControl.Name = "SeatListGridControl";
            this.SeatListGridControl.Size = new System.Drawing.Size(1140, 819);
            this.SeatListGridControl.TabIndex = 0;
            this.SeatListGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.SeatListGridView});
            // 
            // SeatListGridView
            // 
            this.SeatListGridView.GridControl = this.SeatListGridControl;
            this.SeatListGridView.Name = "SeatListGridView";
            this.SeatListGridView.OptionsBehavior.Editable = false;
            this.SeatListGridView.OptionsSelection.EnableAppearanceHideSelection = false;
            // 
            // EventListTabPage
            // 
            this.EventListTabPage.Controls.Add(this.EventListGridControls);
            this.EventListTabPage.Name = "EventListTabPage";
            this.EventListTabPage.Size = new System.Drawing.Size(1406, 880);
            this.EventListTabPage.Text = "Renginiai";
            // 
            // EventListGridControls
            // 
            this.EventListGridControls.Location = new System.Drawing.Point(4, 4);
            this.EventListGridControls.MainView = this.EventListGridControlView;
            this.EventListGridControls.Name = "EventListGridControls";
            this.EventListGridControls.Size = new System.Drawing.Size(1140, 873);
            this.EventListGridControls.TabIndex = 0;
            this.EventListGridControls.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.EventListGridControlView});
            // 
            // EventListGridControlView
            // 
            this.EventListGridControlView.GridControl = this.EventListGridControls;
            this.EventListGridControlView.Name = "EventListGridControlView";
            // 
            // CreateEventTabPage
            // 
            this.CreateEventTabPage.Controls.Add(this.EventTimeToLabel);
            this.CreateEventTabPage.Controls.Add(this.EventTimeFromLabel);
            this.CreateEventTabPage.Controls.Add(this.EventDateLabel);
            this.CreateEventTabPage.Controls.Add(this.EventHallLabel);
            this.CreateEventTabPage.Controls.Add(this.EventNameLabel);
            this.CreateEventTabPage.Controls.Add(this.TimeEditTo);
            this.CreateEventTabPage.Controls.Add(this.TimeEditFrom);
            this.CreateEventTabPage.Controls.Add(this.CreateEventButton);
            this.CreateEventTabPage.Controls.Add(this.EventStartDateTimeOffset);
            this.CreateEventTabPage.Controls.Add(this.CreateEventHallSelect);
            this.CreateEventTabPage.Controls.Add(this.CreateEventNameTextEdit);
            this.CreateEventTabPage.Name = "CreateEventTabPage";
            this.CreateEventTabPage.Size = new System.Drawing.Size(1406, 880);
            this.CreateEventTabPage.Text = "Įvesti naują renginį";
            // 
            // EventTimeToLabel
            // 
            this.EventTimeToLabel.Location = new System.Drawing.Point(566, 319);
            this.EventTimeToLabel.Name = "EventTimeToLabel";
            this.EventTimeToLabel.Size = new System.Drawing.Size(11, 13);
            this.EventTimeToLabel.TabIndex = 10;
            this.EventTimeToLabel.Text = "Iki";
            // 
            // EventTimeFromLabel
            // 
            this.EventTimeFromLabel.Location = new System.Drawing.Point(428, 319);
            this.EventTimeFromLabel.Name = "EventTimeFromLabel";
            this.EventTimeFromLabel.Size = new System.Drawing.Size(19, 13);
            this.EventTimeFromLabel.TabIndex = 9;
            this.EventTimeFromLabel.Text = "Nuo";
            // 
            // EventDateLabel
            // 
            this.EventDateLabel.Location = new System.Drawing.Point(388, 255);
            this.EventDateLabel.Name = "EventDateLabel";
            this.EventDateLabel.Size = new System.Drawing.Size(23, 13);
            this.EventDateLabel.TabIndex = 8;
            this.EventDateLabel.Text = "Data";
            // 
            // EventHallLabel
            // 
            this.EventHallLabel.Location = new System.Drawing.Point(388, 186);
            this.EventHallLabel.Name = "EventHallLabel";
            this.EventHallLabel.Size = new System.Drawing.Size(20, 13);
            this.EventHallLabel.TabIndex = 7;
            this.EventHallLabel.Text = "Salė";
            // 
            // EventNameLabel
            // 
            this.EventNameLabel.Location = new System.Drawing.Point(388, 120);
            this.EventNameLabel.Name = "EventNameLabel";
            this.EventNameLabel.Size = new System.Drawing.Size(103, 13);
            this.EventNameLabel.TabIndex = 6;
            this.EventNameLabel.Text = "Renginio pavadinimas";
            // 
            // TimeEditTo
            // 
            this.TimeEditTo.EditValue = new System.DateTime(2023, 1, 23, 0, 0, 0, 0);
            this.TimeEditTo.Location = new System.Drawing.Point(566, 338);
            this.TimeEditTo.Name = "TimeEditTo";
            this.TimeEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TimeEditTo.Properties.MaskSettings.Set("mask", "HH:mm");
            this.TimeEditTo.Size = new System.Drawing.Size(100, 20);
            this.TimeEditTo.TabIndex = 5;
            // 
            // TimeEditFrom
            // 
            this.TimeEditFrom.EditValue = new System.DateTime(2023, 1, 23, 0, 0, 0, 0);
            this.TimeEditFrom.Location = new System.Drawing.Point(428, 338);
            this.TimeEditFrom.Name = "TimeEditFrom";
            this.TimeEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TimeEditFrom.Properties.MaskSettings.Set("mask", "HH:mm");
            this.TimeEditFrom.Size = new System.Drawing.Size(100, 20);
            this.TimeEditFrom.TabIndex = 4;
            // 
            // CreateEventButton
            // 
            this.CreateEventButton.Location = new System.Drawing.Point(428, 417);
            this.CreateEventButton.Name = "CreateEventButton";
            this.CreateEventButton.Size = new System.Drawing.Size(238, 72);
            this.CreateEventButton.TabIndex = 3;
            this.CreateEventButton.Text = "Įtraukti renginį";
            this.CreateEventButton.Click += new System.EventHandler(this.CreateEventButton_Click);
            // 
            // EventStartDateTimeOffset
            // 
            this.EventStartDateTimeOffset.EditValue = null;
            this.EventStartDateTimeOffset.Location = new System.Drawing.Point(388, 274);
            this.EventStartDateTimeOffset.Name = "EventStartDateTimeOffset";
            this.EventStartDateTimeOffset.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EventStartDateTimeOffset.Properties.MaskSettings.Set("mask", "yyyy/MM/dd");
            this.EventStartDateTimeOffset.Size = new System.Drawing.Size(334, 20);
            this.EventStartDateTimeOffset.TabIndex = 2;
            // 
            // CreateEventHallSelect
            // 
            this.CreateEventHallSelect.Location = new System.Drawing.Point(388, 205);
            this.CreateEventHallSelect.Name = "CreateEventHallSelect";
            this.CreateEventHallSelect.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreateEventHallSelect.Properties.PopupView = this.CreateEventHallSelectView;
            this.CreateEventHallSelect.Size = new System.Drawing.Size(334, 20);
            this.CreateEventHallSelect.TabIndex = 1;
            // 
            // CreateEventHallSelectView
            // 
            this.CreateEventHallSelectView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.CreateEventHallSelectView.Name = "CreateEventHallSelectView";
            this.CreateEventHallSelectView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.CreateEventHallSelectView.OptionsView.ShowGroupPanel = false;
            // 
            // CreateEventNameTextEdit
            // 
            this.CreateEventNameTextEdit.Location = new System.Drawing.Point(388, 140);
            this.CreateEventNameTextEdit.Name = "CreateEventNameTextEdit";
            this.CreateEventNameTextEdit.Size = new System.Drawing.Size(334, 20);
            this.CreateEventNameTextEdit.TabIndex = 0;
            // 
            // ReserveSeatTabPage
            // 
            this.ReserveSeatTabPage.Controls.Add(this.Reserve_responseLabel);
            this.ReserveSeatTabPage.Controls.Add(this.ExactSeatSearchButton);
            this.ReserveSeatTabPage.Controls.Add(this.ExactSeatSearch);
            this.ReserveSeatTabPage.Controls.Add(this.reserved_seatrowletter);
            this.ReserveSeatTabPage.Controls.Add(this.reserved_seatnumber);
            this.ReserveSeatTabPage.Controls.Add(this.reserved_seatnumberletter);
            this.ReserveSeatTabPage.Controls.Add(this.reserved_seatrow);
            this.ReserveSeatTabPage.Controls.Add(this.ReserveSeatsButton);
            this.ReserveSeatTabPage.Controls.Add(this.ReserveSeatEventSelectLookUpEdit);
            this.ReserveSeatTabPage.Controls.Add(this.ReserveSeatHallGroupSelectLookUpEdit);
            this.ReserveSeatTabPage.Controls.Add(this.ReserveSeatHallSelectLookUpEdit);
            this.ReserveSeatTabPage.Controls.Add(this.NotReserverSeatListGridControl);
            this.ReserveSeatTabPage.Name = "ReserveSeatTabPage";
            this.ReserveSeatTabPage.Size = new System.Drawing.Size(1406, 880);
            this.ReserveSeatTabPage.Text = "Rezervuoti vietą";
            // 
            // Reserve_responseLabel
            // 
            this.Reserve_responseLabel.Location = new System.Drawing.Point(29, 400);
            this.Reserve_responseLabel.Name = "Reserve_responseLabel";
            this.Reserve_responseLabel.Size = new System.Drawing.Size(0, 13);
            this.Reserve_responseLabel.TabIndex = 11;
            // 
            // ExactSeatSearchButton
            // 
            this.ExactSeatSearchButton.Location = new System.Drawing.Point(19, 358);
            this.ExactSeatSearchButton.Name = "ExactSeatSearchButton";
            this.ExactSeatSearchButton.Size = new System.Drawing.Size(217, 36);
            this.ExactSeatSearchButton.TabIndex = 10;
            this.ExactSeatSearchButton.Text = "Rezervuoti vietą";
            this.ExactSeatSearchButton.Click += new System.EventHandler(this.ExactSeatSearchButton_Click);
            // 
            // ExactSeatSearch
            // 
            this.ExactSeatSearch.Location = new System.Drawing.Point(78, 254);
            this.ExactSeatSearch.Name = "ExactSeatSearch";
            this.ExactSeatSearch.Size = new System.Drawing.Size(104, 13);
            this.ExactSeatSearch.TabIndex = 9;
            this.ExactSeatSearch.Text = "Tikslios vietos paieška";
            // 
            // reserved_seatrowletter
            // 
            this.reserved_seatrowletter.EditValue = "";
            this.reserved_seatrowletter.Location = new System.Drawing.Point(130, 273);
            this.reserved_seatrowletter.Name = "reserved_seatrowletter";
            this.reserved_seatrowletter.Properties.NullValuePrompt = "Raidė";
            this.reserved_seatrowletter.Size = new System.Drawing.Size(95, 20);
            this.reserved_seatrowletter.TabIndex = 8;
            // 
            // reserved_seatnumber
            // 
            this.reserved_seatnumber.Location = new System.Drawing.Point(29, 332);
            this.reserved_seatnumber.Name = "reserved_seatnumber";
            this.reserved_seatnumber.Properties.NullValuePrompt = "Vietos numeris";
            this.reserved_seatnumber.Size = new System.Drawing.Size(95, 20);
            this.reserved_seatnumber.TabIndex = 7;
            // 
            // reserved_seatnumberletter
            // 
            this.reserved_seatnumberletter.EditValue = "";
            this.reserved_seatnumberletter.Location = new System.Drawing.Point(130, 332);
            this.reserved_seatnumberletter.Name = "reserved_seatnumberletter";
            this.reserved_seatnumberletter.Properties.NullValuePrompt = "Raidė";
            this.reserved_seatnumberletter.Size = new System.Drawing.Size(95, 20);
            this.reserved_seatnumberletter.TabIndex = 6;
            // 
            // reserved_seatrow
            // 
            this.reserved_seatrow.EditValue = "";
            this.reserved_seatrow.Location = new System.Drawing.Point(29, 273);
            this.reserved_seatrow.Name = "reserved_seatrow";
            this.reserved_seatrow.Properties.NullValuePrompt = "Vietos eilė";
            this.reserved_seatrow.Size = new System.Drawing.Size(95, 20);
            this.reserved_seatrow.TabIndex = 5;
            // 
            // ReserveSeatsButton
            // 
            this.ReserveSeatsButton.Location = new System.Drawing.Point(19, 156);
            this.ReserveSeatsButton.Name = "ReserveSeatsButton";
            this.ReserveSeatsButton.Size = new System.Drawing.Size(217, 36);
            this.ReserveSeatsButton.TabIndex = 4;
            this.ReserveSeatsButton.Text = "Rezervuoti vietas";
            this.ReserveSeatsButton.Click += new System.EventHandler(this.ReserveSeatsButton_Click);
            // 
            // ReserveSeatEventSelectLookUpEdit
            // 
            this.ReserveSeatEventSelectLookUpEdit.Location = new System.Drawing.Point(19, 110);
            this.ReserveSeatEventSelectLookUpEdit.Name = "ReserveSeatEventSelectLookUpEdit";
            this.ReserveSeatEventSelectLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReserveSeatEventSelectLookUpEdit.Properties.NullText = "Pasirinkite renginį";
            this.ReserveSeatEventSelectLookUpEdit.Properties.PopupView = this.ReserveSeatEventSelectLookUpEditView;
            this.ReserveSeatEventSelectLookUpEdit.Size = new System.Drawing.Size(217, 20);
            this.ReserveSeatEventSelectLookUpEdit.TabIndex = 3;
            this.ReserveSeatEventSelectLookUpEdit.EditValueChanged += new System.EventHandler(this.ReserveSeatHallSelectLookUpEdit_EditValueChanged);
            // 
            // ReserveSeatEventSelectLookUpEditView
            // 
            this.ReserveSeatEventSelectLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ReserveSeatEventSelectLookUpEditView.Name = "ReserveSeatEventSelectLookUpEditView";
            this.ReserveSeatEventSelectLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ReserveSeatEventSelectLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // ReserveSeatHallGroupSelectLookUpEdit
            // 
            this.ReserveSeatHallGroupSelectLookUpEdit.Location = new System.Drawing.Point(19, 84);
            this.ReserveSeatHallGroupSelectLookUpEdit.Name = "ReserveSeatHallGroupSelectLookUpEdit";
            this.ReserveSeatHallGroupSelectLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReserveSeatHallGroupSelectLookUpEdit.Properties.NullText = "Pasirinkite salės grupę";
            this.ReserveSeatHallGroupSelectLookUpEdit.Properties.PopupView = this.ReserveSeatHallGroupSelectLookUpEditView;
            this.ReserveSeatHallGroupSelectLookUpEdit.Size = new System.Drawing.Size(217, 20);
            this.ReserveSeatHallGroupSelectLookUpEdit.TabIndex = 2;
            this.ReserveSeatHallGroupSelectLookUpEdit.EditValueChanged += new System.EventHandler(this.ReserveSeatHallSelectLookUpEdit_EditValueChanged);
            // 
            // ReserveSeatHallGroupSelectLookUpEditView
            // 
            this.ReserveSeatHallGroupSelectLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ReserveSeatHallGroupSelectLookUpEditView.Name = "ReserveSeatHallGroupSelectLookUpEditView";
            this.ReserveSeatHallGroupSelectLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ReserveSeatHallGroupSelectLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // ReserveSeatHallSelectLookUpEdit
            // 
            this.ReserveSeatHallSelectLookUpEdit.EditValue = "Pasirinkite salę";
            this.ReserveSeatHallSelectLookUpEdit.Location = new System.Drawing.Point(19, 58);
            this.ReserveSeatHallSelectLookUpEdit.Name = "ReserveSeatHallSelectLookUpEdit";
            this.ReserveSeatHallSelectLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReserveSeatHallSelectLookUpEdit.Properties.NullText = "Pasirinkite salę";
            this.ReserveSeatHallSelectLookUpEdit.Properties.PopupView = this.ReserveSeatHallSelectLookUpEditView;
            this.ReserveSeatHallSelectLookUpEdit.Size = new System.Drawing.Size(217, 20);
            this.ReserveSeatHallSelectLookUpEdit.TabIndex = 1;
            this.ReserveSeatHallSelectLookUpEdit.EditValueChanged += new System.EventHandler(this.ReserveSeatHallSelectLookUpEdit_EditValueChanged);
            // 
            // ReserveSeatHallSelectLookUpEditView
            // 
            this.ReserveSeatHallSelectLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.ReserveSeatHallSelectLookUpEditView.Name = "ReserveSeatHallSelectLookUpEditView";
            this.ReserveSeatHallSelectLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ReserveSeatHallSelectLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // NotReserverSeatListGridControl
            // 
            this.NotReserverSeatListGridControl.Location = new System.Drawing.Point(265, 3);
            this.NotReserverSeatListGridControl.MainView = this.NotReserverSeatListGridControlView;
            this.NotReserverSeatListGridControl.Name = "NotReserverSeatListGridControl";
            this.NotReserverSeatListGridControl.Size = new System.Drawing.Size(783, 874);
            this.NotReserverSeatListGridControl.TabIndex = 0;
            this.NotReserverSeatListGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.NotReserverSeatListGridControlView});
            // 
            // NotReserverSeatListGridControlView
            // 
            this.NotReserverSeatListGridControlView.GridControl = this.NotReserverSeatListGridControl;
            this.NotReserverSeatListGridControlView.Name = "NotReserverSeatListGridControlView";
            // 
            // ReservationSchedulerTabPage
            // 
            this.ReservationSchedulerTabPage.Controls.Add(this.splitContainerControl1);
            this.ReservationSchedulerTabPage.Name = "ReservationSchedulerTabPage";
            this.ReservationSchedulerTabPage.Size = new System.Drawing.Size(1406, 880);
            this.ReservationSchedulerTabPage.Text = "Rezervuotos vietos";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.resourcesTree1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.ReservedSeatSchedulerControl);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1406, 880);
            this.splitContainerControl1.SplitterPosition = 338;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // resourcesTree1
            // 
            this.resourcesTree1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colIdSort,
            this.colId,
            this.colDescription});
            this.resourcesTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourcesTree1.Location = new System.Drawing.Point(0, 0);
            this.resourcesTree1.Name = "resourcesTree1";
            this.resourcesTree1.OptionsBehavior.Editable = false;
            this.resourcesTree1.SchedulerControl = this.ReservedSeatSchedulerControl;
            this.resourcesTree1.Size = new System.Drawing.Size(338, 880);
            this.resourcesTree1.TabIndex = 0;
            // 
            // colIdSort
            // 
            this.colIdSort.FieldName = "IdSort";
            this.colIdSort.Name = "colIdSort";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            // 
            // ReservedSeatSchedulerControl
            // 
            this.ReservedSeatSchedulerControl.BackColor = System.Drawing.SystemColors.WindowText;
            this.ReservedSeatSchedulerControl.DataStorage = this.ReservedSeatSchedulerDataStorage;
            this.ReservedSeatSchedulerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReservedSeatSchedulerControl.ForeColor = System.Drawing.Color.White;
            this.ReservedSeatSchedulerControl.Location = new System.Drawing.Point(0, 0);
            this.ReservedSeatSchedulerControl.Name = "ReservedSeatSchedulerControl";
            this.ReservedSeatSchedulerControl.OptionsBehavior.ShowRemindersForm = false;
            this.ReservedSeatSchedulerControl.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.ReservedSeatSchedulerControl.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.ReservedSeatSchedulerControl.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.ReservedSeatSchedulerControl.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.ReservedSeatSchedulerControl.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.ReservedSeatSchedulerControl.OptionsCustomization.AllowAppointmentMultiSelect = false;
            this.ReservedSeatSchedulerControl.OptionsCustomization.AllowAppointmentResize = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.ReservedSeatSchedulerControl.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.ReservedSeatSchedulerControl.OptionsRangeControl.AllowChangeActiveView = false;
            this.ReservedSeatSchedulerControl.OptionsRangeControl.Scales.Add(timeScaleYear2);
            this.ReservedSeatSchedulerControl.OptionsRangeControl.Scales.Add(timeScaleQuarter2);
            this.ReservedSeatSchedulerControl.OptionsRangeControl.Scales.Add(timeScaleMonth2);
            this.ReservedSeatSchedulerControl.OptionsRangeControl.Scales.Add(timeScaleWeek2);
            this.ReservedSeatSchedulerControl.OptionsRangeControl.Scales.Add(timeScaleDay2);
            this.ReservedSeatSchedulerControl.OptionsRangeControl.Scales.Add(timeScaleHour2);
            this.ReservedSeatSchedulerControl.OptionsRangeControl.Scales.Add(timeScale15Minutes2);
            this.ReservedSeatSchedulerControl.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Never;
            this.ReservedSeatSchedulerControl.Size = new System.Drawing.Size(1058, 880);
            this.ReservedSeatSchedulerControl.Start = new System.DateTime(2023, 1, 25, 0, 0, 0, 0);
            this.ReservedSeatSchedulerControl.TabIndex = 0;
            this.ReservedSeatSchedulerControl.Text = "schedulerControl1";
            this.ReservedSeatSchedulerControl.Views.AgendaView.Enabled = false;
            this.ReservedSeatSchedulerControl.Views.DayView.AppointmentDisplayOptions.AppointmentWidth = 100;
            this.ReservedSeatSchedulerControl.Views.DayView.TimeRulers.Add(timeRuler4);
            this.ReservedSeatSchedulerControl.Views.FullWeekView.TimeRulers.Add(timeRuler5);
            this.ReservedSeatSchedulerControl.Views.GanttView.AppointmentDisplayOptions.PercentCompleteDisplayType = DevExpress.XtraScheduler.PercentCompleteDisplayType.None;
            this.ReservedSeatSchedulerControl.Views.GanttView.AppointmentDisplayOptions.StretchAppointments = true;
            this.ReservedSeatSchedulerControl.Views.GanttView.CellsAutoHeightOptions.AutoHeightMode = DevExpress.XtraScheduler.SchedulerCellAutoHeightMode.Full;
            this.ReservedSeatSchedulerControl.Views.GanttView.CellsAutoHeightOptions.Enabled = true;
            this.ReservedSeatSchedulerControl.Views.GanttView.CellsAutoHeightOptions.MinHeight = 50;
            this.ReservedSeatSchedulerControl.Views.MonthView.Enabled = false;
            this.ReservedSeatSchedulerControl.Views.TimelineView.Enabled = false;
            this.ReservedSeatSchedulerControl.Views.WeekView.Enabled = false;
            this.ReservedSeatSchedulerControl.Views.WorkWeekView.Enabled = false;
            this.ReservedSeatSchedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler6);
            this.ReservedSeatSchedulerControl.Views.YearView.UseOptimizedScrolling = false;
            // 
            // ReservedSeatSchedulerDataStorage
            // 
            // 
            // 
            // 
            this.ReservedSeatSchedulerDataStorage.AppointmentDependencies.AutoReload = false;
            // 
            // 
            // 
            this.ReservedSeatSchedulerDataStorage.Appointments.CommitIdToDataSource = false;
            this.ReservedSeatSchedulerDataStorage.Appointments.DataSource = this.appointmentsBindingSource;
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(0, "None", "&None", System.Drawing.SystemColors.Window);
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))));
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.AllDay = "AllDay";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.Description = "Description";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.End = "EndDate";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.Label = "Label";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.Location = "Location";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.ResourceId = "ResourceId";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.Start = "StartDate";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.Status = "Status";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.Subject = "Subject";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.TimeZoneId = "TimeZoneId";
            this.ReservedSeatSchedulerDataStorage.Appointments.Mappings.Type = "Type";
            // 
            // 
            // 
            this.ReservedSeatSchedulerDataStorage.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("CustomField1", "CustomField1"));
            this.ReservedSeatSchedulerDataStorage.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("IdSort", "IdSort"));
            this.ReservedSeatSchedulerDataStorage.Resources.DataSource = this.resourcesBindingSource;
            this.ReservedSeatSchedulerDataStorage.Resources.Mappings.Caption = "Description";
            this.ReservedSeatSchedulerDataStorage.Resources.Mappings.Color = "Color";
            this.ReservedSeatSchedulerDataStorage.Resources.Mappings.Id = "Id";
            this.ReservedSeatSchedulerDataStorage.Resources.Mappings.Image = "Image";
            this.ReservedSeatSchedulerDataStorage.Resources.Mappings.ParentId = "ParentId";
            this.ReservedSeatSchedulerDataStorage.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsInserted);
            this.ReservedSeatSchedulerDataStorage.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
            this.ReservedSeatSchedulerDataStorage.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsDeleted);
            // 
            // appointmentsBindingSource
            // 
            this.appointmentsBindingSource.DataMember = "Appointments";
            this.appointmentsBindingSource.DataSource = this.ganttDataSet;
            // 
            // ganttDataSet
            // 
            this.ganttDataSet.DataSetName = "GanttDataSet";
            this.ganttDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // resourcesBindingSource
            // 
            this.resourcesBindingSource.DataMember = "Resources";
            this.resourcesBindingSource.DataSource = this.ganttDataSet;
            // 
            // ReservationTabSplitContainer
            // 
            this.ReservationTabSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ReservationTabSplitContainer.Name = "ReservationTabSplitContainer";
            this.ReservationTabSplitContainer.Size = new System.Drawing.Size(200, 100);
            this.ReservationTabSplitContainer.TabIndex = 0;
            // 
            // appointmentsTableAdapter
            // 
            this.appointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // resourcesTableAdapter
            // 
            this.resourcesTableAdapter.ClearBeforeFill = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 905);
            this.Controls.Add(this.xtraMaintabControl);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.xtraMaintabControl)).EndInit();
            this.xtraMaintabControl.ResumeLayout(false);
            this.SeatListTabPage.ResumeLayout(false);
            this.SeatListTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeatListHallSelectLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatListHallSelectLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatListGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatListGridView)).EndInit();
            this.EventListTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EventListGridControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventListGridControlView)).EndInit();
            this.CreateEventTabPage.ResumeLayout(false);
            this.CreateEventTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventStartDateTimeOffset.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateEventHallSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateEventHallSelectView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateEventNameTextEdit.Properties)).EndInit();
            this.ReserveSeatTabPage.ResumeLayout(false);
            this.ReserveSeatTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reserved_seatrowletter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserved_seatnumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserved_seatnumberletter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reserved_seatrow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatEventSelectLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatEventSelectLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatHallGroupSelectLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatHallGroupSelectLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatHallSelectLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSeatHallSelectLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotReserverSeatListGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotReserverSeatListGridControlView)).EndInit();
            this.ReservationSchedulerTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resourcesTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservedSeatSchedulerControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservedSeatSchedulerDataStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ganttDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationTabSplitContainer.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationTabSplitContainer.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationTabSplitContainer)).EndInit();
            this.ReservationTabSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraMaintabControl;
        private DevExpress.XtraTab.XtraTabPage SeatListTabPage;
        private DevExpress.XtraTab.XtraTabPage EventListTabPage;
        private DevExpress.XtraGrid.GridControl SeatListGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView SeatListGridView;
        private DevExpress.XtraEditors.GridLookUpEdit SeatListHallSelectLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView SeatListHallSelectLookUpEditView;
        private DevExpress.XtraEditors.SimpleButton UploadXMLButton;
        private DevExpress.XtraEditors.LabelControl UploadXMLStatus;
        private DevExpress.XtraTab.XtraTabPage CreateEventTabPage;
        private DevExpress.XtraEditors.SimpleButton CreateEventButton;
        private DevExpress.XtraEditors.DateTimeOffsetEdit EventStartDateTimeOffset;
        private DevExpress.XtraEditors.GridLookUpEdit CreateEventHallSelect;
        private DevExpress.XtraGrid.Views.Grid.GridView CreateEventHallSelectView;
        private DevExpress.XtraEditors.TextEdit CreateEventNameTextEdit;
        private DevExpress.XtraEditors.LabelControl EventTimeToLabel;
        private DevExpress.XtraEditors.LabelControl EventTimeFromLabel;
        private DevExpress.XtraEditors.LabelControl EventDateLabel;
        private DevExpress.XtraEditors.LabelControl EventHallLabel;
        private DevExpress.XtraEditors.LabelControl EventNameLabel;
        private DevExpress.XtraEditors.TimeEdit TimeEditTo;
        private DevExpress.XtraEditors.TimeEdit TimeEditFrom;
        private DevExpress.XtraGrid.GridControl EventListGridControls;
        private DevExpress.XtraGrid.Views.Grid.GridView EventListGridControlView;
        private DevExpress.XtraTab.XtraTabPage ReserveSeatTabPage;
        private DevExpress.XtraEditors.SimpleButton ReserveSeatsButton;
        private DevExpress.XtraEditors.GridLookUpEdit ReserveSeatEventSelectLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView ReserveSeatEventSelectLookUpEditView;
        private DevExpress.XtraEditors.GridLookUpEdit ReserveSeatHallGroupSelectLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView ReserveSeatHallGroupSelectLookUpEditView;
        private DevExpress.XtraEditors.GridLookUpEdit ReserveSeatHallSelectLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView ReserveSeatHallSelectLookUpEditView;
        private DevExpress.XtraGrid.GridControl NotReserverSeatListGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView NotReserverSeatListGridControlView;
        private DevExpress.XtraTab.XtraTabPage ReservationSchedulerTabPage;
        private DevExpress.XtraEditors.SplitContainerControl ReservationTabSplitContainer;
        private DevExpress.XtraScheduler.SchedulerDataStorage SchedulerDataStorage;
        private DevExpress.XtraEditors.SimpleButton ExactSeatSearchButton;
        private DevExpress.XtraEditors.LabelControl ExactSeatSearch;
        private DevExpress.XtraEditors.TextEdit reserved_seatrowletter;
        private DevExpress.XtraEditors.TextEdit reserved_seatnumber;
        private DevExpress.XtraEditors.TextEdit reserved_seatnumberletter;
        private DevExpress.XtraEditors.TextEdit reserved_seatrow;
        private DevExpress.XtraEditors.LabelControl Reserve_responseLabel;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraScheduler.UI.ResourcesTree resourcesTree1;
        private SchedulerControl ReservedSeatSchedulerControl;
        private SchedulerDataStorage ReservedSeatSchedulerDataStorage;
        private GanttDataSet ganttDataSet;
        private BindingSource appointmentsBindingSource;
        private GanttDataSetTableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private BindingSource resourcesBindingSource;
        private GanttDataSetTableAdapters.ResourcesTableAdapter resourcesTableAdapter;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colIdSort;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colId;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colDescription;
    }
}