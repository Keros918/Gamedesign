using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private bool hasLaserSword = false;
    [SerializeField] private bool hasLantern = false;
    [SerializeField] private int money = 0;
    [SerializeField] private int pfand = 0;
    [SerializeField] private int healingItems = 0;
    [SerializeField] private float healingAmount = 10f;
    [SerializeField] private EnemyManager enemyManager;

    AudioManager audioManager;


    private PlayerControls playerControls;

    public bool HasLaserSword => hasLaserSword;
    public bool HasLantern => hasLantern;
    public int Money => money;
    public int Pfand => pfand;
    public int HealingItems => healingItems;
    void Awake()
    {
        playerControls = new PlayerControls();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnEnable(){
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }
    void Update()
    {

        if (playerControls.World.Action3.triggered)
        {
            UseHealingItem();
        }
    }

    public void UnlockLaserSword()
    {
        hasLaserSword = true;
        enemyManager.Enable();
    }
    public void UnlockLantern() => hasLantern = true;

    public void CollectMoney(int amount) => money += amount;
    public void CollectPfand(int amount) => pfand += amount;

    public void TradePfand(int amountPfandTraded, int pricePerPfand = 1)
    {
        money += amountPfandTraded * pricePerPfand;
        pfand -= amountPfandTraded;
    }

    public bool BuyHealingItem(int cost)
    {
        if (money >= cost)
        {
            audioManager.PlaySFX(audioManager.buy);
            money -= cost;
            healingItems++;
            return true;
        }
        return false;
    }

    public bool UseHealingItem()
    {
        if (healingItems > 0)
        {
            healingItems--;
            pfand++;
            if (TryGetComponent<PlayerHealth>(out var player))
            {
                audioManager.PlaySFX(audioManager.heal);
                player.Regenrate(healingAmount);
                return true;
            }
        }
        return false;
    }
}