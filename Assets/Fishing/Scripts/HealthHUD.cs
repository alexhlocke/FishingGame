using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Image healthImage; // Reference to the Image component for health display
    [FormerlySerializedAs("fullHealthSprite")] public Sprite HealthSpriteFull; // Sprite for full health
    [FormerlySerializedAs("halfHealthSprite")] public Sprite HealthSpriteDmg1; // Sprite for half health
    [FormerlySerializedAs("lowHealthSprite")] public Sprite HealthSpriteDmg2; // Sprite for low health
    public Sprite HealthSpriteOverheal; //Sprite for upgraded Health
    public static float maxHealth = 3f; // Set your maximum health value here
    public static float currentHealth = 3f;
    public DayManager DayHandler;
    
    // Call this method whenever health changessd
    private void Awake()
    {
        UpdateHealthUI();
    }

    public void ChangeHealth(float newHealth)
    {
        // Ensure health doesn't go below 0 or exceed maxHealth
        currentHealth += newHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Debug.Log("Health is " + currentHealth);
        Debug.Log("MaxHealth is " + maxHealth);
        UpdateHealthUI();
    }

    public void setMaxHealth(int newMax)
    {
        maxHealth = newMax;
        UpdateHealthUI();
    }

    // Update the health image based on the health num
    private void UpdateHealthUI()
    {
        switch (currentHealth)
        {
            case >= 4:
                healthImage.sprite = HealthSpriteOverheal; // Bonus health
                break;
            case >= 3:
                healthImage.sprite = HealthSpriteFull; // Full health
                break;
            case >= 2:
                healthImage.sprite = HealthSpriteDmg1; // 2/3rds health
                break;
            case >= 1:
                healthImage.sprite = HealthSpriteDmg2; // Low health
                break;
            default:
                //Player is Dead
                DayHandler.EndDay();
                ChangeHealth(maxHealth);
                break;
        }
    }
}
