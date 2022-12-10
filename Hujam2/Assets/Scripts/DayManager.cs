using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Entity.EventArrays;
using Assets.Entity.EventEntities;

public class DayManager : MonoBehaviour
{
    [SerializeField] int dayCount;
    [SerializeField] GameObject crewManager;
    [SerializeField] GameObject eventLister;
    List<ItemEvent> events;

    int oldDayCount;
    int timeTillPlanet;
    bool canShowEvent;

    List<Event> allEvents;

    public void EndDay() //End of day button handling
    {
        dayCount++;
        timeTillPlanet--;

        GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Day: " + dayCount.ToString();
    }

    Event ChooseEvent(int dayNumber, List<Event> eventOptions)
    {
        Event chosenEvent = eventOptions[Random.Range(0, eventOptions.Count)]; //Chose random event from given list

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

    public float GenPlanet() //Generate random planet and return risk amount
    {
        Planet planet = new Planet();
        planet.toxicAtmosphere = Random.Range(0, 41);
        planet.waterLevel = Random.Range(0, 21);
        planet.hostileCreatures = Random.Range(0, 2);

        return planet.planetRiskLevel();
    }

    void Awake()
    {
        AllEvents BEV = new AllEvents(); //Dont add up all the lists later this is for test

        events = eventLister.GetComponent<AllItemEvents>().getAllItemEvents();
        allEvents = BEV.getAllEvents();
    }

    void Start()
    {
        canShowEvent = true;
        dayCount = 1;
        oldDayCount = 1;

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
            //Planet Search events
            timeTillPlanet = Random.Range(5, 11);
        }

        if (canShowEvent)
        {
            canShowEvent = false;
            ItemEvent temp = events[0];
            float value = temp.EventOptions[0].MoodEffect;
            temp.EventOptions[0].NegativeEffectCrew.ChangeMood(value);
            temp.EventOptions[0].PositiveEffectCrew.ChangeMood(value);
            Debug.Log(temp.EventOptions[0].NegativeEffectCrew.Mood);
            Debug.Log(temp.EventOptions[0].PositiveEffectCrew.Mood);

        }
    }
}
