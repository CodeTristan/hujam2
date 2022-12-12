using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Entity
{
    public class Security : Crew
    {
        void Awake()
        {
            this.Image = gameObject.GetComponent<Image>().sprite;
            this.Name = "Sarah";
            this.RoleName = "Security";
            this.Mood = 100;
        }

    }
}
