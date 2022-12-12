using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Entity
{
   public class TechSupport : Crew
    {
        void Awake()
        {
            this.Image = gameObject.GetComponent<Image>().sprite;
            this.Name = "Brian";
            this.RoleName = "TechSupport";
            this.Mood = 100;
        }
    }
}
