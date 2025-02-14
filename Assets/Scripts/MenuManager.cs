using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _phone;
    [SerializeField] private GameObject _phoneBorder;
    [SerializeField] private GameObject _phoneMainScreen;
    [SerializeField] private GameObject _phoneNoSignalScreen;
    [SerializeField] private GameObject _inventoryMenu;
    [SerializeField] private GameObject _topInGameUI;
    [SerializeField] private GameObject _firstPhoneButton;
    [SerializeField] private GameObject _MoneyCount;
    [SerializeField] private GameObject _PfandCount;


    private PlayerControls playerControls; 
    private InputAction phoneAction;
    private InputAction resumeAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {   
        _phone.SetActive(false);
        _phoneBorder.SetActive(false);
        _phoneMainScreen.SetActive(false);
        _phoneNoSignalScreen.SetActive(false);
        _inventoryMenu.SetActive(false);
        _topInGameUI.SetActive(true);
    }
    void Start()
    {
        playerControls = InputManager.inputActions; 
        playerControls.Enable();
        phoneAction = playerControls.World.Menu;
        resumeAction = playerControls.UI.Exit;
        phoneAction.started += OnMenuButtonPressed;
        resumeAction.started += OnResumeButtonPressed;
        InventoryMenu.InitializeUI(_MoneyCount, _PfandCount);
    }

    private void GoToPhoneMain()
    {
        _phone.SetActive(true);
        Debug.Log("Going to phone");
        _phoneBorder.SetActive(true);
        Debug.Log("_phoneBorder = true");
        _phoneMainScreen.SetActive(true); 
        Debug.Log("_phoneMainScreen = true");
        _topInGameUI.SetActive(true);
        Debug.Log("_topInGameUI = true");
        _phoneNoSignalScreen.SetActive(false);
        Debug.Log("_phoneNoSignalScreen = false");
        _inventoryMenu.SetActive(false);
        Debug.Log("_inventoryMenu = false");
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(_firstPhoneButton, new BaseEventData(eventSystem));
    }
    private void GoToPhoneNoSignal()
    {
        _phone.SetActive(true);
        _phoneBorder.SetActive(true);
        _phoneMainScreen.SetActive(false); 
        _topInGameUI.SetActive(true);
        _phoneNoSignalScreen.SetActive(true);
        _inventoryMenu.SetActive(false);
    }

    private void GoToWorld()
    {
        _phone.SetActive(false);
        _phoneBorder.SetActive(false);
        _phoneMainScreen.SetActive(false); 
        _topInGameUI.SetActive(true);
        _phoneNoSignalScreen.SetActive(false);
        _inventoryMenu.SetActive(false);
    }

    public void GoToOpenInventory()
    {
        _phone.SetActive(false);
        _phoneBorder.SetActive(false);
        _phoneMainScreen.SetActive(false); 
        _topInGameUI.SetActive(false);
        _phoneNoSignalScreen.SetActive(false);
        _inventoryMenu.SetActive(true);
    }
    private void OnDestroy()
    {
        // Unregister callback methods
        phoneAction.performed -= OnMenuButtonPressed;
        resumeAction.performed -= OnResumeButtonPressed;
    }
    private void OnMenuButtonPressed(InputAction.CallbackContext context)
    {
        if (!TimeHandler.isPaused)
        {
            Debug.Log("OnMenuButtonPressed");
            TimeHandler.ToggleGamePause();
            Debug.Log("PauseToggled");
            InputManager.ToggleActionMap(playerControls.UI);
            GoToPhoneMain();
        }
    }

    private void OnResumeButtonPressed(InputAction.CallbackContext context)
    {
        if (TimeHandler.isPaused == true)
        {
            Debug.Log("OnResumeButtonPressed");
            TimeHandler.ToggleGamePause();
            Debug.Log("PauseToggled");
            InputManager.ToggleActionMap(playerControls.World);
            GoToWorld();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
