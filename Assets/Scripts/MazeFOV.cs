using UnityEngine;

public class MazeFOV : MonoBehaviour
{
    [SerializeField] private Material lanternEffectMaterial;
    [SerializeField] private LanternEffectController lantern;

    void Start()
    {
        lanternEffectMaterial.SetFloat("_RestrictedVisionRadius", 1.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || lantern.isFurtwangenActive)
        {
            return;
        }
        lantern.canToggleLantern = false;
        lantern.DeactivateLantern();
        lanternEffectMaterial.SetFloat("_RestrictedVisionRadius", 0.5f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        lantern.canToggleLantern = true;
        lanternEffectMaterial.SetFloat("_RestrictedVisionRadius", 1.5f);
    }
}
