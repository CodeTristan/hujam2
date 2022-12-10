using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity
{
    public class EventOption:MonoBehaviour
    {
        public int TargetEventID{ get; set; }
        public GameObject FirstCrew{ get; set; }
        public GameObject SecondCrew{ get; set; }
        public EventItem MyProperty { get; set; }
    }
}
