using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Image healthImage; // Reference to the Image component for health display
    [FormerlySerializedAs("fullHealthSprite")] public Sprite HealthSpriteFull; // Sprite for full health
    [FormerlySerializedAs("halfHealthSprite")] public Sprite HealthSpriteDmg1; // Sprite for half health
    [FormerlySerializedAs("lowHealthSprite")] public Sprite HealthSpriteDmg2; // Sprite for low health
    private float maxHealth = 3f; // Set your maximum health value here
    private float currentHealth;
    public DayManager DayHandler;
    void Start()
    {
        currentHealth = maxHealth; // Initialize health to full when the game starts
        UpdateHealthUI();
    }

    // Call this method whenever health changes
    public void ChangeHealth(float newHealth)
    {
        // Ensure health doesn't go below 0 or exceed maxHealth
        currentHealth = Mathf.Clamp(newHealth, 0f, maxHealth);

        UpdateHealthUI();
    }

    // Update the health image based on the health num
    private void UpdateHealthUI()
    {
        if (currentHealth >= 3)
        {
            healthImage.sprite = HealthSpriteFull; // Full health
        }
        else if (currentHealth >= 2)
        {
            healthImage.sprite = HealthSpriteDmg1; // 2/3rds health
        }
        else if (currentHealth >= 1)
        {
            healthImage.sprite = HealthSpriteDmg2; // Low health
        }
        else
        {
            //Player is Dead
            DayHandler.EndDay();
            ChangeHealth(3); 
        }
    }
}
