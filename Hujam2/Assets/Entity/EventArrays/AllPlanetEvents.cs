using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity.EventArrays
{
    public class AllPlanetEvents : MonoBehaviour
    {
        private List<ShipStats> Stats;
        private EventEntitySearcher searcher;
        private StatAndItemLister lister;
        private void Awake()
        {
            lister = new StatAndItemLister();    
            Stats = new List<ShipStats>(); 
            Stats = lister.allStats;
        }
    }
}
