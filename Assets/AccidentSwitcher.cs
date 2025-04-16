using UnityEngine;

public class AccidentSwitcher : MonoBehaviour
{
    public GameObject[] AccidentAreas;

    public void ShowAccident(int index)
    {
        for (int i = 0; i < AccidentAreas.Length; i++)
        {
            AccidentAreas[i].SetActive(i == index);
        }
    }
}
