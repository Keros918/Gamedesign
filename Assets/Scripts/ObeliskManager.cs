using UnityEngine;

public class ObeliskManager : MonoBehaviour
{
    [SerializeField] private DialogController dialogController;
    [SerializeField] private DialogList dialogFirstActivated;
    [SerializeField] private DialogList dialogSecondActivated;
    [SerializeField] private DialogList dialogThirdActivated;
    public static DialogController DialogController;
    public static DialogList DialogFirstActivated;
    public static DialogList DialogSecondActivated;
    public static DialogList DialogThirdActivated;
    public static ObeliskManager Instance { get; private set; }
    private int totalObelisks;
    public static int ActivatedObelisks;

    private void Awake()
    {
        DialogController = dialogController;
        DialogFirstActivated = dialogFirstActivated;
        DialogSecondActivated = dialogSecondActivated;
        DialogThirdActivated = dialogThirdActivated;
        DialogFirstActivated.completed = false;
        DialogSecondActivated.completed = false;
        DialogThirdActivated.completed = false;


        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        totalObelisks = FindObjectsByType<Obelisk>(FindObjectsSortMode.None).Length;
        ActivatedObelisks = 0;
        Debug.Log(totalObelisks);
    }

    public void ObeliskActivated()
    {
        ActivatedObelisks++;
        Debug.Log($"Obelisks activated: {ActivatedObelisks}/{totalObelisks}");

        if (ActivatedObelisks >= totalObelisks)
        {
            AllObelisksActivated();
        }
    }

    public static DialogList GetNextDialog()
    {
        if (ActivatedObelisks == 1)
        {
            return DialogFirstActivated;
        }
        if (ActivatedObelisks == 2)
        {
            return DialogSecondActivated;
        }
        if (ActivatedObelisks == 3)
        {
            return DialogThirdActivated;
        }
        return null;
    }

    public static bool DialogCompleted()
    {
        return GetNextDialog().completed;
    }

    private void AllObelisksActivated()
    {
        Debug.Log("All Obelisks have been activated");
    }
}