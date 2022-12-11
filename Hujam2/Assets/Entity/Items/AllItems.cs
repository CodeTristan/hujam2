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
        private List<EventItem> temp;
        public List<EventItem> getAllItems()
        {
            temp = new List<EventItem>();
            EventItem a = new EventItem();

            a.ItemCount = 0;
            a.ItemID = 1;
            a.ItemName = "LifeRadar";
            temp.Add(a);
            Debug.Log(temp.Count);
            return temp;
        }
    }
}
