using UnityEngine;

public class Obelisk : MonoBehaviour
{
    [SerializeField] private bool isActivated = false;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color activatedColor = Color.green;

    public void Activate()
    {
        if (!isActivated)
        {
            isActivated = true;
            Debug.Log("Obelisk has been activated");

            if (spriteRenderer != null)
            {
                spriteRenderer.color = activatedColor;
            }

            ObeliskManager.Instance.ObeliskActivated();
        }
    }
}