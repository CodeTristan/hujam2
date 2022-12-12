using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menubuttons;
    public GameObject backbutton;
    public GameObject credits;
    public AudioSource clickaudio;
    public AudioClip[] clips;
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
    }
    public void Click()
    {
        clickaudio.pitch = Random.Range(1f, 1.3f);
        clickaudio.PlayOneShot(clips[Random.Range(0, 3)]);
    }
}
