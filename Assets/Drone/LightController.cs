using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light stoplight;

        public void ToggleStoplight()
    {
        if (stoplight != null)
        {
            stoplight.enabled = !stoplight.enabled;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleStoplight();
        }
    }
}


