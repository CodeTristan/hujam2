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
        public List<EventItem> Items;
        private void Awake()
        {
            Items = getAllItems();
        }
        private List<EventItem> temp;
        public List<EventItem> getAllItems()
        {
            temp = new List<EventItem>();
            EventItem item1 = new EventItem();

            item1.ItemCount = 0;
            item1.ItemID = 1;
            item1.ItemName = "LifeRadar";
            temp.Add(item1);
            return temp;
        }
    }
}
