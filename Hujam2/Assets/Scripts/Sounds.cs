using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource clickaudio;
    public AudioClip[] clips;

    public void Sound(string voicetype)
    {
        if (voicetype=="click")
        {
            clickaudio.pitch = Random.Range(1f, 1.3f);
            clickaudio.PlayOneShot(clips[Random.Range(0, 3)]);
        }
        
    }
}
