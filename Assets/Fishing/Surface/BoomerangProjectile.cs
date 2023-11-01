using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 45f;
    public float despawnTime = 7f;

    private bool returning = false;
    private Vector3 initialDirection;
    private float startTime;

    private void Start()
    {
        initialDirection = transform.up;
        startTime = Time.time;
        Destroy(gameObject, despawnTime);
    }

    private void Update()
    {
        if (!returning)
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            transform.Translate(initialDirection * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (!returning)
        {
            returning = true;
        }
    }
}