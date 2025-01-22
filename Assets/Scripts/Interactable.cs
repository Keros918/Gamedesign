using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer interactSprite;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float interactDistance = 5f;
    protected bool hasInteraction = true;

    void Update()
    {
        bool isWithinInteractDistance = IsWithinInteractDistance();
        interactSprite.gameObject.SetActive(isWithinInteractDistance);
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