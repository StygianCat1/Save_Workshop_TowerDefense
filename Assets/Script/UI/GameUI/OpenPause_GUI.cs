using UnityEngine;

public class OpenPause_GUI : MonoBehaviour
{
    //ref to pausePanel
    [SerializeField] private GameObject pausePanel;
    //Ref to image pause du GUI
    [SerializeField] private GameObject imagePause;
    //Ref to image resume du GUI
    [SerializeField] private GameObject imageResume;
    
    //ref to the script "OpenPause"
    private OpenPause gamePaused;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get ref to the Component "OpenPause" script from the "GameraSupport" tag object
        gamePaused = GameObject.FindGameObjectWithTag("CameraSupport").GetComponent<OpenPause>();
    }

    // Update is called once per frame
    void Update()
    {
        //if 'isPaused' is true
        if (gamePaused.isPaused)
        {
            //change image for fashion :)
            imagePause.SetActive(false);
            //change image for fashion :)
            imageResume.SetActive(true);
        }
        //if 'isPaused' is false
        else
        {
            //change image for fashion :)
            imagePause.SetActive(true);
            //change image for fashion :)
            imageResume.SetActive(false);
        }
        
    }

    public void OpenPause()
    {
        //activate the GameObject
        pausePanel.SetActive(true);
        // set is paused to true
        gamePaused.isPaused = true;
        //set back the time to stopping 
        Time.timeScale = 0f;
    }
}
