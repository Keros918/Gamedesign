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

    void Start()
    {
        playerControls = InputManager.inputActions;
        
        if (playerControls == null)
        {
            Debug.LogError("InputManager.inputActions is not initialized!");
            return;
        }
    }
    void Update()
    {
        interact = playerControls.World.Interact.ReadValue<float>();
        bool isWithinInteractDistance = IsWithinInteractDistance();
        interactSprite.gameObject.SetActive(isWithinInteractDistance);
        bool hasInteraction = InteractChecks();
        interactSprite.enabled = hasInteraction;
        if (playerControls.World.Interact.triggered && isWithinInteractDistance && hasInteraction)
        {
            Interact();
        }
    }

    public abstract bool InteractChecks();

    public abstract void Interact();

    private bool IsWithinInteractDistance()
    {
        float distance = Vector2.Distance(playerTransform.position, transform.position);
        return distance < interactDistance;
    }
}