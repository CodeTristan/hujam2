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
    public Event chosenEvent;
    public EventOption chosenOption;

    [SerializeField] int dayCount;
    [SerializeField] GameObject crewManager;
    [SerializeField] GameObject eventLister;

    private List<Event> repeatableEvents;
    private List<Event> itemEvents;
    private List<Event> chainEvents;
    private List<Event> chainEventsB;
    private List<ChainEvent> chainEventsA;
    private List<ChainEvent> chainEventsAB;
    private OptionExecuter optionExecuter;
    int oldDayCount;
    int timeTillPlanet;
    int habitableChance;
    int chanceMod;
    int nextEventID;
    bool chainEvent;
    bool canShowEvent;

    public void EndDay() //End of day button handling
    {
        dayCount++;
        timeTillPlanet--;

        //optionExecuter.ExecuteOption(chosenOption, chosenEvent); //Check if there is a bug

        this.GetComponent<ShipStatus>().ShipStats[0].StatValue += this.GetComponent<ShipStatus>().ShipStats[4].StatValue;
        this.GetComponent<ShipStatus>().ShipStats[1].StatValue += this.GetComponent<ShipStatus>().ShipStats[5].StatValue;
        this.GetComponent<ShipStatus>().ShipStats[2].StatValue += this.GetComponent<ShipStatus>().ShipStats[6].StatValue;

        GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Day: " + dayCount.ToString();
    }

    Event ChooseEvent(int dayNumber, List<Event> eventOptions, int type)
    {
      Event chosenEvent = eventOptions[Random.Range(1, eventOptions.Count)];

      if(eventOptions.Count > 1)
      {
        if (chosenEvent.RequiredCrews != null) //If event requires crew check if crew is alive
        {
          foreach (Crew tested in chosenEvent.RequiredCrews)
          {
            try
            {
              if(GameObject.FindGameObjectsWithTag(tested.RoleName)[0] == null);
            }
            catch
            {
              eventOptions.Remove(chosenEvent);
              return ChooseEvent(dayNumber, eventOptions, type);
            }
          }
        }

        if (chosenEvent.RequiredDay > dayNumber) //If required day time doesnt satisfy
        {
          eventOptions.Remove(chosenEvent);//Remove event from given list
          return ChooseEvent(dayNumber, eventOptions, type); //Call fucntion again
        }

        else
        {
          switch(type)
          {
            case 0:
              break;
            case 1:
              itemEvents.Remove(chosenEvent);
              break;
            case 2:
              chainEventsB.Remove(chosenEvent);
              break;
          }

          return chosenEvent; //If every requirement is satisfied return event as Event
        }
      }
      else
        return null;
    }

    Planet GenPlanet() //Generate random planet
    {
        Planet planet = new Planet();

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

        return planet;
    }

    void Start()
    {
        repeatableEvents = eventLister.GetComponent<AllRepeatableEvents>().getAllRepeatableEvents();

        itemEvents = new List<Event>();
        foreach(Event add in eventLister.GetComponent<AllItemEvents>().getAllItemEvents())
          itemEvents.Add(add);

        chainEvents = new List<Event>();
        chainEventsB = new List<Event>();
        chainEventsA = eventLister.GetComponent<AllChainEvents>().getAllChainEvents();
        chainEventsAB = new List<ChainEvent>();
        foreach(ChainEvent test in chainEventsA)
        {
          if(test.PrevEventID == 0)
            chainEventsAB.Add(test);
        }
        foreach(Event add in chainEventsAB)
          chainEventsB.Add(add);
        foreach(Event add in chainEventsA)
          chainEvents.Add(add);

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
        GenPlanet();

        //Planet Search events

        timeTillPlanet = Random.Range(5, 11);
      }

      if (canShowEvent)
      {
        canShowEvent = false;

        if(chainEvent == true && chainEvents[nextEventID].isChainTriggered)
        {
          chosenEvent = chainEvents[nextEventID];
        }
        else
        {
          chainEvent = false;
          nextEventID = 0;

          switch(Random.Range(0,3))
          {
            case 0: //Repetable events
              chosenEvent = ChooseEvent(dayCount, repeatableEvents, 0);
              break;

            case 1: //Item events
              chosenEvent = ChooseEvent(dayCount, itemEvents, 1);
              break;

            case 2: //Chain events
              chainEvent = true;
              chosenEvent = ChooseEvent(dayCount, chainEventsB, 2);
              nextEventID = chainEventsA[chosenEvent.EventID].NextEventID;
              break;
          }
        }
      }
  }
}
