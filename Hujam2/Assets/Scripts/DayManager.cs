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
    public CosmicEvent LastEvent;
    public EventOption chosenOption;
    public EventOption finalOption;
    public Planet aproachingPlanet;
    public Crew PlanetSelectedCrew;
    public bool isShipOnPlanet;

    public int dayCount;
    [SerializeField] GameObject crewManager;
    [SerializeField] GameObject eventLister;
    [SerializeField] GameObject endButton;
    [SerializeField] GameObject[] planetsUI;
    [SerializeField] GameObject planetPanelButton;
    [SerializeField] GameObject ScientistP;
    [SerializeField] GameObject SecurityP;
    [SerializeField] GameObject MedicP;
    [SerializeField] GameObject TechSupportP;
    [SerializeField] GameObject TechnicalEngineerP;
    private Medic med;
    private Assets.Entity.Security sec;
    private Scientist sci;
    private TechSupport techSup;
    private TechnicalEngineer techE;

    private List<CosmicEvent> repeatableEvents;
    private List<CosmicEvent> itemEvents;
    private List<CosmicEvent> chainEvents;
    private List<PlanetEvent> planetEvents;
    private List<CosmicEvent> chainEventsBegin;
    private PlanetExplorer planetExplorer;
    private OptionExecuter optionExecuter;
    private CosmicEvent chainEventNext;
    private PlanetEvent selectedPlanetEvent;
    int oldDayCount;
    int timeTillPlanet;
    int habitableChance;
    int chanceMod;
    int nextEventID;
    int randomPlanetIndex;
    bool chainEvent;
    bool canShowEvent;

    public void EndDay() //End of day button handling
    {
        dayCount++;
        timeTillPlanet--;


        //EventOption finalOption = new EventOption();
        finalOption.TargetEventID = chosenOption.TargetEventID;
        finalOption.MoodEffect = chosenOption.MoodEffect;
        finalOption.StatEffect = chosenOption.StatEffect;
        finalOption.ChainTrigger = chosenOption.ChainTrigger;
        finalOption.CosmicTrigger = chosenOption.CosmicTrigger;
        finalOption.OptionText = chosenOption.OptionText;
        finalOption.PositiveEffectCrew = chosenOption.PositiveEffectCrew;
        finalOption.NegativeEffectCrew = chosenOption.NegativeEffectCrew;
        finalOption.GetItem = chosenOption.GetItem;
        finalOption.UseItem = chosenOption.UseItem;

        //CosmicEvent LastEvent = new CosmicEvent();
        LastEvent.EventID = finalEvent.EventID;
        LastEvent.isChainTriggered = finalEvent.isChainTriggered;
        LastEvent.isCosmicTriggered = finalEvent.isCosmicTriggered;
        //LastEvent.EffectedStat = finalEvent.EffectedStat;

        chainEventNext = optionExecuter.ExecuteOption(finalOption, LastEvent); //Check if there is a bug
        if (isShipOnPlanet)
        {
            planetExplorer.explorePlanet(PlanetSelectedCrew, selectedPlanetEvent, aproachingPlanet);
        }
        chosenOption = new EventOption();

        this.GetComponent<ShipStatus>().ShipStats[0].StatValue += this.GetComponent<ShipStatus>().ShipStats[4].StatValue;
        this.GetComponent<ShipStatus>().ShipStats[1].StatValue += this.GetComponent<ShipStatus>().ShipStats[5].StatValue;
        this.GetComponent<ShipStatus>().ShipStats[2].StatValue += this.GetComponent<ShipStatus>().ShipStats[6].StatValue;

        GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Hafta: " + dayCount.ToString();
        planetsUI[randomPlanetIndex].SetActive(false);
        planetPanelButton.SetActive(false);
        endButton.SetActive(false);
        isShipOnPlanet = false;
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

        if (eventOptions.Count > 1)
        {
            chosenEvent = eventOptions[Random.Range(1, eventOptions.Count)];

            if (chosenEvent.RequiredCrews != null) //If event requires crew check if crew is alive
            {
                foreach (Crew tested in chosenEvent.RequiredCrews)
                {
                    try
                    {
                        if (GameObject.FindGameObjectsWithTag(tested.RoleName)[0] == null) ;
                    }
                    catch
                    {
                        eventOptions = removeFromList(eventOptions, chosenEvent.EventID);
                        return ChooseEvent(dayNumber, eventOptions, type);
                    }
                }
            }

            if (chosenEvent.RequiredDay > dayNumber) //If required day time doesnt satisfy
            {
                eventOptions = removeFromList(eventOptions, chosenEvent.EventID);
                return ChooseEvent(dayNumber, eventOptions, type); //Call fucntion again
            }

            else
            {
                switch (type)
                {
                    case 0:
                        break;
                    case 1:
                        itemEvents = removeFromList(itemEvents, chosenEvent.EventID);
                        break;
                    case 2:
                        chainEventsBegin = removeFromList(chainEventsBegin, chosenEvent.EventID);
                        break;
                }

                return chosenEvent;
            }
        }
        else
        {
            chosenEvent = eventOptions[0];
            return chosenEvent;
        }
    }

    Planet GenPlanet() //Generate random planet
    {
        Planet planet = new Planet();
        PlanetSelectedCrew = new Crew();

        planet.toxicAtmosphere = Random.Range(0, 41);
        planet.waterLevel = Random.Range(0, 21);
        planet.hostileCreatures = Random.Range(0, 2);

        planet.foodAmount = Random.Range(20, 41);
        planet.waterAmount = Random.Range(planet.waterLevel, 31);
        planet.fuelAmount = Random.Range(40, 61);

        selectedPlanetEvent = planetEvents[Random.Range(0, planetEvents.Count)];

        if (Random.Range(0f, 1f) < habitableChance / 100)
            planet.habitable = true;
        else
        {
            planet.habitable = false;
            habitableChance += chanceMod;
        }

        return planet;
    }
    private void Awake()
    {
        med = MedicP.GetComponent<Medic>();
        sec = SecurityP.GetComponent<Assets.Entity.Security>();
        sci = ScientistP.GetComponent<Scientist>();
        techSup = TechSupportP.GetComponent<TechSupport>();
        techE = TechnicalEngineerP.GetComponent<TechnicalEngineer>();
    }
    void Start()
    {
        endButton.SetActive(false);
        planetExplorer = new PlanetExplorer();
        planetEvents = new List<PlanetEvent>();
        planetEvents = eventLister.GetComponent<AllPlanetEvents>().getAllPlanetEvents();
        repeatableEvents = eventLister.GetComponent<AllRepeatableEvents>().getAllRepeatableEvents();
        itemEvents = eventLister.GetComponent<AllItemEvents>().getAllItemEvents();
        chainEvents = eventLister.GetComponent<AllChainEvents>().getAllChainEvents();
        optionExecuter = new OptionExecuter();
        chainEventsBegin = new List<CosmicEvent>();
        foreach (CosmicEvent add in chainEvents)
        {
            if (add.PrevEventID == 0)
                chainEventsBegin.Add(add);
        }

        dayCount = 1;
        oldDayCount = 1;
        habitableChance = 0;

        timeTillPlanet = Random.Range(8, 11);//Random assignment for planet arrivel for begining

        GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Hafta: " + dayCount.ToString(); //Displayes day counter
        canShowEvent = true;
    }


    void Update()
    {

        if (chosenOption.OptionText == null || (planetPanelButton.activeSelf && PlanetSelectedCrew == null))
            endButton.SetActive(false);
        else
            endButton.SetActive(true);

        if (dayCount != oldDayCount) //Makes sure no 2 event is shown in one day.
        {
            canShowEvent = true;
            oldDayCount = dayCount;
        }

        if (timeTillPlanet <= 0)
        {
            randomPlanetIndex = Random.Range(0, planetsUI.Length);
            planetsUI[randomPlanetIndex].SetActive(true);
            planetPanelButton.SetActive(true);
            aproachingPlanet = GenPlanet();
            isShipOnPlanet = true;
            timeTillPlanet = Random.Range(5, 9);
        }

        if (canShowEvent)
        {
            canShowEvent = false;

            if (chainEvent == true)
            {
                Debug.Log("next event goes here");
                foreach (CosmicEvent test in chainEvents)
                {

                    Debug.Log(test.isChainTriggered);

                    if (test.EventID == nextEventID && chainEventNext.isChainTriggered)
                    {
                        chainEvent = true;
                        Debug.Log("Chain Event if 2");
                        finalEvent = test;
                        Debug.Log(finalEvent.Label);
                    }
                    else
                    {
                        chainEvent = false;
                    }
                }
            }

            if (!chainEvent)
            {
                while (true)
                {
                    chainEvent = false;
                    nextEventID = 0;

                    finalEvent = new CosmicEvent();

                    switch (Random.Range(0, 3))
                    {
                        case 0: //Repetable events
                            finalEvent = ChooseEvent(dayCount, repeatableEvents, 0);
                            break;

                        case 1: //Item events
                            finalEvent = ChooseEvent(dayCount, itemEvents, 1);
                            break;

                        case 2: //Chain events
                            chainEvent = true;
                            finalEvent = ChooseEvent(dayCount, chainEventsBegin, 2);
                            if (finalEvent.Label != "This event for control indexing")
                                nextEventID = finalEvent.NextEventID;
                            break;
                    }

                    if (finalEvent.Label != "This event for control indexing")
                    {
                        break;
                    }
                }
            }
        }
    }
}
