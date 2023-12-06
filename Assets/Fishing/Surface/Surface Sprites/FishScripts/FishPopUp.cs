using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FishPopup : MonoBehaviour
{
    public Sprite defaultFishSprite;  // Assign a default sprite in the inspector
    public Image fishImage;  // Reference to the Image component
    public TextMeshProUGUI fishNameText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI valueText;
    public Canvas fishCanvas;

    public void ShowPopup(string fishName, float size, int value, Sprite newfishImage)
    {
        Debug.Log("Showing PopUp");
        SetFishData(fishName, size, value, newfishImage);

        fishCanvas.enabled = true;

        StartCoroutine(HideCanvasAfterDelay(3f)); // Adjust the delay as needed
    }

    void SetFishData(string fishName, float size, int value, Sprite newfishImage)
    {
        if (newfishImage == null)
        {
            fishImage.sprite = defaultFishSprite;  
        }
        else
        {
            fishImage.sprite = newfishImage;
        }

        fishNameText.text = "Name: " + fishName;
        sizeText.text = "Size: " + size.ToString("F2");
        valueText.text = "Value: $" + value.ToString();
    }

    System.Collections.IEnumerator HideCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        fishCanvas.enabled = false;

    }
}