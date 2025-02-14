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