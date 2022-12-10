using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity.Stats
{
    public class AllStats:MonoBehaviour
    {
        public List<ShipStats> Stats;
        private void Awake()
        {
            Stats = getAllShipStats();
        }
        private List<ShipStats> temp;
        public List<ShipStats> getAllShipStats()
        {
            temp = new List<ShipStats>();
            temp.Add(new ShipStats()
            {
                StatName="Food",
                StatValue=100f,
            });
            temp.Add(new ShipStats()
            {
                StatName = "Water",
                StatValue = 80f,
            });
            temp.Add(new ShipStats()
            {
                StatName = "Fuel",
                StatValue = 70f,
            });
            temp.Add(new ShipStats()
            {
                StatName = "Durability",
                StatValue = 60f,
            });
            return temp;
        }
    }
}
