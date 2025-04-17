using UnityEngine;

public class AccidentSwitcher : MonoBehaviour
{
    void Start()
    {
        // Initialize all accident areas to inactive
        for (int i = 0; i < AccidentAreas.Length; i++)
        {
            AccidentAreas[i].SetActive(false);
        }
    }
    public GameObject[] AccidentAreas;

    public void ShowAccident(int index)
    {
        for (int i = 0; i < AccidentAreas.Length; i++)
        {
            AccidentAreas[i].SetActive(i == index);
        }
    }
}
