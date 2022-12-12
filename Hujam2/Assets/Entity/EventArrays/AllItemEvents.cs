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
        private EventOption op3;
        private CosmicEvent a;

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
        private void Start()
        {
            

        }
        private List<CosmicEvent> temp;
        public List<CosmicEvent> getAllItemEvents()
        {
            searcher = new EventEntitySearcher();
            temp = new List<CosmicEvent>();
            #region IndexControlEvent
            //Event 0
            CosmicEvent controlEvent = new CosmicEvent();
            controlEvent.EventID = 0;
            controlEvent.Label = "This event for control indexing";
            controlEvent.Text = "This is just for control text";
            temp.Add(controlEvent);
            #endregion
            #region Event1
            //Event 1
            a = new CosmicEvent();
            a.EventID = 1;
            a.RequiredCrews = new List<Crew>();
            a.RequiredCrews.Add(med);
            a.RequiredCrews.Add(techE);
            a.Label = "Radar";
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
            a = new CosmicEvent();
            op1 = new EventOption();
            op2 = new EventOption();
            op3 = new EventOption();
            a.EventOptions = new List<EventOption>();
            a.RequiredCrews = new List<Crew>();
            a.EffectedStat = searcher.statFinder(Stats, "Fuel");
            a.EventID = 2;
            a.RequiredCrews.Add(sec);
            a.Label = "UZAY KORSANLARI";
            a.Text = "Üzerinde uzay korsanları yazan bir gemi hızla gemimize yaklaşıyor tehlikeli olabilirler. Sarah kendimizi korumak için ateş açmamızı öneriyor.";
            op1.TargetEventID = 2;
            op1.OptionText = "Gemiye kilitlenin ve silahları ateşleyin!";
            op1.UseItem = searcher.ItemFinder(Items, "Gun");
            op1.MoodEffect = 30;
            op1.PositiveEffectCrew = sec;
            a.EventOptions.Add(op1);
            op2.TargetEventID = 2;
            op2.OptionText = "Gazı kökleyip buradan gidiyoruz";
            op2.StatEffect = -20;
            a.EventOptions.Add(op2);
            op3.TargetEventID = 2;
            op3.OptionText = "Lazer kalkanlarını aktive edin ve harekete geçin";
            op3.UseItem = searcher.ItemFinder(Items, "Shield");
            a.EventOptions.Add(op3);
            temp.Add(a);
            #endregion           
            return temp;
        }
    }
}
