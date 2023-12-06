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
    
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
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
            SceneManager.LoadScene(1);
        }
    }
}
