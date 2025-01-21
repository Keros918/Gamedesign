using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private Image playerCloseupImage;
    [SerializeField] private Image npcCloseupImage;
    private Text dialogText;
    [SerializeField] private GameObject choicesContainer;
    [SerializeField] private Button choiceButtonPrefab;
    [SerializeField] private Sprite playerCloseupSprite;
    private Dialog currentDialog;
    private NPCDialog currentNPC;
    private int currentNodeIndex;

    public void StartDialog(NPCDialog npc)
    {
        currentNPC = npc;
        currentDialog = npc.GetDialog();
        currentNodeIndex = 0;

        // Set player and NPC closeup sprites
        playerCloseupImage.sprite = playerCloseupSprite;
        npcCloseupImage.sprite = npc.GetCloseupSprite();

        DisplayNode(currentDialog.dialogNodes[currentNodeIndex]);
    }

    private void DisplayNode(DialogNode node)
    {
        dialogText.text = node.text;

        // Clear existing choices
        foreach (Transform child in choicesContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Display choices
        if (node.choices != null && node.choices.Count > 0)
        {
            foreach (var choice in node.choices)
            {
                var button = Instantiate(choiceButtonPrefab, choicesContainer.transform);
                button.GetComponentInChildren<Text>().text = choice.text;
                button.onClick.AddListener(() => OnChoiceSelected(choice.nextNodeIndex));
            }
        }
        else if (node.isEndNode)
        {
            TriggerAction(node);
        }
    }

    private void OnChoiceSelected(int nextNodeIndex)
    {
        if (nextNodeIndex < currentDialog.dialogNodes.Count)
        {
            currentNodeIndex = nextNodeIndex;
            DisplayNode(currentDialog.dialogNodes[currentNodeIndex]);
        }
        else
        {
            EndDialog();
        }
    }

    private void EndDialog()
    {
        Debug.Log("Dialog finished.");
        currentDialog = null;

        // Hide closeups and reset UI
        playerCloseupImage.gameObject.SetActive(false);
        npcCloseupImage.gameObject.SetActive(false);
        dialogText.text = "";
    }

    private void TriggerAction(DialogNode node)
    {
        // switch (node.actionType)
        // {
        //     case ActionType.StartQuest:
        //         QuestManager.Instance.StartQuest(node.actionParameter);
        //         break;
        //     case ActionType.MoveNPC:
        //         NPCManager.Instance.MoveNPC(node.actionParameter);
        //         break;
        //     case ActionType.TriggerEvent:
        //         EventManager.Instance.TriggerEvent(node.actionParameter);
        //         break;
        // }

        EndDialog();
    }
}