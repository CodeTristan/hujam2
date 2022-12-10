using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButonAnimation : MonoBehaviour
{
    public Animator buttonanim;
    void OnPointerEnter(PointerEventData eventData)
    {
        buttonanim.Play("Hover");
    }
    void OnPointerExit(PointerEventData eventData)
    {
        buttonanim.Play("UnHover");
    }
}
