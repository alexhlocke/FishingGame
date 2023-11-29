using TMPro;
using UnityEngine;

public class FishLister : MonoBehaviour
{
    public GameObject shopCanvas;
    public TextMeshProUGUI moneyHUD;
    public int money = 1000;

    public GameObject inventorySlotPrefab;
    public Transform inventoryGrid;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            shopCanvas.SetActive(!shopCanvas.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            AddMoney(50);
        }

        moneyHUD.text = "Money: $" + money;
    }

    public void PurchaseItem(int index)
    {
        // Your existing purchase logic...
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    void IncreaseInventorySize()
    {
        // Your existing inventory size increase logic...
    }

    // Add fish to the inventory list on the canvas
    public void AddFishToInventory(Fish fish)
    {
        GameObject newSlot = Instantiate(inventorySlotPrefab, inventoryGrid);
        //InventorySlot slotScript = newSlot.GetComponent<InventorySlot>();

        // Set the visual elements of the inventory slot with fish details
        //slotScript.SetFishDetails(fish);
    }
}