using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Camera secondaryCamera; // Reference to the secondary camera
    public float fadeDuration = 1.0f; // Duration of the fade effect

    private void Start()
    {
        // Ensure both cameras are initially enabled
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
    }

    // Method to fade the screen to black
    public void FadeToBlack()
    {
        StartCoroutine(FadeCamera(mainCamera, 0f));
    }

    // Method to fade the screen back in
    public void FadeIn()
    {
        StartCoroutine(FadeCamera(mainCamera, 1f));
    }

    // Coroutine for the fade effect
    private IEnumerator FadeCamera(Camera targetCamera, float targetAlpha)
    {
        float startAlpha = targetCamera.backgroundColor.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Interpolate alpha over time
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            targetCamera.backgroundColor = new Color(targetCamera.backgroundColor.r, targetCamera.backgroundColor.g, targetCamera.backgroundColor.b, newAlpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha value is set
        targetCamera.backgroundColor = new Color(targetCamera.backgroundColor.r, targetCamera.backgroundColor.g, targetCamera.backgroundColor.b, targetAlpha);
    }

    // Method to switch cameras
    public void SwitchCamera()
    {
        // Check which camera is currently active and switch to the non-active one
        if (mainCamera.enabled)
        {
            mainCamera.enabled = false;
            secondaryCamera.enabled = true;
        }
        else
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
        }
    }

    // Method to load the "Bullet Hell" scene with fade-out
    public void LoadBulletHellScene()
    {
        StartCoroutine(LoadSceneWithFade("Bullet Hell"));
    }

    // Method to load the "Fishing" scene with fade-out
    public void LoadFishingScene()
    {
        StartCoroutine(LoadSceneWithFade("FishingScene"));
    }

    // Coroutine to load a scene with fade-out
    private IEnumerator LoadSceneWithFade(string sceneName)
    {
        // Fade to black
        FadeToBlack();
        yield return new WaitForSeconds(fadeDuration);

        // Load the new scene
        SceneManager.LoadScene(sceneName);

        // Fade back in
        FadeIn();
    }
}