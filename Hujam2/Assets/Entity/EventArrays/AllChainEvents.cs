﻿using Assets.Entity.EventEntities;
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
    public class AllChainEvents : MonoBehaviour
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
        private ChainEvent a;

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
            #region IndexControlEvent
            //Event 0
            ChainEvent controlEvent = new ChainEvent();
            controlEvent.EventID = 0;
            controlEvent.Label = "This event for control indexing";
            controlEvent.Text = "This is just for control text";
            temp.Add(controlEvent);
            #endregion
            #region Event1
            a = new ChainEvent();
            a.EventID = 1;
            a.NextEventID = 2;
            a.EffectedStat = searcher.statFinder(Stats, "FoodConsump");
            a.Label = "Fare";
            a.Text = "Sarah havalandırmada bir fare bulmuş. Uzaya çıkmayı başarmış ilk fare olmasının ilginçliğinin yanı sıra yemeklerimizi yediğini de keşfettik. Sarah  tam fareyi yiyecekken Gauss onu deney faresi olarak kullanmak istediğini söyledi ve bizi durdurdu.";
            a.RequiredCrews = new List<Crew>();
            a.RequiredCrews.Add(sec);
            a.RequiredCrews.Add(sci);
            a.EventOptions = new List<EventOption>();
            op1 = new EventOption();
            op1.TargetEventID = 1;
            op1.OptionText = "Fareyi Sarah’ın yemesine izin ver.";
            op1.MoodEffect = 30;
            op1.PositiveEffectCrew = sec;
            op1.NegativeEffectCrew = sci;
            a.EventOptions.Add(op1);
            op2 = new EventOption();
            op2.TargetEventID = 1;
            op2.OptionText = "Gauss’u dinle, fareyi deney için kullan";
            op2.MoodEffect = 30;
            op2.PositiveEffectCrew = sci;
            op2.NegativeEffectCrew = sec;
            op2.StatEffect = -1;
            op2.ChainTrigger = true;
            a.EventOptions.Add(op2);
            temp.Add(a);
            #endregion
            #region Event1.2
            a = new ChainEvent();
            op1 = new EventOption();
            op2 = new EventOption();
            a.EventOptions = new List<EventOption>();
            a.RequiredCrews = new List<Crew>();
            a.EventID = 2;
            a.PrevEventID = 1;
            a.NextEventID = 3;
            a.EffectedStat = searcher.statFinder(Stats, "FoodConsump");
            a.RequiredCrews.Add(sci);
            a.RequiredCrews.Add(sec);
            a.Label = "Fare Zehirlenmesi";
            a.Text = "Bu sabah kalktığımızda Gauss çok hasta gözüküyordu. Fareyle deney yapacağım diye zehirlenmiş. Fareyi atarsak belki düzelebilir ama Gauss atmamızı istemiyor. Ne yapalım?";
            op1.TargetEventID = 2;
            op1.OptionText = "Fareyi atmalıyız Gauss hastalanmış. ";
            op1.MoodEffect = 30;
            op1.PositiveEffectCrew=sec;
            op1.NegativeEffectCrew=sci;
            op1.StatEffect = +1;
            a.EventOptions.Add(op1);
            op2.TargetEventID = 2;
            op2.OptionText = "Gauss o fareyle güzel buluşlar yapacak, atamayız.";
            op2.MoodEffect = 30;
            op2.PositiveEffectCrew=sci;
            op2.NegativeEffectCrew=sec;
            op2.ChainTrigger=true;
            a.EventOptions.Add(op2);
            temp.Add(a);
            #endregion
            #region Event 1.3
            a = new ChainEvent();
            op1 = new EventOption();
            op2 = new EventOption();
            EventOption op3 = new EventOption();
            a.EventOptions = new List<EventOption>();
            a.RequiredCrews = new List<Crew>();
            a.EventID = 3;
            a.PrevEventID = 2;
            a.RequiredCrews.Add(sci);
            a.RequiredCrews.Add(sec);
            a.Label = "Fare Aşısı";
            a.Text = "Gauss faresini kullanarak bir aşı yaptığını söyledi. Eğer bunu kullanırsak hastalıklara karşı bağışıklık kazanacakmışız. Ama Sarah Gauss’a güvenmediğini ve bunu kullanmamamız gerektiğini söyleyip durdu. Aşıyı kullanalım mı?";
            op1.TargetEventID = 3;
            op1.OptionText = "Evet aşı bizi güvende tutar.";
            op1.MoodEffect = 50;
            op1.NegativeEffectCrew=sec;
            op1.PositiveEffectCrew=sci;
            a.EventOptions.Add(op1);
            op2.TargetEventID = 3;
            op2.OptionText = "Hayır bu aşıya güvenemeyiz.";
            op2.MoodEffect = 50;
            op2.NegativeEffectCrew = sci;
            op2.PositiveEffectCrew = sec;
            a.EventOptions.Add(op2);
            op3.TargetEventID = 3;
            op3.OptionText = "Aşıyı sadece Gauss kullansın.";
            op3.MoodEffect = 20;
            op3.NegativeEffectCrew = sci;
            op3.PositiveEffectCrew = sec;
            a.EventOptions.Add(op3);
            temp.Add(a);
            #endregion
            return temp;
        }
    }
}
