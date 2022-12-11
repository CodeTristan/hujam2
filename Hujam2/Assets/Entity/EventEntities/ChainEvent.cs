using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entity.EventEntities
{
    public class ChainEvent : ItemEvent
    {
        public int PrevEventID { get; set; }        
        public int NextEventID { get; set; }

    }
}
