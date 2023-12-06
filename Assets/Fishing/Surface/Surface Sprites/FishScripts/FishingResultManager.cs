using UnityEngine;

public class FishingResultManager : MonoBehaviour
{
    public HealthHUD healthHUD;
    public PlayerStatsManager playerStatsManager;
    public FightManager fightManager;
    public FishManager fishM;
    
    void Start()
    {
        // Make sure all required components are assigned
        if (healthHUD == null || playerStatsManager == null || fightManager == null)
        {
            Debug.LogError("Missing references in GameOutcomeHandler. Please assign all required components.");
        }
        Debug.Log("We're Starting");
        if (fightManager.GetFightState() == FightManager.FightState.Win)
        {
            Debug.Log("We've Won");

            HandleWin();
        }else if (fightManager.GetFightState() == FightManager.FightState.Loss)
        {
            Debug.Log("We've Lost");

            HandleLoss();
        }
        else
        {
            Debug.Log("We've Neutral");
            fightManager.SetToNeutral();
        }
    }

    // Call this method when the player wins
    public void HandleWin()
    {
        // Add logic for handling a win
        Debug.Log("Handling Win!");

        // Example: Increase player's money
        playerStatsManager.IncreaseMoney(15);
        
        fishM.CollectFish();
        
        fightManager.SetFightState(FightManager.FightState.Neutral);
    }

    // Call this method when the player loses
    public void HandleLoss()
    {
        // Add logic for handling a loss
        Debug.Log("Handling Loss!");
        
        // Example: Update health HUD
        healthHUD.ChangeHealth(-1); // Assuming 0 health for simplicity

        // Example: Set the fight manager to a loss state
        fightManager.SetFightState(FightManager.FightState.Neutral);
    }
}
