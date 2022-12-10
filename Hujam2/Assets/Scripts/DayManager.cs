using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
  [SerializeField]int dayCount;
  int oldDayCount;
  int timeTillPlanet;
  bool canShowEvent;
  int[] eventOptions;

  public void EndDay()
  {
    dayCount++;
    timeTillPlanet--;

    GameObject.FindGameObjectsWithTag("Day Display")[0].GetComponent<TextMeshProUGUI>().text = "Day: " + dayCount.ToString();
  }

  int ChooseEvent(int dayNumber)
  {
    //Event choosing goes here
    return 1;
  }

  float GenPlanet()
  {
    Planet planet = new Planet();
    planet.toxicAtmosphere = Random.Range(0,41);
    planet.waterLevel = Random.Range(0,21);
    planet.hostileCreatures = Random.Range(0,2);

    return planet.planetRiskLevel();
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
  }
}
