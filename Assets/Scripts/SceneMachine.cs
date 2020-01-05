using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMachine : MonoBehaviour
{
    int currentSceneIndex; // Holds current scene index

    void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Assigns current scene index to variable  
    }

    // Loads the next scene on the index
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Loads the main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    // Closes the application
    public void CloseGame()
    {
        Application.Quit();
    }
}
