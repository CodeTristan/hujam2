﻿using Assets.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class OptionExecuter
    {/// <summary>
     /// Control Validations and Executing given option.
     /// </summary>
     /// <param name="option">EventOption Object</param>
     /// <param name="control">Event Object</param>
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
                else
                    Debug.Log("---NegativeCrew :NULL");
                if (PositiveCrewChecker(option))
                {
                    Debug.Log("---PositiveCrew :CHECKED");
                    option.PositiveEffectCrew.ChangeMood(moodEffect);
                }
                else
                    Debug.Log("---PositiveCrew :NULL");
                if (GetItemChecker(option))
                {
                    if (option.GetItem.ItemCount == 0)
                    {

                        option.GetItem.ItemCount++;
                    }
                    Debug.Log("---GetItem :CHECKED");
                }
                else
                    Debug.Log("---GetItem :Null");
                if (UseItemChecker(option))
                {
                    if (option.UseItem.ItemCount == 1)
                    {
                        option.UseItem.ItemCount--;                        
                    }
                    Debug.Log("---UseItem :CHECKED");
                }
                else
                    Debug.Log("---UseItem :NULL");
                if (StatChecker(control))
                {
                    Debug.Log("---EffectedStat :CHECKED");
                    control.EffectedStat.StatValue += option.StatEffect;
                }
                else
                    Debug.Log("---EffectedStat :NULL");

                control.isChainTriggered = option.ChainTrigger;

                control.isCosmicTriggered = option.ChainTrigger;
            }
            Debug.Log("---option id equals event id :FAILED");
        }
        
        /// <summary>
        /// Validation for checking option and event id
        /// </summary>
        /// <param name="option"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool IdChecker(EventOption option, Event control)
        {
            return option.TargetEventID == control.EventID;
        }
        /// <summary>
        /// Validation for GetItem
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool GetItemChecker(EventOption option)
        {
            return option.GetItem != null;
        }/// <summary>
         /// Validation for UseItem
         /// </summary>
         /// <param name="option"></param>
         /// <returns></returns>
        public bool UseItemChecker(EventOption option)
        {
            return option.UseItem != null;
        }
        /// <summary>
        /// Validation for NegativeCrew
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool NegativeCrewChecker(EventOption option)
        {
            return option.NegativeEffectCrew != null;
        }
        /// <summary>
        /// Validation for PositiveCrew
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool PositiveCrewChecker(EventOption option)
        {
            return option.PositiveEffectCrew != null;

        }/// <summary>
         /// Validation for EffectedStat
         /// </summary>
         /// <param name="control"></param>
         /// <returns></returns>
        public bool StatChecker(Event control)
        {
            return control.EffectedStat != null;
        }
    }
}
