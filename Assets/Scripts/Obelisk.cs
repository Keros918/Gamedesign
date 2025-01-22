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
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        if (!isActivated)
        {
            isActivated = true;
            hasInteraction = false;
            Debug.Log("Obelisk has been activated");

            if (spriteRenderer != null)
            {
                spriteRenderer.color = activatedColor;
            }

            ObeliskManager.Instance.ObeliskActivated();
        }
    }
}