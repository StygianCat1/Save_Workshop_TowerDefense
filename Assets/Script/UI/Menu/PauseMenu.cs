using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseMenu : MonoBehaviour
{
    //var to get GameObject that will be the pauseMenu cancas
    [SerializeField] public GameObject pauseMenu;
    
    //var to verify if the game is paused 
    [SerializeField] public static bool isPaused = false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if pause menu is active
        if (pauseMenu.activeSelf)
        {
            //make the pause menu unactive
            pauseMenu.SetActive(false);
            //set the time scale to normal
            Time.timeScale = 1f;
        }
    }
    
    
    void OnPauseGame()
    {
        //if game is paused
        if (isPaused)
        {
            //can resume the game
            Resume();
        }
        else
        {
            //can pause the game
            Pause();
        }
    }

    
    public void Resume()
    {
        //set the GameObject to inactive
        pauseMenu.SetActive(false);
        //set time scale to normal
        Time.timeScale = 1f;
        //set is paused to false
        isPaused = false;
    }

    
    public void Pause()
    {
        //set the GameObject to active
        pauseMenu.SetActive(true);
        //set time scale to stop
        Time.timeScale = 0f;
        //set is paused to true
        isPaused = true;
    }
    
    
    public void OpenMainMenu()
    {
        //load scene MainMenu scene
        SceneManager.LoadSceneAsync("MainMenu_Scene");
    }

    
    public void QuitGame()
    {
        //quit the application
        Application.Quit();
    }

    

}
