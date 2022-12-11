using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPanel : MonoBehaviour
{
    [SerializeField] GameObject eventpanel;
    public void EventPanelOn()
    {
        eventpanel.SetActive(true);
    }
    public void Close() //BURAYA IF PLANETEVENT MÝ DÝYE BÝR ÞEY EKLENECEK
    {
        eventpanel.SetActive(false);
    }
}
