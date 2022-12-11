using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Entity.EventArrays
{
    public class EventEntitySearcher : MonoBehaviour
    {
        public EventItem ItemFinder(List<EventItem> Items,string ItemName)
        {
            List<EventItem> controlList = new List<EventItem>();
            controlList = Items;
            //Debug.Log(Items.Count + " eventEntitySearcherItemCount");
            EventItem a = new EventItem();
            for (int i = 0; i < controlList.Count; i++)
            {                
                if (controlList[i].ItemName == ItemName)
                {
                    a = controlList[i];
                    return a;
                }
            }
            return a;
        }
        public ShipStats statFinder(List<ShipStats> Stats,string StatName)
        {
            ShipStats a = new ShipStats();
            for (int i = 0; i < Stats.Count; i++)
            {
                if (Stats[i].StatName == StatName)
                {
                    a=Stats[i];
                    return a;
                }
            }
            return a;
        }
    }
}
