using System;
using UnityEngine;

public class DroneScreenController : MonoBehaviour
{
    [Header("Drone screen material settings")]
    public Renderer screenRenderer;
    public Light projectorLight;
    public Light Spotlight1;
    public Light Spotlight2;
    public Texture2D[] screenTextures;

    private int currentIndex = 0;
    private Material screenMaterial;

    void Start()
    {
        if (screenRenderer != null)
        {
            screenMaterial = screenRenderer.material;
            ApplyTexture();
        }
        DisableSign(); // Disable the sign at the start
        DisableSpotlights(); // Disable the spotlights at the start
    }

    void Update()
    {
        // Vaihda seuraava kuva painamalla V
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Vaihdetaan kuvaa");
            NextTexture();
        }

        // Sammuta/k�ynnist� n�ytt� painamalla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleScreen();
        }
    }

    public void SetScreenTexture(int signIndex){
        currentIndex = signIndex;
    }
    public void NextTexture()
    {
        if (screenTextures.Length == 0) return;

        currentIndex = (currentIndex + 1) % screenTextures.Length;
        ApplyTexture();
    }

    public void ToggleScreen()
    {
        if (screenMaterial.IsKeywordEnabled("_EMISSION"))
        {
            // Sammuta molemmat
            screenMaterial.DisableKeyword("_EMISSION");
            screenMaterial.SetTexture("_EmissionMap", null);
            screenMaterial.mainTexture = null;

            if (projectorLight != null)
                projectorLight.enabled = false;
        }
        else
        {
            // K�ynnist� molemmat
            ApplyTexture();

            if (projectorLight != null)
                projectorLight.enabled = true;
        }
    }
    
    public void EnableSign()
    {
        // Enable both the screen and the projector light
        ApplyTexture();

        if (projectorLight != null)
            projectorLight.enabled = true;
    }

    public void DisableSign()
    {
        if (screenMaterial != null) // Check if screenMaterial is not null  
        {
            screenMaterial.DisableKeyword("_EMISSION");
            screenMaterial.SetTexture("_EmissionMap", null);
            screenMaterial.mainTexture = null;
        }

        if (projectorLight != null) // Check if projectorLight is not null  
        {
            projectorLight.enabled = false;
        }
    }

    public void EnableSpotlights()
    {
        if (Spotlight1 != null)
            Spotlight1.enabled = true;
        if (Spotlight2 != null)
            Spotlight2.enabled = true;
    }
    public void DisableSpotlights()
    {
        if (Spotlight1 != null)
            Spotlight1.enabled = false;
        if (Spotlight2 != null)
            Spotlight2.enabled = false;
    }
    
    private void ApplyTexture()
    {
        Texture2D tex = screenTextures[currentIndex];

        screenMaterial.mainTexture = tex;
        screenMaterial.SetTexture("_EmissionMap", tex);
        screenMaterial.SetColor("_EmissionColor", Color.white);
        screenMaterial.EnableKeyword("_EMISSION");

        if (projectorLight != null)
        {
            projectorLight.cookie = tex;
            
            
        }
    }
}