using System;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 50f;
    private float currentHealth;
    public UnityEvent OnPlayerHealthChanged;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public float currentPlayerHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
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
        OnPlayerHealthChanged.Invoke();
    }

    public void Regenrate(float amount)
    {
        currentHealth = Math.Min(maxHealth, amount);
        OnPlayerHealthChanged.Invoke();
    }
}