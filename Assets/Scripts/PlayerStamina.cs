using UnityEngine;
using UnityEngine.Events;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] public float currentStamina;
    [SerializeField] private float staminaRegenRate = 5f;
    [SerializeField] private float emptyStaminaDelay = 1.5f;

    private bool isRegenerating = true;
    private float regenDelayTimer;
    
    public UnityEvent OnPlayerStaminaChanged;

    private void Start()
    {
        currentStamina = maxStamina;
    }

    private void Update()
    {
        if (!isRegenerating)
        {
            return;
        }
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            OnPlayerStaminaChanged.Invoke();
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);   
        }
        // Debug.Log(currentStamina);
    }

    public float currentPlayerStaminaPercentage
    {
        get
        {
            return currentStamina / maxStamina;
        }
    }
    public bool UseStamina(float amount)
    {
        float stamina = currentStamina - amount;
        // currentStamina -= amount;
        OnPlayerStaminaChanged.Invoke();
        CheckStaminaStatus(stamina);
        if (stamina <= 0)
        {
            return false;
        }
        currentStamina = stamina;
        return true;
    }

    private void CheckStaminaStatus(float stamina)
    {
        if (stamina <= 0)
        {
            // currentStamina = 0;
            isRegenerating = false;
            regenDelayTimer = emptyStaminaDelay;
            StartCoroutine(DelayedRegen());
        }
    }

    private System.Collections.IEnumerator DelayedRegen()
    {
        yield return new WaitForSeconds(emptyStaminaDelay);
        isRegenerating = true;
    }

    public void AddStamina(float amount)
    {
        currentStamina = Mathf.Clamp(currentStamina += amount, 0, maxStamina);
        OnPlayerStaminaChanged.Invoke();
    }

    public void AccelerateRegen(float multiplier, float duration)
    {
        StartCoroutine(AccelerateRegenCoroutine(multiplier, duration));
    }

    private System.Collections.IEnumerator AccelerateRegenCoroutine(float multiplier, float duration)
    {
        float originalRegenRate = staminaRegenRate;
        staminaRegenRate *= multiplier;
        yield return new WaitForSeconds(duration);
        staminaRegenRate = originalRegenRate;
    }
}