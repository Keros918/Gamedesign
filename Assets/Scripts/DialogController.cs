using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] private Image npcSpriteContainer;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private TextMeshProUGUI nameContainer;
    [SerializeField] private float typeSpeed = 0.5f;
    [SerializeField] private PlayerMovementController playerMovement;
    [SerializeField] private Inventory inventory;
    private Queue<DialogNode> dialogNodes = new();
    private DialogNode dialogNode;
    private bool conversationEnded = false;
    private bool isTyping;
    private Coroutine typeEffectCoroutine;

    public void NextParagraph(DialogList dialogList)
    {
        if (dialogNodes.Count == 0)
        {
            if (!conversationEnded)
            {
                StartConversation(dialogList);
            }
            else if (conversationEnded && !isTyping)
            {
                EndConversation(dialogList);
                return;
            }
        }

        if (!isTyping)
        {
            dialogNode = dialogNodes.Dequeue();
            npcSpriteContainer.sprite = dialogNode.speakerSprite;
            nameContainer.text = dialogNode.speakerName;
            typeEffectCoroutine = StartCoroutine(TypeDialog(dialogNode));
        }
        else
        {
            SkipTyping();
        }

        if (dialogNodes.Count == 0)
        {
            conversationEnded = true;
        }
    }

    private void StartConversation(DialogList dialogList)
    {
        playerMovement.playerControls.World.Move.Disable();
        gameObject.SetActive(true);
        foreach (var p in dialogList.paragraphs)
        {
            dialogNodes.Enqueue(p);
        }
    }

    private void EndConversation(DialogList dialogList)
    {
        playerMovement.playerControls.World.Move.Enable();
        dialogNodes.Clear();
        conversationEnded = false;
        gameObject.SetActive(false);
        dialogList.completed = true;
        if (dialogList.unlockOnCompletion)
        {
            dialogList.unlockOnCompletion.unlocked = true;
        }
        if (dialogList.unlockLaserSword)
        {
            inventory.UnlockLaserSword();
            playerMovement.playerControls.World.Action1.Enable();
        }
        if (dialogList.unlockLantern)
        {
            inventory.UnlockLantern();
            playerMovement.playerControls.World.Action2.Enable();
        }
    }

    private IEnumerator TypeDialog(DialogNode p)
    {
        isTyping = true;
        int maxVisibleChars = 0;

        textBox.maxVisibleCharacters = maxVisibleChars;
        textBox.text = p.text;

        foreach (var c in p.text.ToCharArray())
        {
            maxVisibleChars++;
            textBox.maxVisibleCharacters = maxVisibleChars;

            yield return new WaitForSeconds(1 / typeSpeed);
        }

        isTyping = false;
    }

    private void SkipTyping()
    {
        StopCoroutine(typeEffectCoroutine);
        textBox.maxVisibleCharacters = dialogNode.text.Length;
        isTyping = false;
    }
}