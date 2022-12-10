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
        private Medic med;
        private Security sec;
        private Scientist sci;
        private TechSupport techSup;
        private TechnicalEngineer techE;
        private List<ShipStats> Stats;
        private List<EventItem> Items;
        private void Awake()
        {
            Items = gameObject.GetComponent<AllItems>().Items;
            Stats = gameObject.GetComponent<AllStats>().Stats;
            med = MedicP.GetComponent<Medic>();
            sec = SecurityP.GetComponent<Security>();
            sci = ScientistP.GetComponent<Scientist>();
            techSup = TechSupportP.GetComponent<TechSupport>();
            techE = TechnicalEngineerP.GetComponent<TechnicalEngineer>();
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
        public List<ItemEvent> getAllItemEvents()
        {
            List<ItemEvent> temp = new List<ItemEvent>();
            temp.Add(new ItemEvent()
            {
                EventID = 1,
                RequiredCrews = {med,techE},
                RequiredDay = 0,
                RequiredItem = null,
                EffectedStat = null,
                Label = "Örnek Başlık",
                Text = "Caitlin, Peter ile beraber bir yaşam ölçme radarı yapmak istiyor fakat Peter buna sıcak bakmıyor. Kimin tarafını tutmalıyım.",
                EventOptions = {
                new EventOption
                {
                    OptionText="Caitlin haklı radarı kullanmak işimize yarayabilir.",
                    TargetEventID=1,
                    PositiveEffectCrew=med,
                    NegativeEffectCrew=techE,
                    MoodEffect=20,
                    GetItem=ItemFinder("LifeRadar")

                },

                new EventOption
                {
                    OptionText="Peter haklı böyle bir icat gereksiz malzeme kaybı.   ",
                    TargetEventID=1,
                    PositiveEffectCrew=techE,
                    NegativeEffectCrew=med,
                    MoodEffect=20,
                }},
            });
            return temp;
        }
    }
}
