using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Entity.EventArrays;

public class DayManager : MonoBehaviour
{
  [SerializeField]int dayCount;
  [SerializeField]GameObject crewManager;

  int oldDayCount;
  int timeTillPlanet;
  bool canShowEvent;

  private List<Event> allEvents;

  public void EndDay()
  {
    dayCount++;
    timeTillPlanet--;

    GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Day: " + dayCount.ToString();
  }

  Event ChooseEvent(int dayNumber, List<Event> eventOptions)
  {
    Event chosenEvent = eventOptions[Random.Range(0, eventOptions.Count)];

    foreach(Crew tested in chosenEvent.RequiredCrews)
    {
      if(crewManager.GetComponent(tested.RoleName) == null)
      {
        allEvents.Remove(chosenEvent);
        eventOptions.Remove(chosenEvent);
        return ChooseEvent(dayNumber, eventOptions);
      }
    }

    if(chosenEvent.RequiredDay > dayNumber)
    {
      eventOptions.Remove(chosenEvent);
      return ChooseEvent(dayNumber, eventOptions);
    }

    else
      return chosenEvent;

  }

  float GenPlanet()
  {
    Planet planet = new Planet();
    planet.toxicAtmosphere = Random.Range(0,41);
    planet.waterLevel = Random.Range(0,21);
    planet.hostileCreatures = Random.Range(0,2);

    return planet.planetRiskLevel();
  }

  private void Awake()
  {
      AllEvents EV = new AllEvents();
      allEvents = EV.getAllEvents();
  }

  void Start()
  {
    canShowEvent = true;
    dayCount = 1;
    oldDayCount = 1;

    timeTillPlanet = Random.Range(8,11);

    GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Day: " + dayCount.ToString();
  }

  void Update()
  {
    if(dayCount != oldDayCount)
    {
      canShowEvent = true;
      oldDayCount = dayCount;
    }

    if(timeTillPlanet <= 0)
    {
      //Planet Search events
      timeTillPlanet = Random.Range(5,11);
    }

    if(canShowEvent)
    {
      Debug.Log(ChooseEvent(dayCount, allEvents).EventID);
      canShowEvent = false;
    }
  }
}
