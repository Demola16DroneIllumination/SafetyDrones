using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitSimulation : MonoBehaviour
{
    [SerializeField]
    private InputActionReference quitGame;

    private void OnEnable()
    {
        quitGame.action.performed += quit;
    }

    private void OnDisable()
    {
        quitGame.action.performed -= quit;
    }

    private void quit(InputAction.CallbackContext context)
    {
        OnApplicationQuit();
    }

    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor  
#else
       Application.Quit(); // Quit the application  
#endif
    }
}
