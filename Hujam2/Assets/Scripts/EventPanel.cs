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
    public void Close() //BURAYA IF PLANETEVENT M� D�YE B�R �EY EKLENECEK
    {
        eventpanel.SetActive(false);
    }
}
