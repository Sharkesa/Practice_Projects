using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RezervacijuSistema
{
    class SQLHelper
    {

        public static bool InsertHallDataToDB(DataSet dataSet)
        {
            int tableID = 0;
            string methodString = "SQLHelper/InserHallDataToDB/ ";

            foreach (DataTable table in dataSet.Tables)
            {
                string consString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
                try
                {
                    using (SqlConnection con = new SqlConnection(consString))
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            string queryAddHalls = "prc_addHall";
                            string queryAddHallGroups = "prc_addHallGroup";
                            string queryAddSeatsTable = "prc_addSeat";

                            string[] queries = { queryAddHalls, queryAddHallGroups, queryAddSeatsTable };

                            SqlCommand comm = new SqlCommand(queries[tableID], con);
                            comm.CommandType = CommandType.StoredProcedure;

                            comm = StoredProcedureHelper.AddSqlCommandParams(table, comm, i);

                            if (con.State != ConnectionState.Open)
                            {
                                con.Close();
                                con.Open();
                            }

                            comm.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(methodString + ex.Message);
                    return false;
                }

                tableID++;
            }
            return true;
        }

        public static DataTable GetTable(string command, string getBy, string[] values)
        {
            DataTable table = new DataTable();
            getBy = getBy.ToLower();

            string connStr = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            {

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand(command, con);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    switch (getBy)
                    {
                        case "hallid":
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@hallID", values[0]);
                            break;
                        case "hallgroupid":
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@hallID", values[0]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@hallGroupID", values[1]);
                            break;
                        case "eventid":
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@hallID", values[0]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@hallGroupID", values[1]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@eventid", values[2]);
                            break;
                        case "resources_eventid":
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@seatid", values[0]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@eventid", values[1]);
                            break;
                        case "seatdetails":
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@eventid", values[0]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@hallid", values[1]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@hallgroupid", values[2]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@seatrow", values[3]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@seatrowletter", values[4]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@seatnumber", values[5]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@seatnumberletter", values[6]);
                            break;
                        case "seatdetails+hallgroup":
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@hallid", values[0]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@hallgroupid", values[1]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@seatrow", values[2]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@seatrowletter", values[3]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@seatnumber", values[4]);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@seatnumberletter", values[5]);
                            break;
                        default:
                            break;
                    }

                    con.Open();

                    dataAdapter.Fill(table);
                    dataAdapter.Dispose();

                }

            }

            return table;

        }

        internal static bool InsertAppointment(string[] details)
        {
            string consString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(consString))
                {
                    SqlCommand comm = new SqlCommand("prc_addAppointment", con);
                    comm.CommandType = CommandType.StoredProcedure;

                    comm = StoredProcedureHelper.AddSqlAppointmentCommandParams(details, comm);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    comm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }


            return true;
        }

        public static bool InsertEventsToDB(string[] eventDetails)
        {

            string consString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(consString))
                {
                    SqlCommand comm = new SqlCommand("prc_addevent", con);
                    comm.CommandType = CommandType.StoredProcedure;

                    comm = StoredProcedureHelper.AddSqlEventCommandParams(eventDetails, comm);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    comm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


            return true;
        }

        internal static bool InsertReservedSeats(string[] details)
        {
            string consString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(consString))
                {
                    SqlCommand comm = new SqlCommand("prc_addreservedseat", con);
                    comm.CommandType = CommandType.StoredProcedure;

                    comm = StoredProcedureHelper.AddSqlReservedSeatCommandParams(details, comm);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    comm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }


            return true;
        }

        public static bool InsertSeatData(string[] details)
        {
            string consString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(consString))
                {
                    SqlCommand comm = new SqlCommand("prc_addSeat", con);
                    comm.CommandType = CommandType.StoredProcedure;

                    comm = StoredProcedureHelper.AddSqlSeatCommandParams(details, comm);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    comm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }


            return true;
        }

        public static bool InsertResources(string[] details)
        {
            string consString = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(consString))
                {
                    SqlCommand comm = new SqlCommand("prc_addResources", con);
                    comm.CommandType = CommandType.StoredProcedure;

                    comm = StoredProcedureHelper.AddSqlResourceCommandParams(details, comm);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Close();
                        con.Open();
                    }

                    comm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }


            return true;
        }
    }
}
