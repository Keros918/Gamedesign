using Unity.VisualScripting;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _healthBar;

    public void UpdateHealthBar(PlayerHealth playerHealth)
    {
        _healthBar.fillAmount = playerHealth.currentPlayerHealthPercentage;
    }
}
