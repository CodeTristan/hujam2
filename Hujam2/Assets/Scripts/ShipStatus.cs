using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatus : MonoBehaviour
{
    public GameObject[] Sliders;
    public GameObject StatPannel;
    public GameObject CrewManager;
    public Image[] SliderFill;
    public Gradient SliderGradient;

    public float food;
    public float water;
    public float fuel;
    public float hullIntegrity;

    void Start()
    {
      CrewManager = GameObject.FindGameObjectsWithTag("Crew Manager")[0];
    }

    public void StatsPannel()
    {
      for(int i = 0; i < GameObject.FindGameObjectsWithTag("Slider").Length; i++)
        Sliders[i] = GameObject.FindGameObjectsWithTag("Slider")[i];

      for(int i = 0; i < GameObject.FindGameObjectsWithTag("Slider Fill").Length; i++)
        SliderFill[i] = GameObject.FindGameObjectsWithTag("Slider Fill")[i].GetComponent<Image>();

      Sliders[0].GetComponent<Slider>().value = food/100;
      Sliders[1].GetComponent<Slider>().value = water/100;
      Sliders[2].GetComponent<Slider>().value = fuel/100;
      Sliders[3].GetComponent<Slider>().value = hullIntegrity/100;

      Sliders[4].GetComponent<Slider>().value = CrewManager.transform.GetChild(0).GetComponent<Crew>().Mood/100;
      Sliders[5].GetComponent<Slider>().value = CrewManager.transform.GetChild(1).GetComponent<Crew>().Mood/100;
      Sliders[6].GetComponent<Slider>().value = CrewManager.transform.GetChild(2).GetComponent<Crew>().Mood/100;
      Sliders[7].GetComponent<Slider>().value = CrewManager.transform.GetChild(3).GetComponent<Crew>().Mood/100;
      Sliders[8].GetComponent<Slider>().value = CrewManager.transform.GetChild(4).GetComponent<Crew>().Mood/100;

        for(int i = 0; i < Sliders.Length; i++)
            SliderFill[i].color = SliderGradient.Evaluate(Sliders[i].GetComponent<Slider>().value);
    }
}
