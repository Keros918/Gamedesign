using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Interactable
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    [SerializeField] DialogText[] dialogTexts;
    [SerializeField] DialogText repeatableDialog;
    [SerializeField] DialogController dialogController;
    [SerializeField] Sprite closeupSprite;
    [SerializeField] string npcName;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
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
        if (dialog == null)
        {
            hasInteraction = false;
            return;
        }
        dialogController.NextParagraph(dialog, closeupSprite, npcName);
    }
}