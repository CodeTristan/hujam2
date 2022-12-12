using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsmenu;
    public GameObject menubuttons;
    public GameObject backbutton;
    public GameObject credits;
    public AudioSource clickaudio;
    public AudioClip[] clips;
    OptionsSave save;
    public Pause pause;
    public Slider soundoption;
    public Slider musicoption;
    public AudioSource[] audiosources;
    public AudioSource musicsource;
    private void Start()
    {
        save = GameObject.Find("OptionsSave").GetComponent<OptionsSave>();
        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].volume = soundoption.value;
        }
        musicsource.volume = musicoption.value;
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        menubuttons.SetActive(false);
        backbutton.SetActive(true);
        credits.SetActive(true);
    }
    public void Back()
    {
        menubuttons.SetActive(true);
        backbutton.SetActive(false);
        credits.SetActive(false);
        soundoption.value = save.volume;
        musicoption.value = save.music;
        optionsmenu.SetActive(false);
    }
    public void Click()
    {
        clickaudio.pitch = Random.Range(1f, 1.3f);
        clickaudio.PlayOneShot(clips[Random.Range(0, 3)]);
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
}
