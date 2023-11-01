using UnityEngine;

[System.Serializable]
public class Fish
{
    public string name;
    public float sizeMin;
    public float sizeMax;
}

public class FishStats : MonoBehaviour
{
    public Fish[] fishArray = new Fish[5];

    public Fish GenerateRandomFish()
    {
        if (fishArray.Length == 0)
        {
            Debug.LogError("No fish data available. Please define fish data in the inspector.");
            return null;
        }

        int randomFishIndex = Random.Range(0, fishArray.Length);
        Fish randomFish = fishArray[randomFishIndex];

        float randomSize = Random.Range(randomFish.sizeMin, randomFish.sizeMax);

        Debug.Log("You caught a " + randomFish.name + " with a size of " + randomSize + " cm!");

        return randomFish;
    }
}