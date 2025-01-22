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
        lanternEffectMaterial.SetFloat("_RestrictedVisionRadius", 0.5f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        lanternEffectMaterial.SetFloat("_RestrictedVisionRadius", 1.5f);
    }
}
