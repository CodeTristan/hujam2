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
    public void Close() //BURAYA IF PLANETEVENT MÝ DÝYE BÝR ÞEY EKLENECEK. Eðer planet event olduysa kapattýktan sonra yeni bir event seçecek.
    {
        eventpanel.SetActive(false);
    }
}
