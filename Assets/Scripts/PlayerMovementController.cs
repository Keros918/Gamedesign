using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D playerBody;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    public bool isMoving;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput.Normalize();

        animator.SetFloat("moveSpeed", movementInput.sqrMagnitude);

        if (movementInput.sqrMagnitude > 0) 
        {
            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);
        }

    }

    void FixedUpdate()
    /*{
        rb.linearVelocity = movementInput * speed;
    }*/
    {
        playerBody.MovePosition(playerBody.position + moveSpeed * Time.fixedDeltaTime * movementInput);
    }
}
