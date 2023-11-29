using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLogic : MonoBehaviour
{
    [Header("References")]
    public GameObject FishingPanel;
    [Space(10)]
    public GameObject Circle1;
    public GameObject Circle2;
    public GameObject Circle3;
    [Space(10)]
    public GameObject Indicator1;
    public GameObject Indicator2;
    public GameObject Indicator3;


    void Start() {
        HideFishingPanel();
    }

    public void HideFishingPanel() {
        FishingPanel.SetActive(false);
    }

    public void InitFishing() {
        FishingPanel.SetActive(true);

        Circle1.SetActive(true);
        Circle2.SetActive(false);
        Circle3.SetActive(false);

        Indicator1.SetActive(true);
        Indicator2.SetActive(true);
        Indicator3.SetActive(true);
    }
}
