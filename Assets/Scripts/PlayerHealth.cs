using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 50f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageTaken)
    {
        float updatedHealth = currentHealth - damageTaken;
        if (updatedHealth < 0)
        {
            updatedHealth = 0;
        }
        currentHealth = updatedHealth;
        Debug.Log("Player health: " + currentHealth);
    }
}