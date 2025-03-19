using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DroneMovement : MonoBehaviour
{
    [Header("Drone Settings")]
    [Tooltip("Drone's flight path positions")]
    public List<Transform> location = new() { null};

    private Transform nextLocation;

    private Vector3 movementDirection;
    public float rotationSpeed = 120;

    [Tooltip("Drone's speed")]
    public float droneSpeed = 5;

    [Header("Drone Inputs")]
    [Tooltip("Drone's launch input")]
    [SerializeField]
    private InputActionReference launchInput;
    private bool isLaunched = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLaunched)
        {
            MoveDrone();   
        }
    }

    private void MoveDrone() 
    {
        if (nextLocation == null)
        {
            nextLocation = location[0];
        }
        else if (transform.position == nextLocation.position)
        {
            int index = location.IndexOf(nextLocation);
            if (index == location.Count - 1)
            {
                // Drone on saapunut viimeiseen waypointtiinsa listassa ja se pyshähtyy
                droneSpeed = 0;

                //// Drone palaa takaisin ensimmäiseen waypointtiin
                //nextLocation = location[0];

            }
            else
            {
                // Seuraavan waypointin indexi listasta
                nextLocation = location[index + 1];
            }
        }
        // Liikuttaa Dronea waypointista toiseen
        transform.position = Vector3.MoveTowards(transform.position, nextLocation.position, droneSpeed * Time.deltaTime);

    }

    private void OnEnable()
    {
        launchInput.action.performed += LaunchDrone;
    }

    private void OnDisable()
    {
        launchInput.action.performed -= LaunchDrone;
    }

    private void LaunchDrone(InputAction.CallbackContext context)
    {
        isLaunched = true;
    }

}
