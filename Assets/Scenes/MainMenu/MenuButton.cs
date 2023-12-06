using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void StartGame()
    {
        // Load the "Fishing scene"
        SceneManager.LoadScene("FishingScene");
    }
}