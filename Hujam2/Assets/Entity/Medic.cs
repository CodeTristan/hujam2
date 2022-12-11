using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity
{
    public class Medic : Crew
    {
        void Awake()
        {
            this.Image = gameObject.GetComponent<SpriteRenderer>().sprite;
            this.Name = "Caitlin";
            this.RoleName = "Medic";
            this.Mood = 100;
        }

    }
}
