using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DroneMovement : MonoBehaviour
{    
    private List<Transform> location = new();
    [Header("Drone Settings")]


    [Tooltip("Waypoint Set 1")]
    public List<Transform> waypointSet1 = new();

    [Tooltip("Waypoint Set 2")]
    public List<Transform> waypointSet2 = new();

    [Tooltip("Waypoint Set 3")]
    public List<Transform> waypointSet3 = new();

    [Tooltip("Waypoint Set 4")]
    public List<Transform> waypointSet4 = new();

    [Tooltip("Home Point")]
    public List<Transform> homepoint = new();

    private Transform nextLocation;

    public float rotationSpeed = 120;

    [Tooltip("Drone's speed")]
    public float droneSpeed = 5;

    private bool isLaunched = false;

    [SerializeField]
    private Transform DronePart;
    private bool finalDestination = false;

    private CarAIController carAIController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carAIController = GameObject.Find("CarAIController").GetComponent<CarAIController>();
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
            DronePart.rotation = Quaternion.Euler(-90,-90, 0);
        }
        else if (transform.position == nextLocation.position)
        {
            int index = location.IndexOf(nextLocation);
            if (index == location.Count - 1)
            {
                // Drone on saapunut viimeiseen waypointtiinsa listassa ja se pysh�htyy
                droneSpeed = 0;

                if (!finalDestination)
                {
                    // Drone k��ntyy 90astetta waypointtiin
                    DronePart.rotation = Quaternion.Euler(-90, 0, 0);
                    finalDestination = true;

                }

                //// Drone palaa takaisin ensimm�iseen waypointtiin
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

    public void LaunchDrone()
    {
        isLaunched = true;
    }

    public void SetWaypointSet(int setNumber)
    {
        if (setNumber == 1)
        {
            location = new List<Transform>(waypointSet1);
        }
        else if (setNumber == 2)
        {
            location = new List<Transform>(waypointSet2);
        }
        else if (setNumber == 3)
        {
            location = new List<Transform>(waypointSet3);
        }
        else if (setNumber == 4)
        {
            location = new List<Transform>(waypointSet4);
        }
        else if (setNumber == 0)
        {
            location = new List<Transform>(homepoint);
        }
        else
        {
            Debug.LogError("Invalid waypoint set number: " + setNumber);
            return;
        }
    }
}
