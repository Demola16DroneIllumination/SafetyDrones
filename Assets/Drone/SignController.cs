using UnityEngine;

public class DroneScreenController : MonoBehaviour
{
    [Header("Drone screen material settings")]
    public Renderer screenRenderer;
    public Light projectorLight;
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
    }

    void Update()
    {
        // Vaihda seuraava kuva painamalla V
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Vaihdetaan kuvaa");
            NextTexture();
        }

        // Sammuta/käynnistä näyttö painamalla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleScreen();
        }
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
            // Käynnistä molemmat
            ApplyTexture();

            if (projectorLight != null)
                projectorLight.enabled = true;
        }
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