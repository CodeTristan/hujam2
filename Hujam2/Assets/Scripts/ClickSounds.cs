using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSounds : MonoBehaviour
{
    public AudioSource clickaudio;
    public AudioClip[] clickclips;

    public void Click()
    {
        clickaudio.pitch = Random.Range(1f, 1.3f);
        clickaudio.PlayOneShot(clickclips[Random.Range(0,3)]);
    }
}
