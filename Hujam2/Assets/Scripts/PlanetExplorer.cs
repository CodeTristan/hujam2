using Assets.Entity.EventEntities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlanetExplorer : MonoBehaviour
    {
        public bool explorePlanet(Crew crew, PlanetEvent control, Planet planet)
        {
            //todo habitable and end game bitecek
            if (Random.Range(0, 100) + 1 <= 100 * planet.planetRiskLevel())
            {
                FindObjectOfType<CrewKiller>().planetKiller(crew);
                return false;
            }
            else
            {
                control.FoodStat.StatValue += planet.foodAmount;
                control.WaterStat.StatValue += planet.waterAmount;
                control.FuelStat.StatValue += planet.fuelAmount;
                return true;
            }
        }
    }
}
