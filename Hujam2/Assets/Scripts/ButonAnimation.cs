using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButonAnimation : MonoBehaviour
{
    Animator buttonanim;

    private void Start()
    {
        buttonanim = GetComponent<Animator>();
        Debug.Log("start");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("imepe in");
        buttonanim.Play("Hover");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonanim.Play("UnHover");
        Debug.Log("imepe out");
    }
}
