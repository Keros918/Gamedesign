using UnityEngine;

[CreateAssetMenu(fileName = "DialogNode", menuName = "Dialog/DialogNode")]
public class DialogNode : ScriptableObject
{
    [TextArea] public string text;
    public Sprite speakerSprite;
    public string speakerName;
}