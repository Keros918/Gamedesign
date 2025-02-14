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

    private PlayerControls playerControls;

    public bool HasLaserSword => hasLaserSword;
    public bool HasLantern => hasLantern;
    public static int Money;
    public static int Pfand;
    public int HealingItems => healingItems;
 
    void Start()
    {
        playerControls = InputManager.inputActions;
        Money = money;
        Pfand = pfand;
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

    public void CollectMoney(int amount){
        money += amount;
        InventoryMenu.UpdateItemCounts();  
    }
    public void CollectPfand(int amount){
        pfand += amount;
        InventoryMenu.UpdateItemCounts(); 
    }
    public void TradePfand(int amountPfandTraded, int pricePerPfand = 1)
    {
        money += amountPfandTraded * pricePerPfand;
        pfand -= amountPfandTraded;
        InventoryMenu.UpdateItemCounts(); 
    }

    public bool BuyHealingItem(int cost)
    {
        if (money >= cost)
        {
            money -= cost;
            healingItems++;
            InventoryMenu.UpdateItemCounts(); 
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
            InventoryMenu.UpdateItemCounts(); 
            if (TryGetComponent<PlayerHealth>(out var player))
            {
                player.Regenrate(healingAmount);
                return true;
            }
        }
        return false;
    }
}