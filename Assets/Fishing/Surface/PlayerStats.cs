using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int kills = 0;
    public int totalFights = 0;
    public int money = 0;
    public int maxFishTypes = 10; // Set the maximum number of fish types you want to manage.
    public GameObject[] fishCaught;

    private int fishCount = 0;

    private void Start()
    {
        // Initialize the fishCaught array with the maximum number of fish types.
        fishCaught = new GameObject[maxFishTypes];
    }

    public void AddKill()
    {
        kills++;
    }

    public void AddTotalFight()
    {
        totalFights++;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void AddFish(GameObject fishType)
    {
        fishCaught[fishCount] = fishType;
        fishCount++;
    }
}