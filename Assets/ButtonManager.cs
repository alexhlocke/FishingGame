using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Toggle catchButton;
    public Toggle button3Fish;
    public Toggle button5Fish;

    void Start()
    {
        // Subscribe to the events to be notified when wins or topCatch are updated
        PlayerStatsManager.OnWinsUpdated += HandleWinsUpdated;
        PlayerStatsManager.OnTopCatchUpdated += HandleTopCatchUpdated;
    }

    void HandleWinsUpdated(int wins)
    {
        button3Fish.interactable = wins >= 1;
        button5Fish.interactable = wins >= 5;
    }

    void HandleTopCatchUpdated(float topCatch)
    {
        catchButton.interactable = topCatch >= 12;
    }

    void OnDestroy()
    {
        // Unsubscribe from the events when the object is destroyed
        PlayerStatsManager.OnWinsUpdated -= HandleWinsUpdated;
        PlayerStatsManager.OnTopCatchUpdated -= HandleTopCatchUpdated;
    }
}