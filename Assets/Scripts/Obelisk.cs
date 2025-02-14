using UnityEngine;

public class Obelisk : Interactable
{
    [SerializeField] private bool isActivated = false;
    [SerializeField] private Color activatedColor = Color.green;

    private SpriteRenderer spriteRenderer;
    private DialogList correspondingDialog;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        if (!isActivated)
        {
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
        }
    }

    public override bool InteractChecks()
    {
        return !isActivated && Inventory.HasLaserSword;
    }
}