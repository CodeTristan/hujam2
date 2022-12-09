using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject optionsmenu;
    public GameObject pausescreen;
    public GameObject pausemenu;
    void Update()
    {
        if (Input.GetKeyDown("escape") && Time.timeScale !=0)
        {
            Time.timeScale = 0;
            pausescreen.SetActive(true);
        }
    }
    public void Continue()
    {
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
}
