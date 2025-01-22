using UnityEngine;

public class VendingMachine : Interactable
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private int cost = 3;
    public override void Interact()
    {
        inventory.BuyHealingItem(cost);
    }
}