using UnityEngine;
using System;
using UnityEngine.AI;

public class InventoryMenu : MonoBehaviour
{
    public GameObject inventoryMenu;
    public static bool isPaused;
    private float select;                               //NewInputSystem
    private PlayerControls playerControls;              //NewInputSystem


    void Awake()
    {
        playerControls = new PlayerControls();          //NewInputSystem
    }
    private void OnEnable(){                            //NewInputSystem
        playerControls.Enable();
    }
    private void OnDisable(){                           //NewInputSystem
        playerControls.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        select = playerControls.World.Menu.ReadValue<float>();

        if (playerControls.World.Menu.triggered)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void PauseGame()
    {
        inventoryMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

public void ResumeGame()
{
    inventoryMenu.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;
}


}