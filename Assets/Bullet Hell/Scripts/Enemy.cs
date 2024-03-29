using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private float startHealth = 150;
    private float health;
    public Image healthBar;
    public FightManager fightm;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Destroy(gameObject);
            //Time.timeScale = 0;
            fightm.SetFightState(FightManager.FightState.Win);
            SceneManager.LoadScene("FishingScene");
        }
    }
}
