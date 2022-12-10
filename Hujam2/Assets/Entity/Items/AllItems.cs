using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity.Items
{
    public class AllItems:MonoBehaviour
    {
        public List<EventItem> getAllItems()
        {
            List<EventItem> temp = new List<EventItem>();
            temp.Add(new EventItem()
            {
                ItemCount=0,
                ItemID=1,
                ItemName="LifeRadar",
                GetItemEventsID = {1,3,5},
                UseItemEventsID = {13,52,34}

            });
            return temp;
        }
    }
}
