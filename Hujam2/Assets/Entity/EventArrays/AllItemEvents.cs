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
    public class AllItemEvents : MonoBehaviour
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

        private EventOption op1;
        private EventOption op2;

        #endregion

        private void Awake()
        {
            lister = new StatAndItemLister();
            Items = new List<EventItem>();
            Stats = new List<ShipStats>();
            Debug.Log(lister.allItems.Count + " allitemEvents itemcount");
            Items = lister.allItems;
            Stats = lister.allStats;
            med = MedicP.GetComponent<Medic>();
            sec = SecurityP.GetComponent<Security>();
            sci = ScientistP.GetComponent<Scientist>();
            techSup = TechSupportP.GetComponent<TechSupport>();
            techE = TechnicalEngineerP.GetComponent<TechnicalEngineer>();
        }
        private void Start()
        {
            

        }
        private List<ItemEvent> temp;
        public List<ItemEvent> getAllItemEvents()
        {
            searcher = new EventEntitySearcher();
            temp = new List<ItemEvent>();
            #region IndexControlEvent
            //Event 0
            ItemEvent controlEvent = new ItemEvent();
            controlEvent.EventID = 0;
            controlEvent.Label = "This event for control indexing";
            controlEvent.Text = "This is just for control text";
            //Event Option 1
            EventOption op001 = new EventOption();
            op001.OptionText = "Control event option1.";
            op001.TargetEventID = 0;
            op001.PositiveEffectCrew = med;
            op001.NegativeEffectCrew = techE;
            op001.MoodEffect = 40;
            op001.GetItem = searcher.ItemFinder(Items, "LifeRadar");
            controlEvent.EventOptions.Add(op001);
            //eventOption2
            EventOption op002 = new EventOption();
            op002.OptionText = "Control event option2.   ";
            op002.TargetEventID = 0;
            op002.PositiveEffectCrew = techE;
            op002.NegativeEffectCrew = med;
            op002.MoodEffect = 20;
            controlEvent.EventOptions.Add(op002);
            temp.Add(controlEvent);
            #endregion
            #region Event1
            //Event 1
            ItemEvent a = new ItemEvent();
            a.EventID = 1;
            a.RequiredCrews = new List<Crew>();
            a.RequiredCrews.Add(med);
            a.RequiredCrews.Add(techE);
            a.Label = "Örnek Başlık";
            a.Text = "Caitlin, Peter ile beraber bir yaşam ölçme radarı yapmak istiyor fakat Peter buna sıcak bakmıyor. Kimin tarafını tutmalıyım.";
            //eventOption1
            op1 = new EventOption();
            a.EventOptions = new List<EventOption>();
            op1.OptionText = "Caitlin haklı radarı kullanmak işimize yarayabilir.";
            op1.TargetEventID = 1;
            op1.PositiveEffectCrew = med;
            op1.NegativeEffectCrew = techE;
            op1.MoodEffect = 20;
            op1.GetItem = searcher.ItemFinder(Items, "LifeRadar");
            a.EventOptions.Add(op1);
            //eventOption2
            op2 = new EventOption();
            op2.OptionText = "Peter haklı böyle bir icat gereksiz malzeme kaybı.   ";
            op2.TargetEventID = 1;
            op2.PositiveEffectCrew = techE;
            op2.NegativeEffectCrew = med;
            op2.MoodEffect = 20;
            a.EventOptions.Add(op2);
            temp.Add(a);

            #endregion
            #region Event2
            //Event2
            #endregion
            Debug.Log(MedicP.GetComponent<Medic>().Name);
            Debug.Log(med.Name);
            Debug.Log(op1.NegativeEffectCrew.Name);
            return temp;
        }
    }
}
