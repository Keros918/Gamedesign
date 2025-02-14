using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] DialogList md1RepeatableDialog;
    [SerializeField] DialogList md2Dialog;
    [SerializeField] PlayerMovementController playerMovement;

    void Start()
    {
        md1RepeatableDialog.unlocked = false;
        md2Dialog.unlocked = false;
        playerMovement.playerControls.World.Action1.Disable();
        playerMovement.playerControls.World.Action2.Disable();
    }
}