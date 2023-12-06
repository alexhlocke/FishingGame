using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public static int playerDamage;
    public static int dashingPower;
    public static int maxHealth;
    public static int bulletForce;
    public PlayerStatsManager playerStats;
    public HealthHUD health;
    public PlayerMovement playerMoves;
    public Shooting bulletSpeed;
    public Bullet dealDamage;
    
    // Function to set Player Damage
    public void SetPlayerDamage()
    {
        if (PlayerStatsManager.playerMoney >= 15)
        {
            playerStats.DecreaseMoney(15);
            dealDamage.setPlayerDamager(2);
            Debug.Log("Player Damage set to: 2");
        }
    }

    // Function to set Dashing Power
    public void SetDashingPower()
    {
        if (PlayerStatsManager.playerMoney >= 15)
        {
            maxHealth = 4;
            playerStats.DecreaseMoney(15);
            playerMoves.setDashPower(12);
            Debug.Log("Dashing Power set to: 12");
        }
    }

    // Function to set Max Health
    public void SetMaxHealth()
    {
        if (PlayerStatsManager.playerMoney >= 15)
        {
            health.setMaxHealth(4);
            Debug.Log("Max Health set to: 4");   
            playerStats.DecreaseMoney(15);
            health.ChangeHealth(4);
        }
    }

    // Function to set Bullet Force
    public void SetBulletForce()
    {
        if (PlayerStatsManager.playerMoney >= 15)
        {
            maxHealth = 4;
            playerStats.DecreaseMoney(15);
            bulletSpeed.setBulletSpeed(17);
            Debug.Log("Bullet Force set to: " + bulletForce);
        }
    }
}