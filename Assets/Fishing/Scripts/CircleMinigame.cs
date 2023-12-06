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
    [Header("Audio")]
    public AudioClip SpaceSound;
    public AudioClip LastSpaceSound;
    //public AudioClip SucceedSound;
    public AudioClip FailSound;

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
            if (step == 1) {
                Debug.Log(Circle1.transform.rotation.eulerAngles.z);
                if (Circle1.transform.rotation.eulerAngles.z > 20 && Circle1.transform.rotation.eulerAngles.z < 340) {
                    FailMinigame();
                } else {
                    AudioManager.instance.PlaySound(SpaceSound,100f);
                }
            } else if (step == 2) {
                Debug.Log(Circle2.transform.rotation.eulerAngles.z);
                if (Circle2.transform.rotation.eulerAngles.z > 20 && Circle2.transform.rotation.eulerAngles.z < 340) {
                    FailMinigame();
                } else {
                    AudioManager.instance.PlaySound(SpaceSound,100f);
                }
            } else if (step == 3) {
                Debug.Log(Circle3.transform.rotation.eulerAngles.z);
                if (Circle3.transform.rotation.eulerAngles.z > 20 && Circle3.transform.rotation.eulerAngles.z < 340) {
                    FailMinigame();
                } else {
                    AudioManager.instance.PlaySound(LastSpaceSound,100f);
                    //Go to fishing scene
                }
            }   
            
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

            if(timer <= 0) {
                FailMinigame();
            }
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

    private void FailMinigame() {
        //play fuck up noise or something
        AudioManager.instance.PlaySound(FailSound,100f);

        EndMinigame();
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
