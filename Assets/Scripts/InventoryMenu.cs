using UnityEngine;
using TMPro; // Ensure you have the TextMeshPro namespace

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private static TMP_Text _MoneyCount; // Reference to the TextMeshPro for the first item
    [SerializeField] private static TMP_Text _PfandCount; // Reference to the TextMeshPro for the second item

    
    public static void InitializeUI(GameObject moneyCount, GameObject pfandCount)
    {
        _MoneyCount = moneyCount.GetComponent<TMP_Text>();
        _PfandCount = pfandCount.GetComponent<TMP_Text>();
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
