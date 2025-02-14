using UnityEngine;

public class Trashcan : Interactable
{
    [SerializeField] private int pfandAmount = 1;


    public override void Interact()
    {
        if (GameObject.FindGameObjectWithTag("Player").TryGetComponent<Inventory>(out var inventory))
        {
            inventory.CollectPfand(pfandAmount);
            pfandAmount--;
        }
    }

    public override bool InteractChecks()
    {
        return pfandAmount > 0;
    }
}