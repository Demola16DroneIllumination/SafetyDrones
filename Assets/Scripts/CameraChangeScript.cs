using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public Camera camCar1;
    //public Camera camCar2;

    //public Camera camDrone1;

    public List<Camera> camList;
    public int currentIndex = 0;
    public bool autoCameraEnabled = true;
    void Start()
    {

        //camList.Add(camCar1);
        //camList.Add(camCar2);
        //camList.Add(camDrone1);


        //camCar1.enabled = true;
        //camDrone1.enabled = false;
        EnableCamera(currentIndex);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) == true)
        {
            RotateCameraList();
            //camCar1.enabled = !camCar1.enabled;
            //camDrone1.enabled = !camDrone1.enabled;



        }
    }

    public void EnableCamera(int index)
    {
        
        for (int i = 0; i < camList.Count; i++)
        {
            camList[i].enabled = false;
        }

        camList[index].enabled = true;
        
    }

    void RotateCameraList()
    {
        
        if (currentIndex < camList.Count - 1)
        {
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
        }

        EnableCamera(currentIndex);
    }

}
