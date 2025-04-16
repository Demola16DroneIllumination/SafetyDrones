using UnityEngine;

public class WaypointCameraChange : MonoBehaviour
{

    public int cameraIndex = 8;
    public CameraChangeScript cameraChangeScript;
    public bool thisPointCameraChangeEnabled = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cameraChangeScript.autoCameraEnabled && thisPointCameraChangeEnabled && other.CompareTag("CameraChangeDrone")) //&& (other.gameObject.layer == 6))
        { 
            cameraChangeScript.EnableCamera(cameraIndex);
        }
    }
}
