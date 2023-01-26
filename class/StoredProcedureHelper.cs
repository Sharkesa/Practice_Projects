using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervacijuSistema
{
    class StoredProcedureHelper
    {
        public static SqlCommand AddSqlCommandParams(DataTable table, SqlCommand comm, int rowID)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                comm.Parameters.AddWithValue(table.Columns[i].ColumnName, table.Rows[rowID][i]);
            }

            return comm;
        }

        public static SqlCommand AddSqlEventCommandParams(string[] args, SqlCommand comm)
        {
            string[] eventColumns =
            {
                "@hallID", "@eventName", "@eventtimefrom", "@eventtimeto", "@ticketcount"
            };

            for (int i = 0; i < eventColumns.Count(); i++)
            {
                comm.Parameters.AddWithValue(eventColumns[i], args[i]);
            }

            return comm;
        }

        public static SqlCommand AddSqlReservedSeatCommandParams(string[] args, SqlCommand comm)
        {
            string[] SeatColumns =
            {
                "@hallid", "@seatid", "@eventid"
            };

            for (int i = 0; i < SeatColumns.Count(); i++)
            {
                comm.Parameters.AddWithValue(SeatColumns[i], args[i]);
            }

            return comm;
        }

        public static SqlCommand AddSqlSeatCommandParams(string[] args, SqlCommand comm)
        {
            string[] SeatColumns =
            {
                "@hallid", "@hallgroupid", "@seatid", "@seatrow", "@seatrowletter", "@seatnumber", "@seatnumberletter", 
                "@color", "@price"
            };

            for (int i = 0; i < SeatColumns.Count(); i++)
            {
                comm.Parameters.AddWithValue(SeatColumns[i], args[i]);
            }

            return comm;
        }

        public static SqlCommand AddSqlResourceCommandParams(string[] args, SqlCommand comm)
        {
            string[] SeatColumns =
            {
                "@idsort", "@description", "@customfield1", "@parentid"
            };

            for (int i = 0; i < SeatColumns.Count(); i++)
            {
                comm.Parameters.AddWithValue(SeatColumns[i], args[i]);
            }

            return comm;
        }

        internal static SqlCommand AddSqlAppointmentCommandParams(string[] details, SqlCommand comm)
        {
            string[] SeatColumns =
            {
                "@eventName", "@timefrom", "@timeto", "@resourceid"
            };

            for (int i = 0; i < SeatColumns.Count(); i++)
            {
                if(SeatColumns[i] == "@resourceid")
                {
                    int resourceID = int.Parse(details[i]);
                    comm.Parameters.AddWithValue(SeatColumns[i], resourceID);
                }
                else
                    comm.Parameters.AddWithValue(SeatColumns[i], details[i]);
            }

            return comm;
        }
    }
}
