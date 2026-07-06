using UnityEngine;
using UnityEngine.SceneManagement;
public class EndMenu : MonoBehaviour
{
    //create private string to keep the name of the scene
    public string sceneName;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the name of the scene that is currently active
        sceneName = SceneManager.GetActiveScene().name;
    }

    //function to start again the game
    public void PlayAgain()
    {
        //open the scene that is active
        SceneManager.LoadScene(sceneName);
    }

    //function to go back to the main menu
    public void MainMenu()
    {
        // open the scene to the "MainMenu_scene"
        SceneManager.LoadScene(0);
    }
}
