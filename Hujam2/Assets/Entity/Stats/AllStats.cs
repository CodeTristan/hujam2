using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity.Stats
{
    public class AllStats : MonoBehaviour
    {              
        private List<ShipStats> temp;
        public List<ShipStats> getAllShipStats()
        {
            temp = new List<ShipStats>();
            ShipStats a = new ShipStats();


            a.StatName = "Food";
            a.StatValue = 100f;
            temp.Add(a);

            ShipStats a1 = new ShipStats();

            a1.StatName = "Water";
            a1.StatValue = 80f;
            temp.Add(a1);

            ShipStats a2 = new ShipStats();

            a2.StatName = "Fuel";
            a2.StatValue = 70f;
            temp.Add(a2);

            ShipStats a3 = new ShipStats();
            a3.StatName = "Durability";
            a3.StatValue = 60f;
            temp.Add(a3);


            ShipStats a4 = new ShipStats();
            a4.StatName = "FoodConsump";
            a4.StatValue = -5f;
            temp.Add(a4);
            ShipStats a5 = new ShipStats();

            a5.StatName = "WaterConsump";
            a5.StatValue = -5f;
            temp.Add(a5);

            ShipStats a6 = new ShipStats();

            a6.StatName = "FuelConsump";
            a6.StatValue = -5f;
            temp.Add(a6);
           
            return temp;
        }
    }
}
