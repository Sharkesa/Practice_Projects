using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervacijuSistema
{
    /// <summary>
    /// Mainly used to get lists of data from DB or existence of data in there
    /// </summary>
    class DataSourceControl
    {
        /// <summary>
        /// Gets list of halls by stored procedure "prc_selectHalls"
        /// </summary>
        /// <returns>Returns list of halls, of custom datatype hall</returns>
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
        /// <summary>
        /// Gets list of hallgroups by stored procedure "prc_selectHallGroups"
        /// </summary>
        /// <param name="hallid">Gets only hallgroups that are in selected hall</param>
        /// <returns>List of halls of custom datatype hallgroup</returns>
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
        /// <summary>
        /// Gets list of events by stored procedure
        /// </summary>
        /// <returns>List of events of type Event</returns>
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
        /// <summary>
        /// Different approach to get eventlist, but only in selected hall
        /// </summary>
        /// <param name="hallid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Checks whether given seat details exist all together in DB
        /// </summary>
        /// <param name="hallid"></param>
        /// <param name="hallgroupid"></param>
        /// <param name="seatrow"></param>
        /// <param name="seatrowletter"></param>
        /// <param name="seatnumber"></param>
        /// <param name="seatnumberletter"></param>
        /// <returns>True if seat is found</returns>
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
