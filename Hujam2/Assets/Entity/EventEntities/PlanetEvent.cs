using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entity.EventEntities
{
    public class PlanetEvent
    {
        public int EventID{ get; set; }
        public string Label{ get; set; }
        public float DangerRate{ get; set; }
        public ShipStats WaterStat{ get; set; }
        public ShipStats FuelStat{ get; set; }
        public ShipStats FoodStat{ get; set; }
    }
}
