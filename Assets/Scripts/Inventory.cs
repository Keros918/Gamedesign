using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int money = 0;
    [SerializeField] private int pfand = 0;
    [SerializeField] private int healingItems = 0;
    [SerializeField] private float healingAmount = 10f;
    [SerializeField] private EnemyManager enemyManager;

    AudioManager audioManager;


    private PlayerControls playerControls;

    public static bool HasLaserSword;
    public static bool HasLantern;
    public static int Money;
    public static int Pfand;
    public int HealingItems => healingItems;
 
    void Start()
    {
        playerControls = InputManager.inputActions;
        Money = money;
        Pfand = pfand;
        InventoryMenu.UpdateItemCounts();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnEnable(){
        playerControls.Enable();
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
        HasLaserSword = true;
        enemyManager.Enable();
    }
    public void UnlockLantern() => HasLantern = true;

    public void CollectMoney(int amount){
        money += amount;
        Money = money;
        InventoryMenu.UpdateItemCounts();  
    }
    public void CollectPfand(int amount){
        pfand += amount;
        Pfand = pfand;
        InventoryMenu.UpdateItemCounts(); 
    }
    public void TradePfand(int amountPfandTraded, int pricePerPfand = 1)
    {
        money += amountPfandTraded * pricePerPfand;
        pfand -= amountPfandTraded;
        Money = money;
        Pfand = pfand;
        InventoryMenu.UpdateItemCounts(); 
    }

    public bool BuyHealingItem(int cost)
    {
        if (money >= cost)
        {
            audioManager.PlaySFX(audioManager.buy);
            money -= cost;
            Money = money;
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
            Pfand = pfand;
            InventoryMenu.UpdateItemCounts(); 
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