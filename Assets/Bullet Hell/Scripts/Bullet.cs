using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect;
    public AudioClip hitEnemy;
    public AudioClip takeD;
    public static int enemyDamage = 3;
    public static int playerDamage = 1;

    public void setPlayerDamager(int newDam)
    {
        playerDamage = newDam;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.takeDamage(playerDamage);
            AudioManager.instance.PlaySound(hitEnemy, 100);
        }

        if (collision.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            playerComponent.takeDamage(enemyDamage);
            AudioManager.instance.PlaySound(takeD, 100);
        }
        Destroy(gameObject);
    }
}
