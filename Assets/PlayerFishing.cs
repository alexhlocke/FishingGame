using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{
    public bool Fishing = false;

    enum FishingState {
        inactive,
        casting,
        swinging,
        reeling,
        caught
    }
    private FishingState fishingState = FishingState.inactive;



    void Start() {
        Fishing = false;
        fishingState = FishingState.inactive;
    }

    void Update() {
        if (!Fishing) {
            if (Input.GetKeyDown(KeyCode.X)) {
                Fishing = true;
                fishingState = FishingState.casting;
            }
        }

        if (fishingState == FishingState.casting) {
            if (Input.GetKeyDown(KeyCode.X)) {
                //Charge cast
            }
        }

        if (fishingState == FishingState.swinging) {
            //wait
            //when done set state to reeling
        }

        if (fishingState == FishingState.reeling) {
            if (Input.GetKeyDown(KeyCode.X)) {
                //reel in
                //if reel back into player set state to inactive / Fishing=false
                //if catch fish then this scene will fuck off
            }
        }
    }
}