using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy {name} took {damage} damage. Current health: {currentHealth}");
        if (currentHealth <= 0)
        {
            Debug.Log($"{name} died!");
            Destroy(gameObject);
        }
    }
}