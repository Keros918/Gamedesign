using Unity.VisualScripting;
using UnityEngine;

public class LanternEffectController : MonoBehaviour
{
    [SerializeField] private RenderTexture furtwangenTexture;
    [SerializeField] private RenderTexture narugubiTexture;
    private bool isFurtwangenActive = true;

    private bool isLanternEnabled = false;
    [SerializeField] private Material lanternEffectMaterial;
    [SerializeField] private Transform lanternTransform;
    [SerializeField] private float lanternRadius = 5f;

    void Start()
    {
        UpdateWorldTextures();
        UpdateLanternEnabled();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFurtwangenActive = !isFurtwangenActive;
            UpdateWorldTextures();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("test");
            isLanternEnabled = !isLanternEnabled;
            UpdateLanternEnabled();
        }
        Vector2 lanternPosition = new Vector2(lanternTransform.position.x, lanternTransform.position.y);
        lanternEffectMaterial.SetVector("_LanternPosition", lanternPosition);
        lanternEffectMaterial.SetFloat("_LanternRadius", lanternRadius);
    }

    void UpdateLanternEnabled()
    {
        if (isLanternEnabled)
        {
            lanternEffectMaterial.SetInt("_EnableLantern", 1);
            // lanternEffectMaterial.DisableKeyword("_EnableLantern");
        }
        else
        {
            lanternEffectMaterial.SetInt("_EnableLantern", 0);
            // lanternEffectMaterial.EnableKeyword("_EnableLantern");
        }
    }

    void UpdateWorldTextures()
    {
        if (isFurtwangenActive)
        {
            lanternEffectMaterial.SetTexture("_ActiveWorldTexture", furtwangenTexture);
            lanternEffectMaterial.SetTexture("_InactiveWorldTexture", narugubiTexture);
        }
        else
        {
            lanternEffectMaterial.SetTexture("_ActiveWorldTexture", narugubiTexture);
            lanternEffectMaterial.SetTexture("_InactiveWorldTexture", furtwangenTexture);
        }
    }
}
