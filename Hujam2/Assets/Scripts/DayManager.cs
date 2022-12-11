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
    public CosmicEvent finalEvent;
    public EventOption chosenOption;

    [SerializeField] int dayCount;
    [SerializeField] GameObject crewManager;
    [SerializeField] GameObject eventLister;

    private List<CosmicEvent> repeatableEvents;
    private List<CosmicEvent> itemEvents;
    private List<CosmicEvent> chainEvents;
    private List<CosmicEvent> chainEventsBegin;
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

    private List<CosmicEvent> removeFromList(List<CosmicEvent> events, int id)
    {
        List<CosmicEvent> newList = new List<CosmicEvent>();

        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].EventID != id)
            {
                newList.Add(events[i]);
            }
        }
        return newList;
    }
    CosmicEvent ChooseEvent(int dayNumber, List<CosmicEvent> eventOptions, int type)
    {
      CosmicEvent chosenEvent;
      Debug.Log("Fonksyon çalıştı ve 0. indexte şu var: " + eventOptions[0].Label);

      if(eventOptions.Count > 1)
      {
        chosenEvent = eventOptions[Random.Range(1, eventOptions.Count)];

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
              Debug.Log("Character dead");
                        eventOptions = removeFromList(eventOptions, chosenEvent.EventID);
                        //eventOptions.Remove(chosenEvent);
              return ChooseEvent(dayNumber, eventOptions, type);
            }
          }
        }

        if (chosenEvent.RequiredDay > dayNumber) //If required day time doesnt satisfy
        {
          Debug.Log("Required day not met");
                eventOptions = removeFromList(eventOptions, chosenEvent.EventID);
                //eventOptions.Remove(chosenEvent);//Remove event from given list
          return ChooseEvent(dayNumber, eventOptions, type); //Call fucntion again
        }

        else
        {
          switch(type)
          {
            case 0:
              break;
            case 1:
              Debug.Log("Before removal "+itemEvents.Count);
                        itemEvents = removeFromList(itemEvents, chosenEvent.EventID);
                        //itemEvents.Remove(chosenEvent);
              Debug.Log("After removal "+itemEvents.Count);
              break;
            case 2:
                        chainEventsBegin = removeFromList(chainEventsBegin, chosenEvent.EventID);
                        //chainEventsBegin.Remove(chosenEvent);
              break;
                    default: Debug.Log("Remove Switch girdi ama case bulamadı"); break;
          }

          return chosenEvent;
        }
      }
      else
      {
            Debug.Log("There is no more events in this category");
            Debug.Log(eventOptions[0].Label + " Bu event yok olmalı");
        chosenEvent = eventOptions[0];
        return chosenEvent;
      }
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
        itemEvents = eventLister.GetComponent<AllItemEvents>().getAllItemEvents();
        chainEvents = eventLister.GetComponent<AllChainEvents>().getAllChainEvents();

        chainEventsBegin = new List<CosmicEvent>();
        foreach(CosmicEvent add in chainEvents)
        {
          if(add.PrevEventID == 0)
            chainEventsBegin.Add(add);
        }

        dayCount = 1;
        oldDayCount = 1;
        habitableChance = 0;

        timeTillPlanet = Random.Range(8, 11);//Random assignment for planet arrivel for begining

        GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Day: " + dayCount.ToString(); //Displayes day counter
        canShowEvent = true;
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

        if(chainEvent == true)
        {
          Debug.Log("next event goes here");
          foreach(CosmicEvent test in chainEvents)
          {
            if(test.EventID == nextEventID && test.isChainTriggered)
              finalEvent = test;
          }

          chainEvent = false;
        }
        else
        {
          while(true)
          {
            chainEvent = false;
            nextEventID = 0;

            finalEvent = new CosmicEvent();

            switch(Random.Range(0,3))
            {
              case 0: //Repetable events
                finalEvent = ChooseEvent(dayCount, repeatableEvents, 0);
                Debug.Log(finalEvent.Label+" Case 0");
                break;

              case 1: //Item events
                finalEvent = ChooseEvent(dayCount, itemEvents, 1);
                Debug.Log(finalEvent.Label+" Case 1");
                break;

              case 2: //Chain events
                chainEvent = true;
                finalEvent = ChooseEvent(dayCount, chainEventsBegin, 2);
                            Debug.Log(chainEventsBegin.Count + " CASE 2: chaineventCount");
                Debug.Log(finalEvent.Label+" Case 2");
                if(finalEvent.Label != "This event for control indexing")
                  nextEventID = finalEvent.NextEventID;
                break;
            }

            if(finalEvent.Label != "This event for control indexing")
            {
              break;
              Debug.Log("Returned null");
            }
          }
        }
      }
  }
}
