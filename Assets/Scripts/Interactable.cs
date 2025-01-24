using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

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
    }
    void Start()
    {
        playerControls = InputManager.inputActions;
        
        if (playerControls == null)
        {
            Debug.LogError("InputManager.inputActions is not initialized!");
            return;
        }
        playerControls.World.Interact.performed += OnInteract;
    }
    void Update()
    {
        /*
        // interact = playerControls.World.Interact.ReadValue<float>();
        bool isWithinInteractDistance = IsWithinInteractDistance();
        interactSprite.gameObject.SetActive(isWithinInteractDistance);
        if (!hasInteraction)
        {
            interactSprite.enabled = false;
        }
        */
    }
    private void OnDestroy()
    {
        // Unregister callback methods
        playerControls.World.Interact.performed -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Interaction triggered");
        bool isWithinInteractDistance = IsWithinInteractDistance();
        interactSprite.gameObject.SetActive(isWithinInteractDistance);
        if (!hasInteraction)
            {
                interactSprite.enabled = false;
            }

        if (isWithinInteractDistance && hasInteraction)
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