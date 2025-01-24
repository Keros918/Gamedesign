using System;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// For future event based input handling.
/// </summary>



public class InputManager : MonoBehaviour
{
    public static PlayerControls inputActions;
    public static event Action<InputActionMap> actionMapChange;

    private void Awake()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();
        }
    }
    private void Start()
    {
        inputActions.UI.Disable();
        inputActions.World.Enable();
    }
    private void OnEnable(){
        inputActions?.Enable();
    }

    private void OnDisable(){
        inputActions?.Disable();
    }

    public static void  ToggleActionMap(InputActionMap actionMap)
    {
        Debug.Log("ToggleActionMap");
        foreach (var map in inputActions.asset.actionMaps)
            {
                map.Disable();
            }
        Debug.Log("All Maps disabled");
        actionMap.Enable();
        Debug.Log("New action Map enabled.");
        
        /*
        if (actionMap.enabled) {
            Debug.Log("Current Map already active. Cancelling!");
            return;
        }
        else
        {   
            Debug.Log("Disabling Current Action Map!");
            inputActions.Disable();
            Debug.Log("Calling Action Map Change Event!");
            actionMapChange?.Invoke(actionMap);
            Debug.Log("Enabling New Action Map!");
            actionMap.Enable();
            Debug.Log("New Action Map enabled!");
        }
        */
    }
}
