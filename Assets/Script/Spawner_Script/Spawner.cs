using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //ref to the pubic class Wave 
    [SerializeField] public Wave[] waves;
    
    //a list of spawner
    [SerializeField] public List<GameObject> spawnPoint;
    
    [SerializeField] private Ressources ressources;
    
    [SerializeField] public List<int> mechanicScrapGained;
    
    //create a var that manage the countdown before the next wave
    [SerializeField] public float countdown;
    //var to get the number of enemies in total (used to know if the game is finished)
    [SerializeField] public float totalNumberOfEnemies = 0;
    
    //keep the index of the wave
    [HideInInspector] [SerializeField] public int waveIndex = 0;
    
    //var that will be used in the UI to let the player know what wave it is
    [HideInInspector] [SerializeField] public int knownWave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        ressources = GameObject.FindGameObjectWithTag("Base").GetComponent<Ressources>();
        //set knowWave to 0 for reset
        knownWave = 0;
        //for all the wave
        for (int i = 0; i < waves.Length; i++)
        {
            //add the total of all the enemies in the waves
            totalNumberOfEnemies += waves[i].enemies.Length;
        }
    }
    
    
    // Update is called once per frame
    private void Update()
    {
        //check the index of the wave and compare it with the length of the wave (the total number)
        if (waveIndex <= waves.Length)
        {
            //make the countdown
            countdown -= Time.deltaTime;

            //if countdown is equal or inferior  to 0
            if (countdown <= 0)
            {
                //add to countdown the time of the enemy spawn + the time before the next wave
                countdown = waves[waveIndex].timeToNextWave + waves[waveIndex].timeToNextEnemy * waves[waveIndex].enemies.Length;
                //Start the Coroutine SpawnWave
                StartCoroutine("SpawnWave");
            }
        }

        
        //check the index of the wave and compare it with the length of the wave (the total number)
        if (knownWave >= waves.Length)
        {

        }
    }



    //SpawnWave Coroutine 
    private IEnumerator SpawnWave()
    { 
        //check the index of the wave and compare it with the length of the wave (the total number)
        if (waveIndex < waves.Length)
        {
            //for the duration of the list of enemies in the wave 
            for (int i = 0; i < waves[waveIndex].enemies.Length; i++)
            {
                //create var enemy that spawn choosen enemies at a spawner position
                Enemy enemy = Instantiate(waves[waveIndex].enemies[i], spawnPoint[waveIndex].transform.position, Quaternion.identity);
    
                //make the enemies children of the gameObject they spawned from (useless but could be used later)
                enemy.transform.SetParent(spawnPoint[waveIndex].transform);

                //time waiting before spawning next enemy
                yield return new WaitForSeconds(waves[waveIndex].timeToNextEnemy);
            }
        }
        //increment wave index
        waveIndex++;
        //wait until the end of the wave
        yield return new WaitForSeconds(waves[waveIndex - 1].timeToNextWave);
        //increment knownWaveknownWave++;
        knownWave++;
        ressources.playerMechanicScrap += mechanicScrapGained[waveIndex - 1];
    }
}


//make the next public class and it's var Seriazable
[System.Serializable]
//create new public class named wave that will be used to control the enemy waves
public class Wave
{
    //list of enemy (can only add the gameObject with the Enemy script)
    public Enemy[] enemies;
    
    //duration before the next enemy spawn
    [SerializeField] public float timeToNextEnemy;

    //duration before the next wave begin
    [SerializeField] public float timeToNextWave;
}
