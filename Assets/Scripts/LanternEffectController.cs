using UnityEngine;
using UnityEngine.Tilemaps;

public class LanternEffectController : MonoBehaviour
{
    [SerializeField] private RenderTexture furtwangenTexture;
    [SerializeField] private RenderTexture narugubiTexture;
    [SerializeField] private Tilemap furtwangenCollider;
    [SerializeField] private Tilemap narugubiCollider;
    [SerializeField] private GameObject navmeshFurtwangen;
    [SerializeField] private GameObject navmeshNarugubi;
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
        UpdateWorldTextures(true);
        UpdateLanternEnabled(true);
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
            UpdateWorldTextures(false);
        }
        if (playerControls.World.Action2.triggered)
        {
            isLanternEnabled = !isLanternEnabled;
            UpdateLanternEnabled(false);
        }
        Vector2 lanternPosition = new Vector2(lanternTransform.position.x, lanternTransform.position.y);
        Vector3 viewportPos = _camera.WorldToViewportPoint(lanternPosition);
        // Vector2 ndcPos = new Vector2(viewportPos.x * 2 - 1, viewportPos.y * 2 - 1);
        lanternEffectMaterial.SetVector("_LanternPosition", viewportPos);
        lanternEffectMaterial.SetFloat("_LanternRadius", lanternRadius);
        lanternEffectMaterial.SetFloat("_AspectRatio", aspectRatio);
    }

    void UpdateLanternEnabled(bool init)
    {
        if (isLanternEnabled)
        {
            lanternEffectMaterial.SetInt("_EnableLantern", 1);
        }
        else
        {
            lanternEffectMaterial.SetInt("_EnableLantern", 0);
        }
        SwapColliders(init);
    }

    void SwapColliders(bool init)
    {
        if (init == true)
        {
            navmeshFurtwangen.SetActive(true);
            navmeshNarugubi.SetActive(false);
            furtwangenCollider.gameObject.SetActive(true);
            narugubiCollider.gameObject.SetActive(false);
            return;
        }
        bool furtwangenColliderActive = furtwangenCollider.gameObject.activeSelf;
        bool narugubiColliderActive = narugubiCollider.gameObject.activeSelf;
        furtwangenCollider.gameObject.SetActive(!furtwangenColliderActive);
        narugubiCollider.gameObject.SetActive(!narugubiColliderActive);
    }

    void UpdateWorldTextures(bool init)
    {
        if (isFurtwangenActive)
        {
            navmeshFurtwangen.SetActive(true);
            navmeshNarugubi.SetActive(false);
            lanternEffectMaterial.SetTexture("_ActiveWorldTexture", furtwangenTexture);
            lanternEffectMaterial.SetTexture("_InactiveWorldTexture", narugubiTexture);
        }
        else
        {
            navmeshFurtwangen.SetActive(false);
            navmeshNarugubi.SetActive(true);
            lanternEffectMaterial.SetTexture("_ActiveWorldTexture", narugubiTexture);
            lanternEffectMaterial.SetTexture("_InactiveWorldTexture", furtwangenTexture);
        }
        SwapColliders(init);
    }
}
