using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField] DialogText[] dialogTexts;
    [SerializeField] DialogText repeatableDialog;
    [SerializeField] DialogController dialogController;
    [SerializeField] Sprite closeupSprite;
    [SerializeField] string npcName;

    private void Start()
    {
        foreach (var text in dialogTexts)
        {
            text.completed = false;
        }
    }

    public override void Interact()
    {
        Talk();
    }

    public void Talk()
    {
        DialogText dialog = dialogTexts.FirstOrDefault(d => d.completed == false);
        if (dialog == null)
        {
            dialog = repeatableDialog;
        }
        if (dialog == null) return;
        dialogController.NextParagraph(dialog, closeupSprite, npcName);
    }
}