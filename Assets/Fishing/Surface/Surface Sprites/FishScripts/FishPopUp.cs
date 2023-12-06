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

    void Awake()
    {
        if (fishImage.sprite == null)
        {
            fishImage.sprite = defaultFishSprite;
        }
        SetFishData("Tester", 5, 5, defaultFishSprite);
        ShowPopup("Tester", 5, 5, defaultFishSprite);
    }

    public void ShowPopup(string fishName, float size, int value, Sprite newfishImage)
    {
        SetFishData(fishName, size, value, newfishImage);

        gameObject.SetActive(true);

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

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            float fadeDuration = 1f; // Fade duration
            float startTime = Time.time;

            while (Time.time < startTime + fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, (Time.time - startTime) / fadeDuration);
                yield return null;
            }

            // Deactivate the canvas after fading
            gameObject.SetActive(false);
        }
    }
}