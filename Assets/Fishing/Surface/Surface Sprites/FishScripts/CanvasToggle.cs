using UnityEngine;

public class CanvasToggle : MonoBehaviour
{
    public Canvas canvas;

    void Update()
    {
        // Check if the "K" key is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Toggle the canvas
            if (canvas != null)
            {
                canvas.enabled = !canvas.enabled;
            }
        }
    }
}