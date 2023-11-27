using UnityEngine;

public class LockboxInteractor : MonoBehaviour
{
    public float detectionRadius = 2f;  // Radius to detect the player
    public Sprite lockboxSprite;       // The sprite to display above the lockbox
    public float spriteOffset = 1f;    // Vertical offset for the sprite

    private GameObject player;          // Reference to the player GameObject
    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer

    private void Start()
    {
        // Find the player GameObject by its tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        // Create a new GameObject for the sprite and add a SpriteRenderer component
        GameObject spriteObject = new GameObject("LockboxSprite");
        spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();

        // Set the sprite and position it above the lockbox
        spriteRenderer.sprite = lockboxSprite;
        spriteObject.transform.position = transform.position + Vector3.up * spriteOffset;

        // Ensure the sprite is initially hidden
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        // Check if the player is within the detection radius
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRadius)
        {
            // Player is within the radius, show the lockbox sprite
            spriteRenderer.enabled = true;
        }
        else
        {
            // Player is outside the radius, hide the lockbox sprite
            spriteRenderer.enabled = false;
        }
    }
}