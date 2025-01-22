using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // [SerializeField] private GameObject enemyContainer;
    [SerializeField] private Inventory inventory;
    [SerializeField] private LanternEffectController lantern;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        if (inventory.HasLaserSword && lantern.isFurtwangenActive)
        {
            gameObject.SetActive(true);
        }
    }

    public void Disable()
    {
        if (!inventory.HasLaserSword || !lantern.isFurtwangenActive)
        {
            gameObject.SetActive(false);
        }
    }
}