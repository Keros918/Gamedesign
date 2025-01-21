using UnityEngine;

public class LanternEffectController : MonoBehaviour
{
    [SerializeField] private RenderTexture furtwangenTexture;
    [SerializeField] private RenderTexture narugubiTexture;
    [SerializeField] private Camera _camera;
    private bool isFurtwangenActive = true;

    private bool isLanternEnabled = false;
    [SerializeField] private Material lanternEffectMaterial;
    [SerializeField] private Transform lanternTransform;
    [SerializeField] private float lanternRadius = 5f;

    private PlayerControls playerControls;
    private float useLantern;
    private float aspectRatio;

    void Start()
    {
        UpdateWorldTextures();
        UpdateLanternEnabled();
        aspectRatio = (float)furtwangenTexture.width / furtwangenTexture.height;
    }
    void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable(){
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }
    // Update is called once per frame
    void Update()
    {

        useLantern = playerControls.World.Action2.ReadValue<float>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFurtwangenActive = !isFurtwangenActive;
            UpdateWorldTextures();
        }
        if (playerControls.World.Action2.triggered)
        {
            isLanternEnabled = !isLanternEnabled;
            UpdateLanternEnabled();
        }
        Vector2 lanternPosition = new Vector2(lanternTransform.position.x, lanternTransform.position.y);
        Vector3 viewportPos = _camera.WorldToViewportPoint(lanternPosition);
        // Vector2 ndcPos = new Vector2(viewportPos.x * 2 - 1, viewportPos.y * 2 - 1);
        lanternEffectMaterial.SetVector("_LanternPosition", viewportPos);
        lanternEffectMaterial.SetFloat("_LanternRadius", lanternRadius);
        lanternEffectMaterial.SetFloat("_AspectRatio", aspectRatio);
    }

    void UpdateLanternEnabled()
    {
        if (isLanternEnabled)
        {
            lanternEffectMaterial.SetInt("_EnableLantern", 1);
        }
        else
        {
            lanternEffectMaterial.SetInt("_EnableLantern", 0);
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
