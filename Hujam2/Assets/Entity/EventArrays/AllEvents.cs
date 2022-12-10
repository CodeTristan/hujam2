using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entity.EventArrays
{
    public class AllEvents
    {
        public List<Event> getAllEvents()
        {
            List<Event> BasicEvents = new List<Event>();
            BasicEvents.Add(new Event()
            {
                EventID = 0,
                Label = "Control Event",
                Text = "This event is for setting index"
            });
            return BasicEvents;
        }
    }
}
