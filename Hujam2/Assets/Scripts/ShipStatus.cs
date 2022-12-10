using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatus : MonoBehaviour
{
    public float[] stats; //food, water, fuel, hull integrity

    [SerializeField]
    public GameObject[] Sliders;
    public GameObject StatPannel;
    public GameObject CrewManager;
    public Image[] SliderFill;
    public Gradient SliderGradient;

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


      for(int i = 0; i < Sliders.Length; i++)
      {
        if(i <= 3)
          Sliders[i].GetComponent<Slider>().value = stats[i]/100;
        else
          Sliders[i].GetComponent<Slider>().value = CrewManager.transform.GetChild(i-4).GetComponent<Crew>().Mood/100;
      }

      for(int i = 0; i < Sliders.Length; i++)
        SliderFill[i].color = SliderGradient.Evaluate(Sliders[i].GetComponent<Slider>().value);
    }
}
