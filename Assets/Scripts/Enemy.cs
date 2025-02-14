using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    NavMeshAgent agent;
    [SerializeField] private int maxHealth = 50;
    private int currentHealth;
    [SerializeField] float attackRange = 5f;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float attackDamage = 10f;
    [SerializeField] float targetRange = 50f;
    [SerializeField] Transform playerTransform;
    [SerializeField] float cooldownInSeconds = 3f;

    AudioManager audioManager;
    private bool canAttack = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentHealth = maxHealth;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        // Collider2D targetHit = Physics2D.OverlapCircle(transform.position, targetRange, playerLayer);
        // if (targetHit.TryGetComponent<Transform>(out var playerTransform))
        // {
        //     target = playerTransform;
        // }
        // else
        // {
        //     // target = null;
        //     // agent.ResetPath();
        //     return;
        // }


        float distance = Vector2.Distance(playerTransform.position, transform.position);
        if (distance <= targetRange && target == null)
        {
            target = playerTransform;
        }
        if (distance <= targetRange && target != null)
        {
            agent.SetDestination(target.position);
        }
        if (distance > targetRange)
        {
            target = null;
            agent.ResetPath();
            return;
        }

        if (target != null && canAttack == true && distance <= attackRange)
        {
            Collider2D attackHit = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);
            if (attackHit != null && attackHit.TryGetComponent<PlayerHealth>(out var player))
            {
                player.TakeDamage(attackDamage);
                canAttack = false;
                StartCoroutine(StopAttacking());
            }
        }
    }

    private IEnumerator StopAttacking()
    {
        yield return new WaitForSeconds(cooldownInSeconds);
        canAttack = true;
    }

    public void TakeDamage(int damage)
    {
        audioManager.PlaySFX(audioManager.hit);
        currentHealth -= damage;
        Debug.Log($"Enemy {name} took {damage} damage. Current health: {currentHealth}");
        if (currentHealth <= 0)
        {
            audioManager.PlaySFX(audioManager.death);
            Debug.Log($"{name} died!");
            Destroy(gameObject);
        }
    }
}