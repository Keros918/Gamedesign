using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip attack;
    public AudioClip hit;
    public AudioClip heal;
    public AudioClip buy;
     public AudioClip collect_pfand;
    public AudioClip lantern_on;
    public AudioClip lantern_off;
    public AudioClip dialog;
    public AudioClip obelisk;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    
}
