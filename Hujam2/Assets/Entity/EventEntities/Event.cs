using Assets.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public int EventID{ get; set; }
    public string Label{ get; set; }
    public string Text{ get; set; }
    public int RequiredDay{ get; set; }
    public int MyProperty { get; set; }
    public EventOption[] Options{ get; set; }
    

}
