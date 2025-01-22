using System.Linq;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private SpriteRenderer interactSprite;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float interactDistance = 5f;
    protected bool hasInteraction = true;

    private float interact;                             //NewInputSystem
    private PlayerControls playerControls;              //NewInputSystem

    void Awake()
    {
        interactSprite = GetComponentsInChildren<SpriteRenderer>().LastOrDefault();
        playerControls = new PlayerControls();          //NewInputSystem
    }
    private void OnEnable(){                            //NewInputSystem
        playerControls.Enable();
    }
    private void OnDisable(){                           //NewInputSystem
        playerControls.Disable();
    }
    void Update()
    {
        interact = playerControls.World.Interact.ReadValue<float>();      //NewInputSystem
        bool isWithinInteractDistance = IsWithinInteractDistance();
        interactSprite.gameObject.SetActive(isWithinInteractDistance);
        if (!hasInteraction)
        {
            interactSprite.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Q) && isWithinInteractDistance && hasInteraction)
        {
            Interact();
        }
    }

    public abstract void Interact();

    private bool IsWithinInteractDistance()
    {
        float distance = Vector2.Distance(playerTransform.position, transform.position);
        return distance < interactDistance;
    }
}