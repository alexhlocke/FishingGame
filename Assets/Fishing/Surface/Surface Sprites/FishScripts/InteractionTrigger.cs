using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public float interactionDistance = 3f;
    public string interactKey = "e";
    public Canvas yourCanvas;
    public GameObject player;

    void Update()
    {
        // Check if the player is nearby and pressing the interaction key
        if (IsPlayerNearby() && Input.GetKeyDown(interactKey))
        {
            // Activate the canvas
            yourCanvas.gameObject.SetActive(true);

            // Disable the Overworld Player Controller script on the player
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.enabled = false;
            }
        }
    }

    bool IsPlayerNearby()
    {
        // Check if the player is within the specified distance
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= interactionDistance;
    }
}