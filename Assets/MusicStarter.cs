using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    public AudioClip Music;
    public float MusicVolume = 90f;

    void Start()
    {
        AudioManager.instance.PlaySound(Music, MusicVolume);
    }
}
