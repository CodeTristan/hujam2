using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entity.EventEntities
{
    public class ItemEvent : Event
    {
        public EventItem RequiredItem{ get; set; }
        public EventItem GetItem{ get; set; }
        public EventItem UseItem{ get; set; }
        public bool InProgress{ get; set; }
    }
}
