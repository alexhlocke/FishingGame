using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleMinigame : MonoBehaviour
{

    [Header("References")]
    public GameObject Circle1;
    public GameObject Circle2;
    public GameObject Circle3;
    public GameObject FishingPanel;
    public GameObject Player;
    public Slider TimeSlider;
    [Header("Important Values")]
    public float SpinRateMin;
    public float SpinRateMax;
    public float StartTime = 10f;

    private float spinRate = 1;
    private int step = 1;
    private float timer;
    private float c1angle = 0;
    private float c2angle = 0;
    private float c3angle = 0;
    private OverworldPlayerController playerController;
    private PlayerFishing playerFishing;

    
    void Start() {
        playerFishing = Player.GetComponent<PlayerFishing>();
        playerController = Player.GetComponent<OverworldPlayerController>();

        timer = StartTime;
    }

    void Update() {
        //Go to next step if space is pressed
        if (Input.GetKeyDown("space")) {
            step += 1;
            resetSpinRate();
        }

        //Spin circles
        if (step == 1) {
            Circle1.SetActive(true);

            RotateCircle(Circle1);
        } 
        else if (step == 2) {
            Circle2.SetActive(true);

            RotateCircle(Circle2);
        } 
        else if (step == 3) {
            Circle3.SetActive(true);

            RotateCircle(Circle3);
        }
        else if (step > 3) {
            EndMinigame();
        }

        //Update timer
        if (step > 0 && step < 4) {
            timer -= Time.deltaTime;
            TimeSlider.value = timer / StartTime;
        }
    }

    private void RotateCircle(GameObject circle) {
        Vector3 currentRotation = circle.transform.rotation.eulerAngles;
        float newRotation = currentRotation.z + spinRate * Time.deltaTime;
        circle.transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
    }

    [ContextMenu("Start Minigame")]
    public void StartMinigame() {
        step = 1;
        FishingPanel.SetActive(true);

        timer = StartTime;

        resetSpinRate();

        //Hide circles
        Circle1.SetActive(false);
        Circle2.SetActive(false);
        Circle3.SetActive(false);
    }

    public void EndMinigame() {
        step = 0;
        playerController.ReturnToMovement();
        FishingPanel.SetActive(false);
    }
    
    public void SetSpinRate(float min, float max) {
        SpinRateMin = min;
        SpinRateMax = max;
    }

    public void SetStartTime(float startTime) {
        StartTime = startTime;
    }

    private void resetSpinRate() {
        spinRate = Random.Range(SpinRateMin, SpinRateMax);
    }
}
