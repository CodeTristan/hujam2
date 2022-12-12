using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity.Items
{
    public class AllItems : MonoBehaviour
    {
        private EventItem a;
        private List<EventItem> temp;
        public List<EventItem> getAllItems()
        {
            temp = new List<EventItem>();
            a = new EventItem();

            a.ItemCount = 0;
            a.ItemID = 1;
            a.ItemName = "LifeRadar";
            temp.Add(a);
            a = new EventItem();
            a.ItemCount=1;
            a.ItemID=2;
            a.ItemName = "Gun";
            temp.Add(a);
            a = new EventItem();
            a.ItemCount = 1;
            a.ItemID = 3;
            a.ItemName = "Shield";
            temp.Add(a);
            a = new EventItem();
            a.ItemCount = 0;
            a.ItemID = 4;
            a.ItemName = "Drive";
            temp.Add(a);
            return temp;
        }
    }
}
