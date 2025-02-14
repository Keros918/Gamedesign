using UnityEngine;

[CreateAssetMenu(fileName = "DialogList", menuName = "Dialog/DialogList")]
public class DialogList: ScriptableObject
{
    public DialogNode[] paragraphs;
    [HideInInspector] public bool completed;
    public bool unlocked = false;
    public DialogList unlockOnCompletion;
    public bool unlockLaserSword;
    public bool unlockLantern;
}