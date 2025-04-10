using UnityEngine;

public class ProjectorController : MonoBehaviour
{
    public Light projectorlight;

    [Header("Liikennemerkit")]
    public Texture2D[] cookieTextures;  
    private int currentCookieIndex = 0;

    public void ToggleProjectorlight()
    {
        if (projectorlight != null)
        {
            projectorlight.enabled = !projectorlight.enabled;
        }
    }

    public void NextCookie()
    {
        if (cookieTextures.Length == 0 || projectorlight == null)
            return;

        currentCookieIndex = (currentCookieIndex + 1) % cookieTextures.Length;
        projectorlight.cookie = cookieTextures[currentCookieIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleProjectorlight(); // P‰‰lle/pois
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            NextCookie(); // Vaihda seuraava liikennemerkki
        }
    }
}