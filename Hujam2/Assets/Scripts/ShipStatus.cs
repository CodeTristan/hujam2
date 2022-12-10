using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatus : MonoBehaviour
{
    public GameObject StatPannel;
    public GameObject[] Sliders;
    public Image[] SliderFill;
    public Gradient SliderGradient;

    public float food;
    public float water;
    public float fuel;
    public float hullIntegrity;

    public void StatsPannel()
    {
      Sliders[0].GetComponent<Slider>().value = food/100;
      Sliders[1].GetComponent<Slider>().value = water/100;
      Sliders[2].GetComponent<Slider>().value = fuel/100;
      Sliders[3].GetComponent<Slider>().value = hullIntegrity/100;
        for(int i = 0; i < Sliders.Length; i++)
        {
            SliderFill[i].color = SliderGradient.Evaluate(Sliders[i].GetComponent<Slider>().value);
        }
    }
}
