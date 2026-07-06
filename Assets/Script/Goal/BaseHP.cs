using System;
using UnityEngine;

public class BaseHP : MonoBehaviour
{
    //var to use the defeatCanvas
    [SerializeField] public GameObject defeatCanvas;
    //var to use the victoryCanvas
    [SerializeField] public GameObject victoryCanvas;
    
    //var to keep the Hp of the base
    [SerializeField] public int baseHP = 100;
    
    // var to get ref to the "Spawner" script
    [SerializeField] [HideInInspector] private Spawner spawnerRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //get ref to the script "Spawner"
        spawnerRef = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //if baseHP inferior or equal to 0
        if (baseHP <= 0)
        {
            //activate the defeatCanvas gameObject
            defeatCanvas.SetActive(true);
        }

        //if baseHP superior to 0 and all enemies are eliminated (inferior or equal to 0)
        if (baseHP > 0 && spawnerRef.totalNumberOfEnemies <= 0)
        {
            //activate the victoryCanvas gameObject
            victoryCanvas.SetActive(true);
        }
    }
}
