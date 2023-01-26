using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervacijuSistema.dataClass
{
    class Event
    {
        public string hallID { get; set; }
        public string hallName { get; set; }
        public string eventName { get; set; }
        public string eventTimeFrom { get; set; }
        public string eventTimeTo { get; set; }
        public string ticketCount { get; set; }
        public string eventID { get; set; }

        public string GetHallName(string hallid, List<Hall> halls)
        {
            foreach(Hall hall in halls)
            {
                if (hall.hallid.ToString().Equals(hallid))
                {
                    return hall.name;
                }
            }

            return "";
        }
    }
}
