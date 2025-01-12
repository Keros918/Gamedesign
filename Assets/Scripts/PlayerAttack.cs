using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float staminaCost = 20f;
    [SerializeField] private PlayerStamina stamina;

    private void Start()
    {
        if (stamina == null)
        {
            stamina = GetComponent<PlayerStamina>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            stamina.UseStamina(staminaCost);
            foreach (Collider2D hit in hits)
            {
                hit.GetComponent<Enemy>()?.TakeDamage(attackDamage);
                hit.GetComponent<Obelisk>()?.Activate();
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
