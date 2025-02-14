using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Interactable
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    [SerializeField] DialogList[] dialogs;
    [SerializeField] DialogList repeatableDialog;
    [SerializeField] DialogController dialogController;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }
        foreach (var text in dialogs)
        {
            text.completed = false;
        }
    }

    public override bool InteractChecks()
    {
        return dialogs.Any(d => d.completed == false && d.unlocked == true) || (repeatableDialog != null && repeatableDialog.unlocked);
    }

    public override void Interact()
    {
        Talk();
    }

    public void Talk()
    {
        DialogList dialog = dialogs.FirstOrDefault(d => d.completed == false && d.unlocked);
        if (dialog == null && repeatableDialog.unlocked)
        {
            dialog = repeatableDialog;
        }
        if (dialog == null)
        {
            hasInteraction = false;
            return;
        }
        dialogController.NextParagraph(dialog);
    }
}