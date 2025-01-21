using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] private Dialog dialog;
    [SerializeField] private Sprite closeupSprite;

    public Dialog GetDialog()
    {
        return dialog;
    }

    public Sprite GetCloseupSprite()
    {
        return closeupSprite;
    } 
}