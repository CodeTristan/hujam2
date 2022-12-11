using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Entity.EventArrays;
using Assets.Entity.EventEntities;
using Assets.Entity;
using Assets.Scripts;

public class DayManager : MonoBehaviour
{
    [SerializeField] int dayCount;
    [SerializeField] GameObject crewManager;
    [SerializeField] GameObject eventLister;

    private List<ItemEvent> events;
    private List<Event> repeatableEvent;
    private List<Event> allEvents;
    private OptionExecuter optionExecuter;
    Planet planet;
    int oldDayCount;
    int timeTillPlanet;
    int habitableChance;
    int chanceMod;
    bool canShowEvent;

    public void EndDay() //End of day button handling
    {
        dayCount++;
        timeTillPlanet--;

        this.GetComponent<ShipStatus>().ShipStats[0].StatValue += this.GetComponent<ShipStatus>().ShipStats[4].StatValue; ;
        this.GetComponent<ShipStatus>().ShipStats[1].StatValue += this.GetComponent<ShipStatus>().ShipStats[5].StatValue; ;
        this.GetComponent<ShipStatus>().ShipStats[2].StatValue += this.GetComponent<ShipStatus>().ShipStats[6].StatValue; ;

        GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Day: " + dayCount.ToString();
    }

    Event ChooseEvent(int dayNumber, List<Event> eventOptions)
    {
        Event chosenEvent = eventOptions[Random.Range(1, eventOptions.Count)]; //Chose random event from given list

        if (chosenEvent.RequiredCrews != null) //If event requires crew check if crew is alive
        {
            foreach (Crew tested in chosenEvent.RequiredCrews)
            {
                if (crewManager.GetComponent(tested.RoleName) == null)
                {
                    allEvents.Remove(chosenEvent); //Remove event from original list if one or both crew members are dead
                    eventOptions.Remove(chosenEvent); //Remove event from given list for recursion
                    return ChooseEvent(dayNumber, eventOptions); //Call fucntion again
                }
            }
        }

        if (chosenEvent.RequiredDay > dayNumber) //If required day time doesnt satisfy
        {
            eventOptions.Remove(chosenEvent);//Remove event from given list
            return ChooseEvent(dayNumber, eventOptions); //Call fucntion again
        }

        else
            return chosenEvent; //If every requirement is satisfied return event as Event

    }

    /*void GenPlanet() //Generate random planet
    {
        planet = new Planet();

        planet.toxicAtmosphere = Random.Range(0, 41);
        planet.waterLevel = Random.Range(0, 21);
        planet.hostileCreatures = Random.Range(0, 2);

        planet.foodAmount = Random.Range(20,41);
        planet.waterAmount = Random.Range(planet.waterLevel, 31);
        planet.fuelAmount = Random.Range(40, 61);

        if(Random.Range(0f,1f)<habitableChance/100)
          planet.habitable = true;
        else
        {
          planet.habitable = false;
          habitableChance += chanceMod;
        }
    }*/

    void Start()
    {
        optionExecuter = new OptionExecuter();
        allEvents = new List<Event>();
        events = eventLister.GetComponent<AllItemEvents>().getAllItemEvents();
        repeatableEvent = eventLister.GetComponent<AllRepeatableEvents>().getAllRepeatableEvents();
        Debug.Log("DayManagerEventCount " + events.Count);
        canShowEvent = true;
        dayCount = 1;
        oldDayCount = 1;
        habitableChance = 0;

        timeTillPlanet = Random.Range(8, 11);//Random assignment for planet arrivel for begining

        GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Day: " + dayCount.ToString(); //Displayes day counter
    }


    void Update()
    {
        if (dayCount != oldDayCount) //Makes sure no 2 event is shown in one day.
        {
            canShowEvent = true;
            oldDayCount = dayCount;
        }

        if (timeTillPlanet <= 0)
        {
            //GenPlanet();

            //Planet Search events

            timeTillPlanet = Random.Range(5, 11);
        }

        if (canShowEvent)
        {
            canShowEvent = false;
            Event temp = repeatableEvent[1];
            EventOption selected = new EventOption();
            foreach(Event add in events)
              allEvents.Add(add);
            selected = ChooseEvent(dayCount, repeatableEvent).EventOptions[0];                       
            //selected = temp.EventOptions[0];
            optionExecuter.ExecuteOption(selected,temp);
            Debug.Log(temp.EventOptions[0].NegativeEffectCrew.Name+" ~DayManager");
            Debug.Log(temp.EventOptions[0].NegativeEffectCrew.Mood + " ~DayManager");                     
            Debug.Log(temp.EventOptions[0].ChainTrigger + " ~DayManager");
            Debug.Log(temp.isChainTriggered + " ~DayManager");
            Debug.Log(temp.RequiredDay + " ~DayManager");

        }
    }
}
