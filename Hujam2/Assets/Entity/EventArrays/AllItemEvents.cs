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
        [SerializeField] GameObject ScientistP;
        [SerializeField] GameObject SecurityP;
        [SerializeField] GameObject MedicP;
        [SerializeField] GameObject TechSupportP;
        [SerializeField] GameObject TechnicalEngineerP;
        public List<ItemEvent> Events;
        private Medic med;
        private Security sec;
        private Scientist sci;
        private TechSupport techSup;
        private TechnicalEngineer techE;
        private List<ShipStats> Stats;
        private List<EventItem> Items;


        private void Start()
        {
            Items = gameObject.GetComponent<AllItems>().Items;
            Stats = gameObject.GetComponent<AllStats>().Stats;
            med = new Medic();
            techE = new TechnicalEngineer();
            med = MedicP.GetComponent<Medic>();
            sec = SecurityP.GetComponent<Security>();
            sci = ScientistP.GetComponent<Scientist>();
            techSup = TechSupportP.GetComponent<TechSupport>();
            techE = TechnicalEngineerP.GetComponent<TechnicalEngineer>();
            Events = getAllItemEvents();
        }
        private EventItem ItemFinder(string ItemName)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ItemName == ItemName)
                {
                    return Items[i];
                }
            }
            return null;
        }
        private ShipStats statFinder(string StatName)
        {
            for (int i = 0; i < Stats.Count; i++)
            {
                if (Stats[i].StatName == StatName)
                {
                    return Stats[i];
                }
            }
            return null;
        }
       private List<ItemEvent> temp;
        public List<ItemEvent> getAllItemEvents()
        {
            temp = new List<ItemEvent>();
            ItemEvent a = new ItemEvent();

            a.InProgress = false;
            a.UseItem = null;
            a.EventID = 1;
            a.RequiredCrews = new List<Crew>();
            a.RequiredCrews.Add(med);
            a.RequiredCrews.Add(techE);
            a.RequiredDay = 0;
            a.RequiredItem = null;
            a.EffectedStat = null;
            a.Label = "Örnek Başlık";
            a.Text = "Caitlin, Peter ile beraber bir yaşam ölçme radarı yapmak istiyor fakat Peter buna sıcak bakmıyor. Kimin tarafını tutmalıyım.";
            EventOption op1 = new EventOption();
            a.EventOptions = new List<EventOption>();
            op1.OptionText = "Caitlin haklı radarı kullanmak işimize yarayabilir.";
            op1.TargetEventID = 1;
            op1.PositiveEffectCrew = med;
            op1.NegativeEffectCrew = techE;
            op1.MoodEffect = 20;
            op1.GetItem = ItemFinder("LifeRadar");
            a.EventOptions.Add(op1);
            EventOption op2 = new EventOption();
            op2.OptionText = "Peter haklı böyle bir icat gereksiz malzeme kaybı.   ";
            op2.TargetEventID = 1;
            op2.PositiveEffectCrew = techE;
            op2.NegativeEffectCrew = med;
            op2.MoodEffect = 20;
            a.EventOptions.Add(op2);
            temp.Add(a);

            return temp;
        }
    }
}
