using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Entity
{
   public class Scientist: Crew
    {
        void Awake()
        {
            this.Image = gameObject.GetComponent<Image>().sprite;
            this.Name = "Gauss";
            this.RoleName = "Scientist";
            this.Mood = 100;
        }

    }
}
