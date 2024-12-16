using System;
using UnityEngine;

public class WorldSwitchController : MonoBehaviour
{
    [SerializeField]
    private RenderTexture furtwangenTexture;
    
    [SerializeField]
    private RenderTexture narugubiTexture;

    [SerializeField]
    private Material worldSwitchMaterial;

    private bool isFurtwangenActive = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFurtwangenActive = !isFurtwangenActive;
            UpdateWorldTexture();
        }
    }

    void UpdateWorldTexture()
    {
        if (isFurtwangenActive)
        {
            Debug.Log("test-1");
            worldSwitchMaterial.SetTexture("_ActiveWorldTexture", furtwangenTexture);
        }
        else
        {
            Debug.Log("test-2");
            worldSwitchMaterial.SetTexture("_ActiveWorldTexture", narugubiTexture);
        }
    }
}
