using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Weather : MonoBehaviour
{
    [SerializeField] private GameObject rainOverlay;
    private Volume volume;
    private ColorAdjustments colorAdjustments;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (volume == null)
        {
            volume = GetComponent<Volume>();
        }
        volume.profile.TryGet(out colorAdjustments);
    }

    public void UpdateWeather(float mood)
    {
        float currentSaturation = colorAdjustments.saturation.value;
        mood = (mood - 1f) * 12;
        Debug.Log(mood);
        colorAdjustments.saturation.value = Mathf.Lerp(currentSaturation, mood, 2f);
        if (mood <= -20)
        {
            rainOverlay.SetActive(true);
        }
        else
        {
            rainOverlay.SetActive(false);
        }
    }
}
