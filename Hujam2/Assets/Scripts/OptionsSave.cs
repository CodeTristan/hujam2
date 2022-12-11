using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSave : MonoBehaviour
{
    public float volume;
    public float music;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
