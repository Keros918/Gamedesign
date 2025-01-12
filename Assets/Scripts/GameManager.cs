using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int totalObelisks;
    private int activatedObelisks;

    private void Awake()
    {
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
        activatedObelisks = 0;
        Debug.Log(totalObelisks);
    }

    public void ObeliskActivated()
    {
        activatedObelisks++;
        Debug.Log($"Obelisks activated: {activatedObelisks}/{totalObelisks}");

        if (activatedObelisks >= totalObelisks)
        {
            AllObelisksActivated();
        }
    }

    private void AllObelisksActivated()
    {
        Debug.Log("All Obelisks have been activated");
    }
}