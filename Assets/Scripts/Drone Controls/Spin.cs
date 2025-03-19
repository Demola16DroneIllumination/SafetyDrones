using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Spin : MonoBehaviour
{
    [Header("Fan Settings")]
    public float fanSpeed;
    public List<Transform> signs = new() { null };
    public GameObject signLocation;

    private float droneSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

        // Update is called once per frame
    void Update()
    {
        droneSpeed = GameObject.Find("Drone").GetComponent<DroneMovement>().droneSpeed;

        if (droneSpeed <= 0.1f)
        {
            fanSpeed = 5000;
        }
        transform.Rotate(fanSpeed * Time.deltaTime, 0, 0, Space.Self);
    }
}

