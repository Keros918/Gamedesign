using UnityEngine;

public class StaminaBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _staminaBar;

    public void UpdateStaminaBar(PlayerStamina playerStamina)
    {
        _staminaBar.fillAmount = playerStamina.currentPlayerStaminaPercentage;
    }
}

