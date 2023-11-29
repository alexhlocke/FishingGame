using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OverworldPlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 1f;
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            animator.SetFloat("Speed", 1f);
        } else {
            animator.SetFloat("Speed", 0f);
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        } else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A)) {
            spriteRenderer.flipX = true;
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        } else if (Input.GetKey(KeyCode.D)) {
            spriteRenderer.flipX = false;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
