using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity
{
   public class Scientist: Crew, IMood
    {
        void Awake()
        {
            this.Image = gameObject.GetComponent<SpriteRenderer>().sprite;
            this.Name = "Maul";
            this.RoleName = "Scientist";
            this.Mood = 100;
        }
        public void ChangeMood(int moodValue)
        {
            this.Mood += moodValue;
        }
    }
}
