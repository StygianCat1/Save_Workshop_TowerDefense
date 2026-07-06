using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //gameObject ref to Canvas that manage the Pause
    [SerializeField] private GameObject pauseMenu;

    //ref to the script "OpenPause"
    private OpenPause openPause;
    
    //ref to the Camera-CTRL
    private GameObject cameraRef;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find the gameObject in scene that have the tag 'CameraSupport'
        cameraRef = GameObject.FindGameObjectWithTag("CameraSupport");
        //find in gameObject the script "OpenPause"
        openPause = cameraRef.GetComponent<OpenPause>();
        //set the var as the gameObject
        pauseMenu = gameObject;
    }
    
    
    //function that resume the game
    public void Resume()
    {
        //set the var 'isPaused' in the script "OpenPause" to false
        openPause.isPaused = false;
        //deactivate the GameObject
        print("pause");
        pauseMenu.SetActive(false);
        //set back the time to normal
        Time.timeScale = 1f;
    }
    
    
    //function to go back to the game Main menu
    public void OpenMainMenu()
    {
        //open/load the scene named "MainMenu_Scene"
        SceneManager.LoadSceneAsync("MainMenu_Scene");
    }

    
    //function to quit the game
    public void QuitGame()
    {
        //quit the application
        Application.Quit();
    }
}
