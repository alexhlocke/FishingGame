using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static event Action<int> OnWinsUpdated;
    public static event Action<float> OnTopCatchUpdated;

    private HealthHUD health;
    public static int playerMoney = 0;
    public TextMeshProUGUI moneyAmount;
    private static int playerLosses = 0;
    private static int playerWins = 0;
    private static float topCatch = 0;

    void Start()
    {
        UpdateMoneyText();
    }

    private void LateUpdate()
    {
        moneyAmount.text = playerMoney.ToString();
    }

    public void addCatch(float newSize)
    {
        if (newSize > topCatch)
        {
            topCatch = newSize;

            // Notify subscribers about the updated topCatch
            OnTopCatchUpdated?.Invoke(topCatch);
        }
    }

    // Method to increase money
    public void IncreaseMoney(int amount)
    {
        playerMoney += amount;
        UpdateMoneyText();
    }

    // Method to decrease money
    public void DecreaseMoney(int amount)
    {
        playerMoney -= amount;
        // Ensure money doesn't go below zero
        playerMoney = Mathf.Max(0, playerMoney);
        UpdateMoneyText();
    }

    // Method to update the money text
    public void UpdateMoneyText()
    {
        moneyAmount.text = playerMoney.ToString();
    }

    // Method to increase the number of wins and notify subscribers
    public void IncreaseWins()
    {
        playerWins++;
        Debug.Log("Wins: " + playerWins);

        // Notify subscribers about the updated number of wins
        OnWinsUpdated?.Invoke(playerWins);
    }
    // Method to increase the number of wins and notify subscribers
    public void IncreaseLosses()
    {
        playerLosses++;
        Debug.Log("Losses: " + playerLosses);
        
    }
}
