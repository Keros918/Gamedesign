using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogNode
{
    public string speakerName;      // Who is speaking
    [TextArea] public string text; // The dialog line
    public List<DialogChoice> choices; // Player's possible responses
    public bool isEndNode;          // Marks the end of the dialog
    public ActionType actionType;   // Action triggered when this node ends
    public string actionParameter; // Parameter for the action (e.g., quest ID or NPC destination)
}

[Serializable]
public class DialogChoice
{
    public string text;           // The player's choice text
    public int nextNodeIndex;     // Index of the next dialog node
}

public enum ActionType
{
    None,
    StartQuest,
    MoveNPC,
    TriggerEvent
}
