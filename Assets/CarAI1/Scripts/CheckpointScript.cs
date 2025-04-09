using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [Tooltip("The speed limit applied to the ai when the car touches the checkpoint. If this value is -1 the script won't modify the speed limit of the car.")]
    public int speedLimit;

    [Tooltip("List of the next checkpoints. If you add more that one checkpoint, the ai will choose one randomly.")]
    public List<Transform> nextCheckpoints = new List<Transform> ();

    public List<Transform> alternativeCheckpoints = new List<Transform>();

    public bool blocked = false;

    void Awake()
    {

        for (int i = 0; i < nextCheckpoints.Count; i++)
        {
            if(nextCheckpoints[i] == null)
            {
                nextCheckpoints.RemoveAt(i);
            }
        }
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HideCheckpoints();

        for (int i = 0; i < nextCheckpoints.Count; i++)
        {
            if (nextCheckpoints[i] == null)
            {
                nextCheckpoints.RemoveAt(i);
                int index = Random.Range(0, alternativeCheckpoints.Count);
                nextCheckpoints.Add(alternativeCheckpoints[index]);
            }
        }
        
        CheckpointBlocked();

    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy this object if the collider name is "Stop"
        if (other.gameObject.name == "Stop")
        {
           blocked = true;
        }
            

        CarAIController controller = other.GetComponent<CarAIController>();

        if (controller && controller.nextCheckpoint.gameObject == transform.gameObject)
        {
            if(speedLimit != -1)
                controller.speedLimit = speedLimit;

            if(controller.taxiMode)
            {
                TaxiScript taxiScript = other.GetComponent<TaxiScript>();
                if(taxiScript)
                {
                    if(taxiScript.bestRoute[taxiScript.bestRoute.Count - 1] == transform)
                    {
                        controller.speedLimit = 0;
                    }
                    else
                    {
                        int index = taxiScript.bestRoute.IndexOf(transform);
                        controller.nextCheckpoint = taxiScript.bestRoute[index+1];
                    }
                }
            }
            else
            {
                int index = Random.Range(0, nextCheckpoints.Count);

                if (nextCheckpoints.Count > 0)
                {
                    controller.nextCheckpoint = nextCheckpoints[index];
                }
            }

        }
    }

    private void HideCheckpoints()
    {
        Renderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (alternativeCheckpoints.Count > 0)
        {
            for (int i = 0; i < alternativeCheckpoints.Count; i++)
            {
                Gizmos.DrawLine(transform.position, alternativeCheckpoints[i].position);
            }
        }

        for(int i=0; i < nextCheckpoints.Count; i++)
        {
            Gizmos.DrawLine(transform.position, nextCheckpoints[i].position);
        }
    }
#endif

    public void CheckpointBlocked()
    {
        if (blocked == true)
        {
            Destroy(gameObject);
        }
    }
}
