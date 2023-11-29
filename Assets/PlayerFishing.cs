using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{
    public bool Fishing = false;
    public CircleMinigame circleMinigame;

    private OverworldPlayerController playerController;


    void Start() {
        Fishing = false;
        playerController = GetComponent<OverworldPlayerController>();
    }

    void Update() {

    }

    public void StartFishing() {
        //play a sound
        //start coroutine
        StartCoroutine(StartFishingPanel());
    }

    private IEnumerator StartFishingPanel() {
        // Wait for 1.5 seconds
        yield return new WaitForSeconds(1.5f); 
        
        // Call the StartMinigame function
        circleMinigame.StartMinigame();
    } 
}