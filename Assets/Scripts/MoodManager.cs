using UnityEngine;

public class MoodManager : MonoBehaviour
{
    [SerializeField] private float mood = 0f;
    [SerializeField] private Weather weather;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AdjustMood(-0.1f);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AdjustMood(0.1f);
        }
    }

    public float Mood
    {
        get => mood;
        set
        {
            Debug.Log("test");
            mood = Mathf.Clamp(value, -1f, 1f);
            weather.UpdateWeather(mood);
        }
    }

    public void AdjustMood(float amount)
    {
        Mood += amount;
    }
}