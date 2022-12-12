using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    OptionsSave save;
    public Pause pause;
    public Slider soundoption;
    public Slider musicoption;
    public AudioSource[] audiosources;
    public AudioSource musicsource;
    public GameObject optionsmenu;

    private void Start()
    {
        save = GameObject.Find("OptionsSave").GetComponent<OptionsSave>();
        musicoption.value = save.music;
        soundoption.value=save.volume;
        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].volume = save.volume;
        }
        musicsource.volume = save.music;
    }
    public void SaveOptions()
    {
        save.volume = soundoption.value;
        save.music = musicoption.value;
        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].volume = soundoption.value;
        }
        musicsource.volume = musicoption.value * pause.musicmultiplier;
    }

    public void Close()
    {
        soundoption.value = save.volume;
        musicoption.value = save.music;
        optionsmenu.SetActive(false);
    }

}
