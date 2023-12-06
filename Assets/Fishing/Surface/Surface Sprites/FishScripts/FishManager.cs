using System;
using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
public class FishType
{
    public string name;
    public Sprite image;
    public float minSize;
    public float maxSize;
    public int baseValue;
}

public class FishManager : MonoBehaviour
{
    public List<FishType> fishTypes = new List<FishType>();
    public FishPopup fishDisplay;
    public PlayerStatsManager playerStats;

    private void OnEnable()
    {
        fishDisplay = FindObjectOfType<FishPopup>();

        if (fishDisplay == null)
        {
            Debug.LogError("FishPopup not found. Make sure it's in the scene or properly initialized.");
        }
    }

    private void Start()
    {
        fishDisplay = FindObjectOfType<FishPopup>();

        if (fishDisplay == null)
        {
            Debug.LogError("FishPopup not found. Make sure it's in the scene or properly initialized.");
        }
        DontDestroyOnLoad(gameObject);
    }

    private Fish GetRandomFish()
    {
        if (fishTypes.Count == 0)
        {
            Debug.LogError("Fish types list is empty. Please add fish types to the list.");
            return null;
        }
        FishType randomFishType = fishTypes[UnityEngine.Random.Range(0, fishTypes.Count)];
        float randomSize = UnityEngine.Random.Range(randomFishType.minSize, randomFishType.maxSize);
        int value = Mathf.RoundToInt(randomFishType.baseValue + (randomSize * 1.5f));
        return new Fish(randomFishType.image, randomSize, randomFishType.name, value);
    }

    public void CollectFish()
    {
        //This function shall get a random fish then send that fish to be displayed by the fishpopup script
        Debug.Log("Collect Fish Start");
        Fish testFish = GetRandomFish();
        if (testFish == null)
        {
            Debug.LogError("testFish is not assigned in the Unity Editor.");
            return; // Exit the method to avoid further issues
        }

        fishDisplay.ShowPopup(testFish.name, testFish.size, testFish.value, testFish.image);
        playerStats.addCatch(testFish.size);
    }
}