using UnityEngine;

[CreateAssetMenu( fileName = "Dialog", menuName = "Dialog/Dialog")]
public class DialogText : ScriptableObject
{
    [TextArea] public string[] paragraphs;
    [HideInInspector] public bool completed;
}