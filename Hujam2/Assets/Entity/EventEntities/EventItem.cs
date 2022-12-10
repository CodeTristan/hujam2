using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity
{
    public class EventItem:MonoBehaviour
    {
        public int ItemID{ get; set; }
        public string ItemName{ get; set; }
        public int ItemCount{ get; set; }
        //todo itemBase event array
        public List<int> GetItemEventsID{ get; set; }
        //todo itemBase event array
        public List<int> UseItemEventsID{ get; set; }
    }
}
