using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.takeDamage(1);
        }

        if (collision.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            playerComponent.takeDamage(3);
        }
        Destroy(gameObject);
    }
}
