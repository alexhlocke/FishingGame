using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    private HealthHUD health;
    private int money = 0;
    public TextMeshProUGUI moneyAmount;

    void Start()
    {
        UpdateMoneyText();
    }

    // Method to increase money
    public void IncreaseMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }

    // Method to decrease money
    public void DecreaseMoney(int amount)
    {
        money -= amount;
        // Ensure money doesn't go below zero
        money = Mathf.Max(0, money);
        UpdateMoneyText();
    }

    // Method to update the money text
    private void UpdateMoneyText()
    {
        if (moneyAmount != null)
        {
            moneyAmount.text = money.ToString();
        }
    }
}
