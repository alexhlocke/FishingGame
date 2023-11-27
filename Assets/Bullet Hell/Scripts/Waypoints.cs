using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    private int current = 0;
    public float speed;
    float WPradius = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current = Random.Range(0, waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position,
            Time.deltaTime * speed);
    }
}
