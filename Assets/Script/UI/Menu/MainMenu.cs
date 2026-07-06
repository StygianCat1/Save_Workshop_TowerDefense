using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //open scene named "Scene_Test_Script" (only if the scene is in the build settings)
        SceneManager.LoadSceneAsync(1);
        //reset Time to normal 
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        //close application
        Application.Quit();
    }
}
