using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPanel : MonoBehaviour
{
    [SerializeField] GameObject eventpanel;
    [SerializeField] GameObject planetPanel;

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
    }
}
