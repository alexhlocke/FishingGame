using UnityEngine;

public class SniperProjectile : MonoBehaviour
{
    public float initialDelay = 0.5f;
    public float speed = 3f;
    public float rotationSpeed = 360f;
    public string enemyTag = "Enemy";
    public float despawnTime = 5f;

    private Transform target;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
        Invoke("SetTarget", initialDelay);
        Destroy(gameObject, despawnTime);
    }

    private void Update()
    {
        if (target == null) return;
        
        Vector3 dir = (target.position - transform.position).normalized;
        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward, dir), step);

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void SetTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        if (enemies.Length > 0)
        {
            float minDist = Mathf.Infinity;

            foreach (GameObject enemy in enemies)
            {
                float dist = Vector2.Distance(transform.position, enemy.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    target = enemy.transform;
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}