using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    public Sprite Image{ get; set; }
    public string Name { get; set; }
    public  string RoleName { get; set; }
    public  float Mood { get; set; }
    public void ChangeMood(float moodValue)
    {
        this.Mood += moodValue;
    }

    [SerializeField] DialogTrigger[] allCharDialogs;

}
