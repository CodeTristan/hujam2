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
            temp.Add(new EventItem() 
            {
                ItemCount=0,
                ItemID=1,
                ItemName="LifeRadar",
                
                
                
            });
            return temp;
        }
    }
}
