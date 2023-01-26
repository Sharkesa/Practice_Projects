using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervacijuSistema
{
    class DataSourceControl
    {
        public static List<dataClass.Hall> GetHallList()
        {
            List<dataClass.Hall> halls = new List<dataClass.Hall> { };

            DataTable hallData = SQLHelper.GetTable("prc_selectHalls", "all", new string[1]);
            foreach (DataRow row in hallData.Rows)
            {
                dataClass.Hall hall = new dataClass.Hall();
                hall.hallid = int.Parse(row.ItemArray[0].ToString());
                hall.name = row.ItemArray[1].ToString();

                halls.Add(hall);
            }

            return halls;
        }

        //MUST BE IMPLEMENTED FOR LATER USE
        //public static List<dataClass.HallGroup> GetHallGroupList()
        //{
        //    List<dataClass.HallGroup> hallgroups = new List<dataClass.HallGroup> { };

        //    DataTable hallgroupslist = SQLHelper.GetTable("prc_selectHallGroups", "all", new string[1]);

        //    throw NotImplementedException(

        //    return hallgroups;
        //}

        public static List<dataClass.HallGroup> GetHallGroupList(string hallid)
        {
            List<dataClass.HallGroup> hallgroups = new List<dataClass.HallGroup> { };

            DataTable hallgroupslist = SQLHelper.GetTable("prc_selectHallGroupsByHallID", "hallid", new string[] { hallid });

            foreach (DataRow row in hallgroupslist.Rows)
            {
                dataClass.HallGroup hallGroup = new dataClass.HallGroup();

                hallGroup.hallGroupID = row.ItemArray[0].ToString();
                hallGroup.hallid = row.ItemArray[1].ToString();
                hallGroup.hallGroupName = row.ItemArray[2].ToString();
                hallGroup.az = row.ItemArray[3].ToString();

                hallgroups.Add(hallGroup);
            }

            return hallgroups;
        }

        public static List<dataClass.Event> GetEventList()
        {
            List<dataClass.Event> events = new List<dataClass.Event> { };
            DataTable eventData = SQLHelper.GetTable("prc_selectEvents", "all", new string[1]);

            foreach (DataRow row in eventData.Rows)
            {
                dataClass.Event _event = new dataClass.Event();
                _event.hallID = row["hallid"].ToString();
                _event.hallName = row["hallname"].ToString();
                _event.eventName = row["eventname"].ToString();
                _event.eventTimeFrom = row["eventtimefrom"].ToString();
                _event.eventTimeTo = row["eventtimeto"].ToString();
                _event.ticketCount = row["ticketcount"].ToString();
                _event.eventID = row["eventid"].ToString();
                events.Add(_event);
            }

            return events;
        }

        public static List<dataClass.Event> GetEventList(string hallid)
        {
            List<dataClass.Event> events = new List<dataClass.Event> { };
            DataTable eventData = SQLHelper.GetTable("prc_selectEventsByHallID", "hallid", new string[] { hallid });

            foreach (DataRow row in eventData.Rows)
            {
                dataClass.Event _event = new dataClass.Event();
                _event.hallName = _event.GetHallName(row["hallid"].ToString(), GetHallList());
                _event.hallID = row["hallid"].ToString();
                _event.eventName = row["eventname"].ToString();
                _event.eventTimeFrom = row["eventtimefrom"].ToString();
                _event.eventTimeTo = row["eventtimeto"].ToString();
                _event.ticketCount = row["ticketcount"].ToString();
                _event.eventID = row["eventid"].ToString();

                events.Add(_event);
            }

            return events;
        }

        internal static bool SeatExists(string hallid, string hallgroupid, string seatrow, string seatrowletter, string seatnumber, string seatnumberletter)
        {
            string[] details =
            {
                "",
                hallid,
                hallgroupid,
                seatrow,
                seatrowletter,
                seatnumber,
                seatnumberletter
            };

            DataTable seat = SQLHelper.GetTable("prc_getSeat", "seatdetails", details);

            if (seat.Rows.Count > 0)
                return true;

            return false;
        }
    }
}
