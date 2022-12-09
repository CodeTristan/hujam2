using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatus : MonoBehaviour
{
    public GameObject StatPannel;
    public GameObject Text;

    public float food;
    public float water;
    public float fuel;
    public float hullIntegrity;

    public void StatsPannel()
    {
      StatPannel.SetActive(true);
      Text.GetComponent<Text>().text = "Food: "+food.ToString()+"\nWater: "+water.ToString()+"\nFuel: "+fuel.ToString()+"\nHull Integrity: "+hullIntegrity.ToString();
    }

    public void ClosePannel()
    {
      StatPannel.SetActive(false);
    }
}
