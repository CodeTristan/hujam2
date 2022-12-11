using Assets.Entity.EventEntities;
using Assets.Entity.Items;
using Assets.Entity.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity.EventArrays
{
    public class AllChainEvents:MonoBehaviour
    {
        #region GameObject and defines
        [SerializeField] GameObject ScientistP;
        [SerializeField] GameObject SecurityP;
        [SerializeField] GameObject MedicP;
        [SerializeField] GameObject TechSupportP;
        [SerializeField] GameObject TechnicalEngineerP;
        private Medic med;
        private Security sec;
        private Scientist sci;
        private TechSupport techSup;
        private TechnicalEngineer techE;
        private List<ShipStats> Stats;
        private List<EventItem> Items;
        private EventEntitySearcher searcher;
        private StatAndItemLister lister;
        #endregion
        private void Awake()
        {
            lister = new StatAndItemLister();
            Items = new List<EventItem>();
            Stats = new List<ShipStats>();
            
            Items = lister.allItems;
            Stats = lister.allStats;
            med = MedicP.GetComponent<Medic>();
            sec = SecurityP.GetComponent<Security>();
            sci = ScientistP.GetComponent<Scientist>();
            techSup = TechSupportP.GetComponent<TechSupport>();
            techE = TechnicalEngineerP.GetComponent<TechnicalEngineer>();
        }
        private List<ChainEvent> temp;
        public List<ChainEvent> getAllChainEvents()
        {
            searcher = new EventEntitySearcher();
            temp = new List<ChainEvent>();
            #region Event1
            #endregion
            return temp;
        }
    }
}
