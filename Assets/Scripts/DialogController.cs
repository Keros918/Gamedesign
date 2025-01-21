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
    private Queue<string> paragraphs = new();
    private string p;
    private bool conversationEnded = false;
    private bool isTyping;
    private Coroutine typeEffectCoroutine;

    public void NextParagraph(DialogText dialogText, Sprite npcSprite, string name)
    {
        if (paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                StartConversation(dialogText, npcSprite, name);
            }
            else if (conversationEnded && !isTyping)
            {
                EndConversation(dialogText);
                return;
            }
        }

        if (!isTyping)
        {
            p = paragraphs.Dequeue();
            typeEffectCoroutine = StartCoroutine(TypeDialog(p));
        }
        else
        {
            SkipTyping();
        }

        if (paragraphs.Count == 0)
        {
            conversationEnded = true;
        }
    }

    private void StartConversation(DialogText dialogText, Sprite npcSprite, string name)
    {
        npcSpriteContainer.sprite = npcSprite;
        nameContainer.text = name;
        gameObject.SetActive(true);
        foreach (var p in dialogText.paragraphs)
        {
            paragraphs.Enqueue(p);
        }
    }

    private void EndConversation(DialogText dialogText)
    {
        paragraphs.Clear();
        conversationEnded = false;
        gameObject.SetActive(false);
        dialogText.completed = true;
    }

    private IEnumerator TypeDialog(string p)
    {
        isTyping = true;
        int maxVisibleChars = 0;

        textBox.maxVisibleCharacters = maxVisibleChars;
        textBox.text = p;

        foreach (var c in p.ToCharArray())
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
        textBox.maxVisibleCharacters = p.Length;
        isTyping = false;
    }
}