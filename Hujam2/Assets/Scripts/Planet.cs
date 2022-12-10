using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public int toxicAtmosphere; //0-40
    public int waterLevel; //0 or 20
    public int hostileCreatures; //0-1

    public int foodAmount;
    public int waterAmount;
    public int fuelAmount;

    public bool habitable;

    public float planetRiskLevel()
    {
      return (hostileCreatures*40 + toxicAtmosphere + waterLevel)/100;
    }

}
