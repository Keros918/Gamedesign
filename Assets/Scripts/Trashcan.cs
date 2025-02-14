using UnityEngine;

public class Trashcan : Interactable
{
    [SerializeField] private int pfandAmount = 1;

    AudioManager audioManager;

    
   
    


    public override void Interact()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (GameObject.FindGameObjectWithTag("Player").TryGetComponent<Inventory>(out var inventory))
        {
            audioManager.PlaySFX(audioManager.collect_pfand);
            inventory.CollectPfand(pfandAmount);
            pfandAmount--;
        }
        if (pfandAmount == 0)
        {
            hasInteraction = false;
            // gameObject.SetActive(false);
        }
    }
}