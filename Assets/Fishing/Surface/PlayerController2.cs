using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 input;
    private Rigidbody2D rb;

    //private animator animator;


    public LayerMask interactableLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Interact()
    {
        /*Vector3 facingDir = new Vector3(input.x, input.y, 0f).normalized;
        Vector3 interactPos = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>().Interact();
        }*/
    }
    private void Move()
    {
        Vector2 velocity = input.normalized * moveSpeed;
        rb.velocity = velocity;
    }
}