using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] DialogList ld1;
    [SerializeField] DialogList md1;
    [SerializeField] DialogList md2;
    [SerializeField] DialogList md1_repeatable;
    [SerializeField] PlayerMovementController playerMovement;

    void Start()
    {
        ld1.unlocked = true;
        md1.unlocked = true;
        md2.unlocked = false;
        md1_repeatable.unlocked = false;
        playerMovement.playerControls.World.Action1.Disable();
        playerMovement.playerControls.World.Action2.Disable();
    }
}