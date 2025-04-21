using UnityEngine;

public class AccidentSwitcher : MonoBehaviour
{
    public GameObject[] AccidentAreas; // Array of accident areas
    public GameObject[] SignObjects;  // Array of 8 objects with DroneScreenController components

    void Start()
    {
        // Initialize all accident areas to inactive
        for (int i = 0; i < AccidentAreas.Length; i++)
        {
            AccidentAreas[i].SetActive(false);
        }
    }

    public void ShowAccident(int index)
    {
        // Activate the selected accident area and deactivate others
        for (int i = 0; i < AccidentAreas.Length; i++)
        {
            AccidentAreas[i].SetActive(i == index);
        }

        // Call the corresponding Area function based on the index
        switch (index)
        {
            case 0:
                Area1();
                break;
            case 1:
                Area2();
                break;
            case 2:
                Area3();
                break;
            case 3:
                Area4();
                break;
            default:
                Debug.LogWarning("Invalid area index");
                break;
        }
    }

    // Area1 function
    public void Area1()
    {
        if (SignObjects.Length != 8) return; // Ensure there are exactly 8 objects

        SignObjects[0].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[1].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[2].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[3].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[4].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[5].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[6].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[7].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
    }

    // Area2 function
    public void Area2()
    {
        if (SignObjects.Length != 8) return;

        SignObjects[0].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[1].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[2].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[3].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[4].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[5].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[6].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[7].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
    }

    // Area3 function
    public void Area3()
    {
        if (SignObjects.Length != 8) return;

        SignObjects[0].GetComponent<DroneScreenController>()?.SetScreenTexture(3);
        SignObjects[1].GetComponent<DroneScreenController>()?.SetScreenTexture(3);
        SignObjects[2].GetComponent<DroneScreenController>()?.SetScreenTexture(3);
        SignObjects[3].GetComponent<DroneScreenController>()?.SetScreenTexture(3);
        SignObjects[4].GetComponent<DroneScreenController>()?.SetScreenTexture(3);
        SignObjects[5].GetComponent<DroneScreenController>()?.SetScreenTexture(3);
        SignObjects[6].GetComponent<DroneScreenController>()?.SetScreenTexture(3);
        SignObjects[7].GetComponent<DroneScreenController>()?.SetScreenTexture(3);
    }

    // Area4 function
    public void Area4()
    {
        if (SignObjects.Length != 8) return;

        SignObjects[0].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[1].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[2].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[3].GetComponent<DroneScreenController>()?.SetScreenTexture(2);
        SignObjects[4].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[5].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[6].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
        SignObjects[7].GetComponent<DroneScreenController>()?.SetScreenTexture(0);
    }
}
