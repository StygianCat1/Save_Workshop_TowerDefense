using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wave_GUI : MonoBehaviour
{
    //ref to component "Spawner" 
    [SerializeField] private Spawner spawner;
    
    //var about the total number of wave in the level
    [SerializeField] private int totalNumberOfWaves = 15;
    
    //List of GameObject to show (wave image)
    [SerializeField] public List<GameObject> waveObjects;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //local variable string to get the gameObject 
        string waveString;
        //ref to component "Spawner" script in "Spawner"
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        //for the total number of wave
        for (int i = 1; i < totalNumberOfWaves + 1; i++)
        {
            //set wave string as "Wave_Icon_(number)
            waveString = "Wave_Icon_" + i.ToString();
            //add the wave string in the list of GameObject waveObjects
            waveObjects.Add(transform.Find(waveString).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //show the waveObjects GameObject corresponding to the knownWave
        waveObjects[spawner.knownWave].SetActive(true);
        //if the known wave is superior or equal to 1
        if (spawner.knownWave >= 1)
        {
            //remove the waveObjects GameObject corresponding to the knownWave - 1
            waveObjects[spawner.knownWave - 1].SetActive(false);
        }
    }
}
