using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int attackDamage = 15;
    [SerializeField] private float staminaCost = 10;
    [SerializeField] private PlayerStamina stamina;
    [SerializeField] private Animator animator;

    
    private PlayerControls playerControls;
    private float attack;
    private void Start()
    {
        if (stamina == null)
        {
            stamina = GetComponent<PlayerStamina>();
        }
    }
    void Awake()
    {
        playerControls = new PlayerControls();
        animator = GetComponent<Animator>();
    }
    private void OnEnable(){
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerControls.World.Action1.triggered)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            if (stamina.UseStamina(staminaCost))
            {
                animator.SetTrigger("Laser");
                foreach (Collider2D hit in hits)
                {
                    hit.GetComponent<Enemy>()?.TakeDamage(attackDamage);
                    // hit.GetComponent<Obelisk>()?.In;
                }
            }
        } 
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
