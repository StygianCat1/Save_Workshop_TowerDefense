using System.Collections;
using UnityEngine;

public class SmallBoostOnSpawn_Behavior : MonoBehaviour
{
    //ref to the the script "Enemy_movement"
    [SerializeField] Enemy_movement enemyMovement;
    
    //speed boosted
    [SerializeField] float boostSpeed = 4.0f;
    //time before boost
    [SerializeField] float timeBeforeSmallBoost = 2.0f;
    //Duration of the boost
    [SerializeField] float boostingDuration = 3.0f;
    
    //var to keep the old speed
    private float oldBoostSpeed;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the gameObject Enemy_movement script
        enemyMovement = gameObject.GetComponent<Enemy_movement>();
        //Start the Coroutine boost
        StartCoroutine("Boost");
        //keep the old boost speed in the var
        oldBoostSpeed = enemyMovement.enemySpeed;
    }

    
    //Boost Coroutine 
    private IEnumerator Boost()
    {
        //Wait time after spawn
        yield return new WaitForSeconds(timeBeforeSmallBoost);
        //change boost speed 
        enemyMovement.enemySpeed = boostSpeed;
        //time before canceling the speed boost
        yield return new WaitForSeconds(boostingDuration);
        //change boost speed to old value
        enemyMovement.enemySpeed = oldBoostSpeed;
    }
}

