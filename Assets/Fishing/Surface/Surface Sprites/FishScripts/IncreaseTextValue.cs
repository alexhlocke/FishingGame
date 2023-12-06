using UnityEngine;
using TMPro;

public class IncreaseTextValue : MonoBehaviour
{
    public TextMeshProUGUI textToIncrease;
    private int currentValue = 0;

    void Start()
    {
        // Ensure the textToIncrease variable is assigned
        if (textToIncrease == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned in IncreaseTextValue script!");
        }
        else
        {
            // Initialize the text value
            UpdateTextValue();
        }
    }

    void Update()
    {
        // Check for the "M" key press
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Increase the value by 15
            currentValue += 15;

            // Update the text value
            UpdateTextValue();
        }
    }

    void UpdateTextValue()
    {
        // Update the TextMeshProUGUI component with the new value
        textToIncrease.text = currentValue.ToString();
    }
}