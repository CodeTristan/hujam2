using Assets.Entity.EventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Entity.EventArrays
{
    public class AllPlanetEvents : MonoBehaviour
    {
        private List<ShipStats> Stats;
        private EventEntitySearcher searcher;
        private StatAndItemLister lister;
        private PlanetEvent a;
        public void Awake()
        {
            lister = new StatAndItemLister();
            Stats = new List<ShipStats>();
            Stats = lister.allStats;
        }
        public List<PlanetEvent> temp;
        public List<PlanetEvent> getAllPlanetEvents()
        {
            //todo newlemeden atamaa olduğu için object null refference fırlatabilir
            searcher = new EventEntitySearcher();
            temp = new List<PlanetEvent>();
            a = new PlanetEvent();
            a.EventID = 0;
            a.FoodStat = new ShipStats();
            a.WaterStat = new ShipStats();
            a.FuelStat = new ShipStats();
            a.Label = "Planet Control Label";
            a = new PlanetEvent();
            a.FoodStat = new ShipStats();
            a.WaterStat = new ShipStats();
            a.FuelStat = new ShipStats();
            a.EventID = 1;           
            a.FoodStat = searcher.statFinder(Stats, "Food");
            a.FuelStat = searcher.statFinder(Stats, "Fuel");
            a.WaterStat = searcher.statFinder(Stats, "Water");
            a.Label = "Enkazlardan gemi ikmal malzemeleriyle karşılaştık";
            temp.Add(a);
            a = new PlanetEvent();
            a.FoodStat = new ShipStats();
            a.WaterStat = new ShipStats();
            a.FuelStat = new ShipStats();
            a.EventID = 2;
            a.FoodStat = searcher.statFinder(Stats, "Food");
            a.FuelStat = searcher.statFinder(Stats, "Fuel");
            a.WaterStat = searcher.statFinder(Stats, "Water");
            a.Label = "Gezegenin bazı yerlileri bize maceramızda destek oldu";
            temp.Add(a);
            a = new PlanetEvent();
            a.FoodStat = new ShipStats();
            a.WaterStat = new ShipStats();
            a.FuelStat = new ShipStats();
            a.EventID = 3;
            a.FoodStat = searcher.statFinder(Stats, "Food");
            a.FuelStat = searcher.statFinder(Stats, "Fuel");
            a.WaterStat = searcher.statFinder(Stats, "Water");
            a.Label = "Karşılaştığımız gezegende bir mola tesisine rastladık";
            temp.Add(a);
            a = new PlanetEvent();
            a.EventID = 4;
            a.FoodStat = searcher.statFinder(Stats, "Food");
            a.FuelStat = searcher.statFinder(Stats, "Fuel");
            a.WaterStat = searcher.statFinder(Stats, "Water");
            a.Label = "Gezegenin atmosferinde terk edilmiş bir gemiye rastladık";
            temp.Add(a);
            return temp;
        }
    }
}
