using UnityEngine;

public class FightManager : MonoBehaviour
{
    public enum FightState
    {
        Neutral,
        Win,
        Loss
    }

    public static FightManager instance;
    public static FightState currentFightState = FightState.Neutral;

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Set the fight state (win, loss, or neutral)
    public void SetFightState(FightState newState)
    {
        currentFightState = newState;
    }

    // Get the current fight state
    public FightState GetFightState()
    {
        return currentFightState;
    }

    // Set the fight state back to neutral
    public void SetToNeutral()
    {
        SetFightState(FightState.Neutral);
    }
}