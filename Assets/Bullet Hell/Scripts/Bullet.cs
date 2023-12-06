using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect;
    public AudioClip hitEnemy;
    public AudioClip takeD;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.takeDamage(1);
            AudioManager.instance.PlaySound(hitEnemy, 100);
        }

        if (collision.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            playerComponent.takeDamage(3);
            AudioManager.instance.PlaySound(takeD, 100);
        }
        Destroy(gameObject);
    }
}
