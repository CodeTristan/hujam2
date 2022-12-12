using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventPanel : MonoBehaviour
{
    [SerializeField] GameObject eventpanel;
    [SerializeField] GameObject planetPanel;
    [SerializeField] GameObject planetEventPanel;

    public void planetPanelOn()
    {
        planetPanel.SetActive(true);
    }
    public void EventPanelOn()
    {
        eventpanel.SetActive(true);
    }

    public void Close() //BURAYA IF PLANETEVENT M� D�YE B�R �EY EKLENECEK. E�er planet event olduysa kapatt�ktan sonra yeni bir event se�ecek.
    {
        eventpanel.SetActive(false);
        planetEventPanel.SetActive(false);
        if(FindObjectOfType<DayManager>().gameFinished)
        {
            SceneManager.LoadScene(0);
        }
    }
}
