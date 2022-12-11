using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Entity.EventEntities;

namespace Assets.Entity.EventArrays
{
    public class AllRepeatableEvents : MonoBehaviour
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
        private List<CosmicEvent> temp;
        public List<CosmicEvent> getAllRepeatableEvents()
        {
            searcher = new EventEntitySearcher();
            temp = new List<CosmicEvent>();
            #region IndexControlEvent
            CosmicEvent controlEvent = new CosmicEvent();
            controlEvent.EventID = 0;
            controlEvent.Label = "This event for control indexing";
            controlEvent.Text = "This is just for control text";
            temp.Add(controlEvent);
            #endregion
            #region Event1
            CosmicEvent event1 = new CosmicEvent();
            event1.RequiredCrews = new List<Crew>();
            event1.RequiredCrews.Add(techE);
            event1.EffectedStat = searcher.statFinder(Stats,"Fuel");
            event1.Label = "Peter'ın yakıt sorunu";
            event1.Text = "Peter yakıtı kendi kişisel amaçları için kullanıyormuş. Tayfamız bunun problem yaratabileceğini söylüyor.";
            EventOption e1op1 = new EventOption();
            event1.EventOptions = new List<EventOption>();
            e1op1.NegativeEffectCrew = techE;
            e1op1.MoodEffect = 20;
            e1op1.OptionText = "Hayır Peter yakıtı içemezsin ";
            event1.EventOptions.Add(e1op1);
            EventOption e1op2 = new EventOption();
            e1op2.PositiveEffectCrew = techE;
            e1op2.StatEffect= -5;
            e1op2.OptionText = "Dikkatli davranmaya özen gösterdiğin sürece seni rahat bırakıyorum. ";
            event1.EventOptions.Add(e1op2);
            temp.Add(event1);
            #endregion
            return temp;
        }
    }
}
