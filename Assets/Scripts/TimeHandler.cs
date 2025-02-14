using UnityEngine;

public class TimeHandler : MonoBehaviour
{

     public static bool isPaused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void ToggleGamePause()
    {
        if (isPaused)
        {   
            Debug.Log("Game is paused, unpausing...");
            Time.timeScale = 1f;
            Debug.Log("Game is unpaused");
            isPaused = false;
            return;
        }    
        else
        {
            Debug.Log("Game is unpaused, pausing...");
            Time.timeScale = 0f;
            Debug.Log("Game is paused");
            isPaused = true;
            return;
        }     
    }
}
