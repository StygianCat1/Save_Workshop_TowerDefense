using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOnDeath_Behavior : MonoBehaviour
{
    //get ref to enemy it will spawn
    [SerializeField] Enemy[] enemies;
    
    
    //activate when gameObject is destroyed
    void OnDestroy()
    {
        //during the enemy list
        for (int i = 0; i < enemies.Length; i++)
        {
            //instantiate the enemy to gameObject position
            Instantiate(enemies[i], transform.position, Quaternion.identity);
        }
    }
}
