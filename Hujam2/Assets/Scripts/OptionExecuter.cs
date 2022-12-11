using Assets.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class OptionExecuter : MonoBehaviour
    {
        public void ExecuteOption(EventOption option, Event control)
        {
            float moodEffect = option.MoodEffect;
            if (IdChecker(option, control))
            {
                Debug.Log("---option id equals event id :CHECKED");
                if (NegativeCrewChecker(option))
                {
                    Debug.Log("---NegativeCrew :CHECKED");
                    option.NegativeEffectCrew.ChangeMood(-moodEffect);
                }
                Debug.Log("---NegativeCrew :NULL");
                if (PositiveCrewChecker(option))
                {
                    Debug.Log("---PositiveCrew :CHECKED");
                    option.PositiveEffectCrew.ChangeMood(moodEffect);
                }
                Debug.Log("---PositiveCrew :NULL");
                if (GetItemChecker(option))
                {
                    Debug.Log("---GetItem :CHECKED");
                    option.GetItem.ItemCount++;
                }
                Debug.Log("---GetItem :Null");
                if (UseItemChecker(option))
                {
                    Debug.Log("---UseItem :CHECKED");
                    option.UseItem.ItemCount--;
                }
                    Debug.Log("---UseItem :NULL");
                if (StatChecker(control))
                {
                    Debug.Log("---EffectedStat :CHECKED");
                    control.EffectedStat.StatValue+=option.StatEffect;
                }
                    Debug.Log("---EffectedStat :NULL");

            }
            Debug.Log("---option id equals event id :FAILED");
        }
        public bool IdChecker(EventOption option, Event control)
        {
            return option.TargetEventID == control.EventID;
        }
        public bool GetItemChecker(EventOption option)
        {
            return option.GetItem != null;
        }
        public bool UseItemChecker(EventOption option)
        {
            return option.UseItem != null;
        }
        public bool NegativeCrewChecker(EventOption option)
        {
            return option.NegativeEffectCrew != null;
        }
        public bool PositiveCrewChecker(EventOption option)
        {
            return option.PositiveEffectCrew != null;

        }
        public bool StatChecker(Event control)
        {
            return control.EffectedStat != null;
        }
    }
}
