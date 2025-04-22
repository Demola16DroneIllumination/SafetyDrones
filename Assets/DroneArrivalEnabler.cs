using UnityEngine;

public class DroneArrivalEnabler : MonoBehaviour
{
    public GameObject[] EnableEffects;
    public GameObject[] Drones;
    public int SceneIndex = 0; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject effect in EnableEffects)
        {
            if (effect != null)
            {
                effect.SetActive(false);
            }
        }
        foreach (GameObject drone in Drones)
        {
            if (drone != null)
            {
                drone.GetComponent<DroneScreenController>()?.DisableSign();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CameraChangeDrone"))
        {
            foreach (GameObject effect in EnableEffects)
            {
                if (effect != null)
                {
                    effect.SetActive(true);
                }
            }
            if (SceneIndex == 2)
            {
                return;
            }
            else if (SceneIndex== 3)
            {
                Drones[0].GetComponent<DroneScreenController>()?.EnableSign();
                Drones[1].GetComponent<DroneScreenController>()?.EnableSign();
                Drones[2].GetComponent<DroneScreenController>()?.EnableSign();
                Drones[4].GetComponent<DroneScreenController>()?.EnableSign();
                Drones[5].GetComponent<DroneScreenController>()?.EnableSign();
                Drones[7].GetComponent<DroneScreenController>()?.EnableSign();

                foreach (GameObject drone in Drones)
                {
                    if (drone != null)
                    {
                        drone.GetComponent<DroneScreenController>()?.EnableSpotlights();
                    }
                }
            }
            else
            {
                foreach (GameObject drone in Drones)
                {
                    if (drone != null)
                    {
                        drone.GetComponent<DroneScreenController>()?.EnableSign();
                    }
                }
            }
        }
    }
}
