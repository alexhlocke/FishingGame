using UnityEngine;
using TMPro;

public class FishPopup : MonoBehaviour
{
    public Sprite defaultFishSprite;  // Assign a default sprite in the inspector
    public SpriteRenderer fishSpriteRenderer;  // Reference to the SpriteRenderer
    public TextMeshProUGUI fishNameText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI valueText;

    void Awake()
    {
        fishSpriteRenderer = transform.Find("fishsprite").GetComponent<SpriteRenderer>();
    }

    public void ShowPopup(string fishName, float size, int value)
    {
        SetFishData(fishName, size, value);

        gameObject.SetActive(true);

        StartCoroutine(HideCanvasAfterDelay(3f)); // Adjust the delay as needed
    }

    void SetFishData(string fishName, float size, int value)
    {
        if (fishSpriteRenderer != null)
        {
            fishSpriteRenderer.sprite = defaultFishSprite;  // Change this to the actual sprite you want to use
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