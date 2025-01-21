using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Game/Dialog")]
public class Dialog : ScriptableObject
{
    public List<DialogNode> dialogNodes; // List of dialog nodes
}