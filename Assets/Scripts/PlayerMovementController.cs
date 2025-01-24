using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D playerBody;
    private Rigidbody2D rb;
    private Vector2 move;                               //NewInputSystem
    private PlayerControls playerControls;              //NewInputSystem
    public bool isMoving;

    void Awake()
    {
        playerControls = InputManager.inputActions; 
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerControls = InputManager.inputActions; 
    }
    void Update()
    {
        move = playerControls.World.Move.ReadValue<Vector2>();      //NewInputSystem

        animator.SetFloat("moveSpeed", move.sqrMagnitude);

        if (move.sqrMagnitude > 0) 
        {
            animator.SetFloat("moveX", move.x);
            animator.SetFloat("moveY", move.y);
        } 
    }

    void FixedUpdate()  //Smoother Movement
    {
        playerBody.MovePosition(playerBody.position + moveSpeed * Time.fixedDeltaTime * move);
    }
}
