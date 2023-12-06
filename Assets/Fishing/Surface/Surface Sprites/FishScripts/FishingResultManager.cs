using UnityEngine;

public class FishingResultManager : MonoBehaviour
{
    [SerializeField] public HealthHUD healthHUD;
    [SerializeField] public PlayerStatsManager playerStatsManager;
    [SerializeField] public FightManager fightManager;
    [SerializeField] public FishManager fishM;
    
    void Start()
    {
        Debug.Log("CHECKING STATES");
        // Make sure all required components are assigned
        if (healthHUD == null || playerStatsManager == null || fightManager == null)
        {
            Debug.LogError("Missing references in GameOutcomeHandler. Please assign all required components.");
        }
        Debug.Log("We're Starting");
        
        if (fishM == null)
        {
            Debug.LogError("FishM is not assigned in the Unity Editor.");
            return;
        }

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
        playerStatsManager.IncreaseWins();
        
        fishM.CollectFish();
        
        fightManager.SetFightState(FightManager.FightState.Neutral);
    }

    // Call this method when the player loses
    public void HandleLoss()
    {
        // Add logic for handling a loss
        Debug.Log("Handling Loss!");
        
        playerStatsManager.IncreaseLosses();
        healthHUD.ChangeHealth(-1);

        fightManager.SetFightState(FightManager.FightState.Neutral);
    }
}
