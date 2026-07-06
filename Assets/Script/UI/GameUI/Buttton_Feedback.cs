using UnityEngine;
using UnityEngine.EventSystems;

public class Buttton_Feedback : MonoBehaviour
{

    [SerializeField] private GameObject tower1Resume;
    [SerializeField] private GameObject tower2Resume;
    [SerializeField] private GameObject tower3Resume;
    [SerializeField] private GameObject tower4Resume;
    [SerializeField] private GameObject tower5Resume;
    [SerializeField] private GameObject tower6Resume;
    [SerializeField] private GameObject overchargeResume;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void EnterPointer(int number)
    {
        if (number == 0)
        {
            tower1Resume.SetActive(true);
        }
        else if (number == 1)
        {
            tower2Resume.SetActive(true);
        }
        else if (number == 2)
        {
            tower3Resume.SetActive(true);
        }
        else if (number == 3)
        {
            tower4Resume.SetActive(true);
        }
        else if (number == 4)
        {
            tower5Resume.SetActive(true);
        }
        else if (number == 5)
        {
            tower6Resume.SetActive(true);
        }        
        else if (number == 6)
        {
            overchargeResume.SetActive(true);
        }
    }
    
    public void ExitPointer(int number)
    {
        if (number == 0)
        {
            tower1Resume.SetActive(false);
        }
        else if (number == 1)
        {
            tower2Resume.SetActive(false);
        }
        else if (number == 2)
        {
            tower3Resume.SetActive(false);
        }
        else if (number == 3)
        {
            tower4Resume.SetActive(false);
        }
        else if (number == 4)
        {
            tower5Resume.SetActive(false);
        }
        else if (number == 5)
        {
            tower6Resume.SetActive(false);
        }        
        else if (number == 6)
        {
            overchargeResume.SetActive(false);
        }
    }
}

