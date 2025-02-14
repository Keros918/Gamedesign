using UnityEngine;

public class PfandAutomat : Interactable
{
    [SerializeField] private Inventory inventory;
    public override void Interact()
    {
        inventory.TradePfand(1, 1);
    }

    public override bool InteractChecks()
    {
        return Inventory.Pfand > 0;
    }
}