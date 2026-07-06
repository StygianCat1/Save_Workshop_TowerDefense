using UnityEngine;
using TMPro;
using UnityEngine.ProBuilder;

public class Timer_GUI : MonoBehaviour
{
    [SerializeField] private GameObject timerObject;
    //var to show the timer
    [SerializeField] public TMP_Text textUI_Timer;
    
    //var to get "Spawner"
    [SerializeField] [HideInInspector] private Spawner spawner;
    
    //var to change in string the countdown int
    [SerializeField] [HideInInspector] private string timerString;
    //float var to round / change the countdown shown in the game scene
    [SerializeField] [HideInInspector]private float timerValueDecimal;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ref to the component "Spawner" script in "Spawner
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //round up to the 0.1 the countdown
        timerValueDecimal = Mathf.Round(spawner.countdown * 10f) / 10f;
        //change the round countdown to a string
        timerString = timerValueDecimal.ToString();
        //set the string as the text
        textUI_Timer.text = timerString;

        if (spawner.knownWave >= spawner.waves.Length)
        {
            if (spawner.countdown <= 0)
            {
                timerObject.SetActive(false);
            }
        }
    }
}
