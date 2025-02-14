using UnityEngine;

// public class Obelisk : MonoBehaviour
// {
//     [SerializeField] private bool isActivated = false;
//     [SerializeField] private SpriteRenderer spriteRenderer;
//     [SerializeField] private Color activatedColor = Color.green;

//     public void Activate()
//     {
//         if (!isActivated)
//         {
//             isActivated = true;
//             Debug.Log("Obelisk has been activated");

//             if (spriteRenderer != null)
//             {
//                 spriteRenderer.color = activatedColor;
//             }

//             ObeliskManager.Instance.ObeliskActivated();
//         }
//     }
// }
public class Obelisk : Interactable
{
    [SerializeField] private bool isActivated = false;
    [SerializeField] private Color activatedColor = Color.green;

    AudioManager audioManager;
    private SpriteRenderer spriteRenderer;
    private DialogList correspondingDialog;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public override void Interact()
    {
        if (!isActivated)
        {
            audioManager.PlaySFX(audioManager.obelisk);
            // isActivated = ObeliskManager.DialogCompleted();
            // hasInteraction = false;
            // Debug.Log("Obelisk has been activated");

            if (spriteRenderer != null)
            {
                spriteRenderer.color = activatedColor;
            }

            if (correspondingDialog == null)
            {
                ObeliskManager.Instance.ObeliskActivated();
                correspondingDialog = ObeliskManager.GetNextDialog();
            }
            ObeliskManager.DialogController.NextParagraph(correspondingDialog);
            isActivated = correspondingDialog.completed;

            // if (ObeliskManager.ActivatedObelisks == 1)
            // {
            //     ObeliskManager.DialogController.NextParagraph(ObeliskManager.DialogFirstActivated);
            // }
            // if (ObeliskManager.ActivatedObelisks == 2)
            // {
            //     ObeliskManager.DialogController.NextParagraph(ObeliskManager.DialogSecondActivated);
            // }
            // if (ObeliskManager.ActivatedObelisks == 3)
            // {
            //     ObeliskManager.DialogController.NextParagraph(ObeliskManager.DialogThirdActivated);
            // }
        }
    }

    public override bool InteractChecks()
    {
        return !isActivated && Inventory.HasLaserSword;
    }
}