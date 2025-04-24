using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreaSpecificCamerasSript : MonoBehaviour
{
    public CameraChangeScript cameraChangeScript;
    public int currentArea = 0;
    public int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private List<int[]> cameraArrayList = new List<int[]>();

    //private int[] noArea;
    public int[] area1Cameras;
    public int[] area2Cameras;
    public int[] area3Cameras;
    public int[] area4Cameras;
    void Start()
    {
        //cameraArrayList.Append(noArea);
        //cameraArrayList.Append(area1Cameras);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentArea != 0 && Input.GetKeyDown(KeyCode.LeftControl) == true)
        {
          int[] currentAreaCameraList = getAreaCameraList(currentArea);
          rotateCameraNext(currentAreaCameraList);
                    
         }
        else if(currentArea != 0 && Input.GetKeyDown(KeyCode.LeftShift) == true)
        {
            int[] currentAreaCameraList = getAreaCameraList(currentArea);
            rotateCameraPrevious(currentAreaCameraList);
        }


    }


    void rotateCameraNext(int[] list)
    {
        //if (currentIndex < camList.Count - 1)
        if (currentIndex < list.Length-1)
        {
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
        }

        //EnableCamera(currentIndex);
        cameraChangeScript.EnableCamera(list[currentIndex]);
    }

    void rotateCameraPrevious(int[] list)
    {
        //if (currentIndex < camList.Count - 1)
        if (currentIndex > 0)
        {
            currentIndex--;
        }
        else
        {
            currentIndex = list.Length - 1;
        }

        //EnableCamera(currentIndex);
        cameraChangeScript.EnableCamera(list[currentIndex]);
    }
    int[] getAreaCameraList(int areaIndex)
    {
        if (areaIndex == 1)
        {
            return area1Cameras;
        }
        if (areaIndex == 2)
        {
            return area2Cameras;
        }
        if (areaIndex == 3)
        {
            return area3Cameras;
        }
        if (areaIndex == 4)
        {
            return area4Cameras;
        }
        else
        {
            return null;
        }
    }

    public void ChangeAreaTo(int areaIndex)
    {
        currentArea = areaIndex;
        currentIndex = 0;

        int[] currentAreaCameraList = getAreaCameraList(currentArea);
        cameraChangeScript.EnableCamera(currentAreaCameraList[currentIndex]);
    }
}
