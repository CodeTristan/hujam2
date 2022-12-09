using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity
{
    public class Security : Crew, IMood
    {
        void Awake()
        {
            this.Image = gameObject.GetComponent<SpriteRenderer>().sprite;
            this.Name = "Sarah";
            this.RoleName = "Security";
            this.Mood = 100;
        }
        public void ChangeMood(int moodValue)
        {
            this.Mood += moodValue;
        }
    }
}
