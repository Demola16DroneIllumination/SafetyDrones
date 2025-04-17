using UnityEngine;

public class DroneArrivalEnabler : MonoBehaviour
{
    public GameObject[] EnableEffects;
    
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
        }
    }
}
