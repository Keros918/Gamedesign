using System;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// For future event based input handling.
/// </summary>



public class InputManager : MonoBehaviour
{
    public static PlayerControls inputActions = new PlayerControls();
    public static event Action<InputActionMap> actionMapChange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ToggleActionMap(inputActions.World);
    }

    public static void   ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled)
            return;
        inputActions.Disable();
        actionMapChange?.Invoke(actionMap);
        actionMap.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
