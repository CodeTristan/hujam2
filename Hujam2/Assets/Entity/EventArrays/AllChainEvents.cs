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
        [SerializeField] GameObject ItemStatLister;
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
            lister = ItemStatLister.GetComponent<StatAndItemLister>();
            Items = new List<EventItem>();
            Stats = new List<ShipStats>();
            Items = lister.GetallItems();
            Stats = lister.GetallShipStats();
            med = MedicP.GetComponent<Medic>();
            sec = SecurityP.GetComponent<Security>();
            sci = ScientistP.GetComponent<Scientist>();
            techSup = TechSupportP.GetComponent<TechSupport>();
            techE = TechnicalEngineerP.GetComponent<TechnicalEngineer>();
        }
        private List<CosmicEvent> temp;
        public List<CosmicEvent> getAllChainEvents()
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
            a = new CosmicEvent();
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
            a = new CosmicEvent();
            op1 = new EventOption();
            op2 = new EventOption();
            a.EventOptions = new List<EventOption>();
            a.RequiredCrews = new List<Crew>();
            a.EventID = 2;
            a.PrevEventID = 1;
            a.EffectedStat = searcher.statFinder(Stats, "FoodConsump");
            a.RequiredCrews.Add(sci);
            a.RequiredCrews.Add(sec);
            a.Label = "Fare Zehirlenmesi";
            a.Text = "Bu sabah kalktığımızda Gauss çok hasta gözüküyordu. Fareyle deney yapacağım diye zehirlenmiş. Fareyi atarsak belki düzelebilir ama Gauss atmamızı istemiyor. Ne yapalım?";
            op1.TargetEventID = 2;
            op1.OptionText = "Fareyi atmalıyız Gauss hastalanmış. ";
            op1.MoodEffect = 30;
            op1.PositiveEffectCrew = sec;
            op1.NegativeEffectCrew = sci;
            op1.StatEffect = +1;
            a.EventOptions.Add(op1);
            op2.TargetEventID = 2;
            op2.OptionText = "Gauss o fareyle güzel buluşlar yapacak, atamayız.";
            op2.MoodEffect = 30;
            op2.PositiveEffectCrew = sci;
            op2.NegativeEffectCrew = sec;
            op2.ChainTrigger = false;
            a.EventOptions.Add(op2);
            temp.Add(a);
            #endregion
            #region Event2
            a = new CosmicEvent();
            op1 = new EventOption();
            op2 = new EventOption();
            a.EventOptions = new List<EventOption>();
            a.RequiredCrews = new List<Crew>();
            a.EventID = 3;
            a.NextEventID = 4;
            a.RequiredCrews.Add(techSup);
            a.RequiredCrews.Add(sec);
            a.Label = "Bu kocaman Silahlar?";
            a.Text = "Brian, Sarah’ın silahlarından irkiliyor ve ona güvenmiyor. Bu sabah tekrar bir kargaşa çıktı ve Brian silahların göz önünde olmasından aşırı rahatsız";
            op1.TargetEventID = 3;
            op1.ChainTrigger = true;
            op1.OptionText = "Silahı göz önünden kaldıralım.";
            op1.NegativeEffectCrew = sec;
            op1.PositiveEffectCrew = techSup;
            op1.MoodEffect = 30;         
            a.EventOptions.Add(op1);
            op2.TargetEventID = 3;
            op2.ChainTrigger = true;
            op2.OptionText = "Silahı hazırda bulundurmazsak dış tehditlere karşı savunmasız kalırız";
            op2.NegativeEffectCrew = techSup;
            op2.PositiveEffectCrew = sec;
            op2.MoodEffect = 30;
            a.EventOptions.Add(op2);
            temp.Add(a);
            #endregion
            #region Event2.1
            a = new CosmicEvent();
            op1 = new EventOption();
            op2 = new EventOption();
            op3 = new EventOption();
            a.EventOptions = new List<EventOption>();
            a.RequiredCrews = new List<Crew>();
            a.EffectedStat = searcher.statFinder(Stats, "Fuel");
            a.EventID = 4;
            a.PrevEventID = 3;
            a.RequiredCrews.Add(sec);
            a.EffectedStat = searcher.statFinder(Stats, "Fuel");
            a.Label = "Bir varlık";
            a.Text = "Dışarıda bir varlık bize doğru yaklaşıyor ne yapmalıyız?";
            op1.OptionText = "Sarah silahı ile ateş etsin";
            op1.TargetEventID = 4;
            op1.UseItem = searcher.ItemFinder(Items, "Gun");
            a.EventOptions.Add(op1);
            op2.OptionText = "Hiçbir şey olmamış gibi hızlıca yanından geç";
            op2.TargetEventID = 4;
            op2.StatEffect = -10;
            a.EventOptions.Add(op2);
            op3.TargetEventID = 4;
            op3.OptionText = "Gemiye girmek koşuluyla yardım teklif etti";
            op3.StatEffect = +10;
            a.EventOptions.Add(op3);

            temp.Add(a);
            #endregion
            #region Event3
            a = new CosmicEvent();
            op1 = new EventOption();
            op2 = new EventOption();            
            a.EventOptions = new List<EventOption>();
            a.RequiredCrews = new List<Crew>();
            a.EventID = 5;
            a.NextEventID = 6;
            a.RequiredCrews.Add(techE);
            a.RequiredCrews.Add(techSup);
            a.Label = "Yedek sistem belleği";
            a.Text = "Brian, Gemi çekirdeğinin olası bir tehdit durumuna karşın yedeklenmesini sağlayan bir sistem yapmak istiyor. Peter bunun gereksiz bir durum olduğunu ve bu konuda emek harcamak istemediğini söylüyor.";
            op1.ChainTrigger = true;
            op1.TargetEventID = 5;
            op1.OptionText = "Brian bu işimize yarayabilir işe koyulun.";
            op1.PositiveEffectCrew = techSup;
            op1.NegativeEffectCrew = techE;
            op1.MoodEffect = 20;
            op1.GetItem = searcher.ItemFinder(Items, "Drive");
            a.EventOptions.Add(op1);
            op2.ChainTrigger = true;
            op2.TargetEventID = 5;
            op2.OptionText = "Olduğu gibi devam edelim vakit kaybına gerek yok ";
            op2.NegativeEffectCrew = techSup;
            op2.PositiveEffectCrew = techE;
            op2.MoodEffect = 20;
            a.EventOptions.Add(op2);
            temp.Add(a);
            #endregion
            #region Event3.1
            a = new CosmicEvent();
            op1 = new EventOption();
            op2 = new EventOption();            
            a.EventOptions = new List<EventOption>();
            a.RequiredCrews = new List<Crew>();
            a.EventID = 6;
            a.PrevEventID = 5;
            a.Label="Çekirdek sorunu";
            a.Text = "Gemi çekirdeği fazla yüklenmeye başladı sistemler her an arıza verebilir. Ne yapmalıyız?";
            a.EffectedStat = searcher.statFinder(Stats, "Durability");
            a.RequiredCrews.Add(techE);
            a.RequiredCrews.Add(techSup);
            op1.TargetEventID = 6;
            op1.OptionText = "Yedek sistem belleğini aktive edin.";
            op1.UseItem = searcher.ItemFinder(Items, "Drive");
            a.EventOptions.Add(op1);
            op2.TargetEventID = 6;
            op2.NegativeEffectCrew = techE;
            op2.PositiveEffectCrew = techSup;
            op2.MoodEffect = 20;
            op2.OptionText = "Peter çekirdeği kontrol et";
            a.EventOptions.Add(op2);
            temp.Add(a);
            #endregion
            return temp;
        }
    }
}
