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
            event1.EventID = 1;
            event1.RequiredCrews = new List<Crew>();
            event1.RequiredCrews.Add(techE);
            event1.EffectedStat = searcher.statFinder(Stats,"Fuel");
            event1.Label = "Peter'ın Yakıt Sorunu";
            event1.Text = "Peter yakıtı kendi kişisel amaçları için kullanıyormuş. Tayfamız bunun problem yaratabileceğini söylüyor.";
            EventOption e1op1 = new EventOption();
            event1.EventOptions = new List<EventOption>();
            e1op1.TargetEventID = 1;
            e1op1.NegativeEffectCrew = techE;
            e1op1.MoodEffect = 20;
            e1op1.OptionText = "Hayır Peter yakıtı içemezsin ";
            event1.EventOptions.Add(e1op1);
            EventOption e1op2 = new EventOption();
            e1op2.TargetEventID = 1;
            e1op2.PositiveEffectCrew = techE;
            e1op2.MoodEffect = 20;
            e1op2.StatEffect= -5;
            e1op2.OptionText = "Dikkatli davranmaya özen gösterdiğin sürece seni rahat bırakıyorum. ";
            event1.EventOptions.Add(e1op2);
            temp.Add(event1);
            #endregion

            #region Event2
            CosmicEvent event2 = new CosmicEvent();
            event2.EventID = 2;
            event2.EffectedStat = searcher.statFinder(Stats,"Fuel");
            event2.Label = "Astreoit Denizi";
            event2.Text = "Gemimizin önünde bir asteroit denizi var! Buradan geçebilir miyiz?";
            EventOption e2op1 = new EventOption();
            event2.EventOptions = new List<EventOption>();
            e2op1.TargetEventID = 2;
            e2op1.StatEffect= -5;
            e2op1.OptionText = "Durmak yok! Bu denizi aşıyoruz.";
            event2.EventOptions.Add(e2op1);
            EventOption e2op2 = new EventOption();
            e2op2.TargetEventID = 2;
            e2op2.StatEffect= -10;
            e2op2.OptionText = "Dikkatli davranmaya özen gösterdiğin sürece seni rahat bırakıyorum. ";
            event2.EventOptions.Add(e2op2);
            temp.Add(event2);
            #endregion

            #region Event3
            CosmicEvent event3 = new CosmicEvent();
            event3.EventID = 3;
            event3.RequiredCrews = new List<Crew>();
            event3.RequiredCrews.Add(techSup);
            event3.RequiredCrews.Add(techE);
            event3.EffectedStat = searcher.statFinder(Stats,"Fuel");
            event3.Label = "Brian ve Peter'ın Yakı Kavgası";
            event3.Text = "Peter ve Brian yakıt kontrol sisteminden kaynaklı bir kavgaya tutuştular.";
            EventOption e3op1 = new EventOption();
            event3.EventOptions = new List<EventOption>();
            e3op1.TargetEventID = 3;
            e3op1.PositiveEffectCrew = techE;
            e3op1.NegativeEffectCrew = techSup;
            e3op1.MoodEffect = 20;
            e3op1.StatEffect= -5;
            e3op1.OptionText = "Brian, bu sormluluk Peter'a ait.";
            event3.EventOptions.Add(e3op1);
            EventOption e3op2 = new EventOption();
            e3op2.TargetEventID = 3;
            e3op2.PositiveEffectCrew = techSup;
            e3op2.NegativeEffectCrew = techE;
            e3op2.MoodEffect = 20;
            e3op2.OptionText = "Brian control etmekte haklı.";
            event3.EventOptions.Add(e3op2);
            temp.Add(event3);
            #endregion

            #region Event4
            CosmicEvent event4 = new CosmicEvent();
            event4.EventID = 4;
            event4.RequiredCrews = new List<Crew>();
            event4.RequiredCrews.Add(techSup);
            event4.Label = "Solucan Deliği";
            event4.Text = "Hedefimiz hesaplamalarınızda çıkandan daha da uzaktaymış, lakin ilerinizde bir solucan deliği bulunmakta. Elinizdeki verilere göre ulaşma sürenizi kısaltabilir ama Brain bunun tehlikeli olduğu konusunda ısrarcı.";
            EventOption e4op1 = new EventOption();
            event4.EventOptions = new List<EventOption>();
            e4op1.TargetEventID = 4;
            e4op1.NegativeEffectCrew = techSup;
            e4op1.MoodEffect = 20;
            e4op1.OptionText = "Solucan deliği iyi bir fırsat.";
            event4.EventOptions.Add(e4op1);
            EventOption e4op2 = new EventOption();
            e4op2.TargetEventID = 4;
            e4op2.PositiveEffectCrew = techSup;
            e4op2.MoodEffect = 20;
            e4op2.OptionText = "En ufak hesap yanlışlığı bize pahalıya patlayabilir.";
            event4.EventOptions.Add(e4op2);
            temp.Add(event4);
            #endregion

            #region Event5
            CosmicEvent event5 = new CosmicEvent();
            event5.EventID = 5;
            event5.RequiredCrews = new List<Crew>();
            event5.RequiredCrews.Add(sec);
            event5.Label = "Nefs-i Müdafa";
            event5.Text = "Sarah herkesin belli bir miktar kendini savunmayı bilmesini istiyor ama silahlar buna uygun değil. Gemide bulunan malzemelerle silahları buna uygun hale getirebileceğimizi söylüyor.";
            EventOption e5op1 = new EventOption();
            event5.EventOptions = new List<EventOption>();
            e5op1.TargetEventID = 5;
            e5op1.NegativeEffectCrew = sec;
            e5op1.MoodEffect = 20;
            e5op1.OptionText = "Elimizdekiler yeterli, gemiye zarar vermeyelim.";
            event5.EventOptions.Add(e5op1);
            EventOption e5op2 = new EventOption();
            e5op2.TargetEventID = 5;
            e5op2.PositiveEffectCrew = sec;
            e5op2.MoodEffect = 20;
            e5op2.OptionText = "Her birimizin canı oldukça değerli, bunu yapalım.";
            event5.EventOptions.Add(e5op2);
            temp.Add(event5);
            #endregion

            return temp;
        }
    }
}
