using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.AI;

public class PhoneMenu : MonoBehaviour
{
    public GameObject phoneMenu;
    private float select;                               //NewInputSystem
    private PlayerControls playerControls;              //NewInputSystem
    private UnityEngine.InputSystem.InputAction phoneAction;
    private UnityEngine.InputSystem.InputAction resumeAction;
/*

    void Awake()
    {
        phoneMenu.SetActive(false);

    }
    private void OnDestroy()
    {
        // Unregister callback methods
        phoneAction.started -= OnMenuButtonPressed;
        resumeAction.started -= OnResumeButtonPressed;
    }

    private void OnMenuButtonPressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        TimeHandler.ToggleGamePause();
        InputManager.ToggleActionMap(playerControls.UI);
        phoneMenu.SetActive(true);
    }

    private void OnResumeButtonPressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        TimeHandler.ToggleGamePause();
        InputManager.ToggleActionMap(playerControls.World);
        phoneMenu.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControls = InputManager.inputActions; 
        phoneAction = playerControls.World.Menu;
        resumeAction = playerControls.UI.Exit;       
        phoneAction.started += OnMenuButtonPressed;
        resumeAction.started += OnResumeButtonPressed;
    }
*/
}


