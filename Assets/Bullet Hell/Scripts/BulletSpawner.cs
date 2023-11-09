using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType
    {
        Straight, Spin
    }

    public GameObject bulletPrefab;
    public float bulletLife = 1f;
    public float speed = 1f;
    public Transform firePoint;
    public float bulletForce = 15f;
    public float rotation = 1f;
    

    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin)
        {
            transform.Rotate(Vector3.forward, rotation * Time.deltaTime);
            //transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        }

        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        if (bulletPrefab)
        {
            // spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            // spawnedBullet.GetComponent<EnemyShooting>().speed = speed;
            // spawnedBullet.GetComponent<EnemyShooting>().bulletLife = bulletLife;
            // spawnedBullet.transform.rotation = transform.rotation;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
