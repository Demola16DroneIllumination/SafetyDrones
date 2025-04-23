using UnityEngine;

public class Area2CameraCheck : MonoBehaviour
{   
    public Camera Area2Camera;
    public GameObject[] Area2Effects;

    // Update is called once per frame
    void Update()
    {
        if (Area2Camera != null && Area2Effects != null)
        {
            // Check if the camera is enabled
            if (Area2Camera.enabled)
            {
                // Enable all objects in Area2Effects
                foreach (GameObject effect in Area2Effects)
                {
                    if (effect != null)
                        effect.SetActive(true);
                }
            }
            else
            {
                // Disable all objects in Area2Effects
                foreach (GameObject effect in Area2Effects)
                {
                    if (effect != null)
                        effect.SetActive(false);
                }
            }
        }
    }
}
