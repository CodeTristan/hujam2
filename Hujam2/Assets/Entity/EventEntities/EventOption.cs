using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity
{
    public class EventOption : MonoBehaviour
    {
        public int TargetEventID { get; set; }
        public int MoodEffect { get; set; }
        public float StatEffect { get; set; }
        public bool ChainTrigger { get; set; }
        public bool CosmicTrigger { get; set; }
        public string OptionText { get; set; }
        public Crew PositiveEffectCrew { get; set; }
        public Crew NegativeEffectCrew { get; set; }
        public EventItem GetItem { get; set; }
        public EventItem UseItem { get; set; }

    }
}
