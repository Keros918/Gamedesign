using UnityEngine;
using System;
using UnityEngine.AI;

public class InventoryMenu : MonoBehaviour
{
    public GameObject inventoryMenu;
    public static bool isPaused;
    private float select;                               //NewInputSystem
    private PlayerControls playerControls;              //NewInputSystem

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryMenu.SetActive(false);
        playerControls = InputManager.inputActions; 
    }

    // Update is called once per frame
    void Update()
    {
    }

public void ResumeGame()
{
    inventoryMenu.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;
}


}