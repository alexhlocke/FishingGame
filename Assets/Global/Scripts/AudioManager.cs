using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource audioObject;

    //Defining as singleton
        //Call like this:
        //AudioManager.instance.PlaySound();
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void PlaySound(AudioClip audioClip, float volume) {
        //Spawn gameobject
        AudioSource audioSource = Instantiate(audioObject, Vector3.zero, Quaternion.identity);

        //Assign clip/volume
        audioSource.clip = audioClip;
        audioSource.volume = volume;

        //Play sound
        audioSource.Play();

        //Get length of clip/destroy obj
        float  clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlaySoundLoop(AudioClip audioClip, float volume) {
        //Spawn gameobject
        AudioSource audioSource = Instantiate(audioObject, Vector3.zero, Quaternion.identity);

        //Assign clip/volume
        audioSource.clip = audioClip;
        audioSource.volume = volume;

        //Loop
        audioSource.loop = true;

        //Play sound
        audioSource.Play();
    }
}
