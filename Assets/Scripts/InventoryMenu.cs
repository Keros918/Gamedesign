using UnityEngine;
using TMPro; // Ensure you have the TextMeshPro namespace

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private static TextMeshPro _MoneyCount; // Reference to the TextMeshPro for the first item
    [SerializeField] private static TextMeshPro _PfandCount; // Reference to the TextMeshPro for the second item

    
    public static void InitializeUI()
    {
        _MoneyCount = GameObject.Find("MoneyCount").GetComponent<TextMeshPro>();
        _PfandCount = GameObject.Find("PfandCount").GetComponent<TextMeshPro>();
    }
    public static void UpdateItemCounts()
    {
        // Get item counts from the inventory
        int money = Inventory.Money;
        int pfand = Inventory.Pfand;

        // Update the TextMeshPro elements
        _MoneyCount.text = "" + money;
        _PfandCount.text = "" + pfand;
    }
}
