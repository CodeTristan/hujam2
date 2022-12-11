using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public OptionsSave save;
    public Slider soundoption;
    public AudioSource[] audiosources;
    public GameObject optionsmenu;

    private void Start()
    {
        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].volume = soundoption.value;
        }
    }
    public void SaveOptions()
    {
        save.volume = soundoption.value;
        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].volume = soundoption.value;
        }
    }

    public void Close()
    {
        soundoption.value = save.volume;
        optionsmenu.SetActive(false);
    }

}
