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
    public Image Dark;
    public void Play()
    {
        StartCoroutine(StartCo());
    }
    IEnumerator StartCo()
    {
        Dark.gameObject.SetActive(true);
        StartCoroutine(FadeIn(Dark,2));
        yield return new WaitForSeconds(2);
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
        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].volume = soundoption.value;
        }
        musicsource.volume = musicoption.value;
        save.volume = soundoption.value;
        save.music = musicoption.value;
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
    public void Options()
    {
        menubuttons.SetActive(false);
        optionsmenu.SetActive(true);
        backbutton.SetActive(true);
    }
    private YieldInstruction Instruction = new YieldInstruction();
    public IEnumerator FadeOut(Image image, float time)
    {//general fade out effect for images
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < time)
        {
            yield return Instruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / time);
            image.color = c;
        }
    }

    public IEnumerator FadeIn(Image image, float time)
    {//general fade in effect for images
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < time)
        {
            yield return Instruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / time);
            image.color = c;
        }
    }
}
