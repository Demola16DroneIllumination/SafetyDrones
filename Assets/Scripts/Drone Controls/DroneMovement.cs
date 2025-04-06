using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;


public class DroneMovement : MonoBehaviour
{
    [Header("Drone Settings")]
    [Tooltip("Drone's flight path positions")]
    public List<Transform> destination = new() { null };
    public List<Transform> location = new() { null};
    public List<Transform> location2 = new() { null };

    [SerializeField]
    private Transform nextLocation;

   // private Vector3 movementDirection;
    public float rotationSpeed = 120;

    public int situation = 0; // 0 = DroneCase1, 1 = DroneCase2, 2 = DroneCase3

    [Tooltip("Drone's speed")]
    public float droneSpeed = 5;

    [Header("Drone Rotation")]
    [Tooltip("Drone's final rotation")]
    [SerializeField]
    private float rotationX, rotationY, rotationZ = 0;

    [Header("Drone Inputs")]
    [Tooltip("Drone's launch input")]
    [SerializeField]
    private InputActionReference launchInput;
    private bool isLaunched = false;

    [SerializeField]
    private Transform DronePart;
    private bool finalDestination = false;

    private float flightRotation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (situation)
        {
            case 0:
                DroneCase1();
                Debug.Log("DroneCase1 is active.");
                break;
            case 1:
                DroneCase2();
                Debug.Log("DroneCase2 is active");
                break;
            case 2:
                //DroneCase3();
                Debug.Log("DroneCase3 is not implemented yet.");
                break;
            default:
                Debug.LogError("Invalid situation value: " + situation);
                break;
        }

        if (isLaunched)
        {
            MoveDrone();
        }

    }

    private void MoveDrone() 
    {
        if (nextLocation == null)
        {
            nextLocation = destination[0];
        }
        else if (transform.position == nextLocation.position)
        {
            int index = destination.IndexOf(nextLocation);
            if (index == destination.Count - 1)
            {
                // Drone on saapunut viimeiseen waypointtiinsa listassa ja se pysh‰htyy
                droneSpeed = 0;
                
                if (!finalDestination)
                {
                    // Drone k‰‰ntyy haluttuun suuntaan lennon j‰lkeen
                    DronePart.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
                    
                    //StartCoroutine(ResetScene(10f));
                    DroneNumber();
                    finalDestination = true;
                }
                //// Drone palaa takaisin ensimm‰iseen waypointtiin
                //nextLocation = location[0];
            }
            else
            {
                // Seuraavan waypointin indexi listasta
                nextLocation = destination[index + 1];

                // Drone k‰‰ntyy haluttuun suuntaan lennon j‰lkeen
                flightRotation = nextLocation.position.z;
                DronePart.rotation = Quaternion.Euler(-90, 0, -flightRotation);
            }
        }
        // Liikuttaa Dronea waypointista toiseen
        transform.position = Vector3.MoveTowards(transform.position, nextLocation.position, droneSpeed * Time.deltaTime);
    }

    private void DroneCase1() 
    { 
        destination = location;
        // Drone k‰‰ntyy haluttuun suuntaan lennon j‰lkeen
        rotationX = -90;
        rotationY = 0;
        rotationZ = 0;
    }

    private void DroneCase2()
    {
        destination = location2;
        // Drone k‰‰ntyy haluttuun suuntaan lennon j‰lkeen
        rotationX = -90;
        rotationY = 0;
        rotationZ = 0;
        //flightRotation = Vector3.SignedAngle(transform.forward, nextLocation.position, Vector3.up);
    }

    IEnumerator ResetScene(float seconds)
    {
        Debug.Log("Resetting scene in " + seconds + " seconds...");
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DroneNumber()
    {
        Collider col = GetComponent<Collider>();
        string colliderName = col.name;

        if (colliderName == "Drone")
        {
            StartCoroutine(ResetScene(10f));
        }
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
