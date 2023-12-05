using System.Collections;
using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public SceneTransitioner sceneTransitioner;
    public TextMeshProUGUI daysText; 
    public int totalDays = 3; // Total number of days
    private int currentDay = 1; // What day we're on

    private void Start()
    {
        // Ensure SceneTransitioner script is assigned
        if (sceneTransitioner == null)
        {
            Debug.LogError("SceneTransitioner is not assigned!");
            return;
        }

        // Initialize the days text
        UpdateDaysText();
    }

    // Call this method when the day changes
    public void EndDay()
    {
        StartCoroutine(TransitionToNextDay());
    }

    // Coroutine for transitioning to the next day
    private IEnumerator TransitionToNextDay()
    {
        // Fade to black
        sceneTransitioner.FadeToBlack();
        yield return new WaitForSeconds(sceneTransitioner.fadeDuration);

        // Switch to secondary camera for a few seconds
        sceneTransitioner.SwitchCamera();
        yield return new WaitForSeconds(2.0f); // Adjust the duration as needed

        // Fade back in
        sceneTransitioner.FadeIn();

        // Switch back to the main camera
        sceneTransitioner.SwitchCamera();

        // Update the current day
        currentDay++;

        // Check if all days have passed
        if (currentDay > totalDays)
        {
            Debug.Log("All days have passed.");
            // Need to input logic for the lose state here, possibly transferring the player to the main menu if needed
        }
        else
        {
            // Update the days text for the next day
            UpdateDaysText();
        }
    }

    // Update the days text
    private void UpdateDaysText()
    {
        daysText.text = "Days Left: " + (totalDays - currentDay + 1);
    }
}