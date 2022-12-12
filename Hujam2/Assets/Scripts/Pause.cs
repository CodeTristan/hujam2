using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Options options;
    OptionsSave save;
    public GameObject optionsmenu;
    public GameObject pausescreen;
    public GameObject pausemenu;
    public float musicmultiplier;
    private void Start()
    {
        save = GameObject.Find("OptionsSave").GetComponent<OptionsSave>();
    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
                pausescreen.SetActive(true);
                musicmultiplier = 0.2f;
                options.musicsource.volume = save.music * musicmultiplier;
            }
            else
            {
                Continue();
            }
            
        }
    }
    public void Continue()
    {
        musicmultiplier = 1;
        options.musicsource.volume = save.music * musicmultiplier;
        Time.timeScale = 1;
        pausescreen.SetActive(false);
    }
    public void OptionsMenu()
    {
        optionsmenu.SetActive(true);
        pausemenu.SetActive(false);
    }
    public void Close()
    {
        pausemenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
