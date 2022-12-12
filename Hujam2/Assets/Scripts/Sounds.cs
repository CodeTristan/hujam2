using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource clickaudio;
    public AudioSource pageaudio;
    public AudioSource musicsource;
    public AudioClip[] clips;
    public AudioClip[] musicclips;
    AudioClip music;
    AudioClip prevmusic;

    private void Update()
    {
        if (musicsource.isPlaying==false)
        {
            Sound("music");
        }
    }

    public void Sound(string voicetype)
    {
        if (voicetype=="click")
        {
            clickaudio.pitch = Random.Range(1f, 1.3f);
            clickaudio.PlayOneShot(clips[Random.Range(0, 3)]);
        }
        else if (voicetype=="music")
        {
            music = musicclips[Random.Range(0, 2)];
            if (music!=prevmusic)
            {
                musicsource.PlayOneShot(music);
                prevmusic = music;
            }
        }
        else if (voicetype=="page")
        {
            pageaudio.Play();
        }

    }

}
