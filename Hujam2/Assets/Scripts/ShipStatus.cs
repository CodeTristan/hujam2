using Assets.Entity;
using Assets.Entity.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatus : MonoBehaviour
{
    public List<ShipStats> ShipStats;

    [SerializeField] GameObject[] Sliders;
    [SerializeField] GameObject StatPannel;
    [SerializeField] GameObject CrewManager;
    [SerializeField] Image[] SliderFill;
    [SerializeField] Gradient SliderGradient;
    [SerializeField] GameObject ItemStatLister;
    private StatAndItemLister lister;

    private void Awake()
    {
        lister = ItemStatLister.GetComponent<StatAndItemLister>();
        
    }
    void Start()
    {
        ShipStats = lister.GetallShipStats();
      CrewManager = GameObject.FindGameObjectsWithTag("Crew Manager")[0];
    }

    public void StatsPannel()
    {
      for(int i = 0; i < GameObject.FindGameObjectsWithTag("Slider").Length; i++)
        Sliders[i] = GameObject.FindGameObjectsWithTag("Slider")[i];

      for(int i = 0; i < GameObject.FindGameObjectsWithTag("Slider Fill").Length; i++)
        SliderFill[i] = GameObject.FindGameObjectsWithTag("Slider Fill")[i].GetComponent<Image>();


      for(int i = 0; i < Sliders.Length; i++)
      {
            Sliders[i].GetComponent<Slider>().maxValue = 2;
        if(i <= 3)
          Sliders[i].GetComponent<Slider>().value = ShipStats[i].StatValue/100;
        else
          Sliders[i].GetComponent<Slider>().value = CrewManager.transform.GetChild(i-4).GetComponent<Crew>().Mood/100;
      }

      for(int i = 0; i < Sliders.Length; i++)
        SliderFill[i].color = SliderGradient.Evaluate(Sliders[i].GetComponent<Slider>().value);
    }
}
