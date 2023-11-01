using UnityEngine;

public class ShotgunProjectile : MonoBehaviour
{
    public float speed = 3f;
    public float despawnTime = 1f;

    private void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}