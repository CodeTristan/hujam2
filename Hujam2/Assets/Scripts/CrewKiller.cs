using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CrewKiller:MonoBehaviour
    {
        public void moodKiller(Crew a)
        {
            if (a.Mood <= -20 && a.gameObject.activeSelf)
            {
                a.suicideDialog.TriggerDialog();
                a.gameObject.SetActive(false);
            }
        }

        public void planetKiller(Crew a)
        {
            a.planetDieDialog.TriggerDialog();
            a.gameObject.SetActive(false);
        }
    }
}
