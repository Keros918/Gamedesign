using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private LanternEffectController lantern;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        if (Inventory.HasLaserSword && lantern.isFurtwangenActive)
        {
            gameObject.SetActive(true);
        }
    }

    public void Disable()
    {
        if (!Inventory.HasLaserSword || !lantern.isFurtwangenActive)
        {
            gameObject.SetActive(false);
        }
    }
}