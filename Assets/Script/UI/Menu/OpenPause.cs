using UnityEngine;
using UnityEngine.InputSystem;


public class OpenPause : MonoBehaviour
{
    //gameObject ref to Canvas that manage the Pause
    [SerializeField] GameObject pauseMenu;
    
    //var that verify if the game is paused
    [HideInInspector] public bool isPaused = false;


    //function that manage if the game is stopped or not
    void OnPauseGame()
    {
        //if 'isPaused' is true
        if (isPaused)
        {
            //activate the function 'Resume'
            Resume();
        }
        //if 'isPaused' is false
        else
        {
            //activate the function 'Pause'
            Pause();
        }
    }
    
    
    //function that resume the game
    public void Resume()
    {
        //deactivate the GameObject
        pauseMenu.SetActive(false);
        //set back the time to normal
        Time.timeScale = 1f;
        //set var 'isPaused' to false
        isPaused = false;
    }
    
    
    //function that manage stops the game
    public void Pause()
    {
        //activate the GameObject
        pauseMenu.SetActive(true);
        //set back the time to stopping 
        Time.timeScale = 0f;
        //set var 'isPaused' to true
        isPaused = true;

    }
}
