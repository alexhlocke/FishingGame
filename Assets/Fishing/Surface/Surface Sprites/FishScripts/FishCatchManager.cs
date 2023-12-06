using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Fish
{
    public Sprite image;
    public float size;
    public string name;
    public int value;

    public Fish(Sprite image, float size, string name, int value)
    {
        this.image = image;
        this.size = size;
        this.name = name;
        this.value = value;
    }
}
 
public class FishCatchManager : MonoBehaviour
{
    public List<Fish> fishCatches = new List<Fish>();

    // Function to add a fish to the array
    public void AddFish(Fish fish)
    {
        fishCatches.Add(fish);
        SortFishBySize();
    }
    //Get the array of fishes caught
    public List<Fish> GetFishCatches()
    {
        return fishCatches;
    }

    // Function to sort the array based on the size of the fish in descending order
    public void SortFishBySize()
    {
        fishCatches.Sort((fish1, fish2) => fish2.size.CompareTo(fish1.size));
    }
    
}