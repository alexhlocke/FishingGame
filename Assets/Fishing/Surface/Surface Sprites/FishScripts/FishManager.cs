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

    public Fish GetRandomFish()
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
}