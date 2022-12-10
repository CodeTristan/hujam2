using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Entity.Stats
{
    public class AllStats
    {
        public List<ShipStats> getAllShipStats()
        {
            List<ShipStats> temp = new List<ShipStats>();
            temp.Add(new ShipStats()
            {
                StatName="Food",
                StatValue=100
            });
            temp.Add(new ShipStats()
            {
                StatName = "Water",
                StatValue = 80
            });
            temp.Add(new ShipStats()
            {
                StatName = "Fuel",
                StatValue = 70
            });
            temp.Add(new ShipStats()
            {
                StatName = "Durability",
                StatValue = 60
            });
            return temp;
        }
    }
}
