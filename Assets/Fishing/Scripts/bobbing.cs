using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbing : MonoBehaviour
{
    public Transform basePosition;
    public AnimationCurve yCurve;
    public AnimationCurve xCurve;
    public float radius;


    private float localTime = 0f;

    void Update() {
        localTime += 1/Time.deltaTime;
        if (localTime > 1) {
            localTime = 0;
        }
    }
}
