using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class RestartGameScene : MonoBehaviour
{
    [SerializeField]
    private InputActionReference restartGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        restartGame.action.performed += RestartScene;
    }

    private void OnDisable()
    {
        restartGame.action.performed -= RestartScene;
    }

    private void RestartScene(InputAction.CallbackContext context)
    {
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
