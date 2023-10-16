using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTest : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;

    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            AudioManager.instance.PlaySound(sound1,100);
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            AudioManager.instance.PlaySoundLoop(sound2,100);
        }
    }
}
