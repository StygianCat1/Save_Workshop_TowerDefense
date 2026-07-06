using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower6 : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;  
    [SerializeField] private float turretRange = 15f;  
    [SerializeField] public float firerate = 1f;  
    [SerializeField] private float firecountdown = 0f;  
    [SerializeField] private int damageAmount = 10;  
    [SerializeField] public string EnemiesTag = "Enemies";
    [SerializeField] public int resellPrice = 300;
    [SerializeField] public int upgradePricegoldlvl2 = 150;
    [SerializeField] public int upgradePricescraplvl2 = 8;
    [SerializeField] public int upgradePricegoldlvl3 = 240;
    [SerializeField] public int upgradePricescraplvl3 = 15;
    
    [SerializeField] private GameObject VFX_Spark;
    
    [SerializeField] public GameObject nextTower;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);  
    }

    private void Update()
    {
        if (targets == null)  
        {
            return;
        }

        
        if (firecountdown <= 0)
        {
            //VFX_Spark.SetActive(false);
            //VFX_Spark.SetActive(true);
            DamageTarget();
            firecountdown = firerate;  // ??? pourquoi faire ça 
        }
        firecountdown -= Time.deltaTime;  // Decrease the countdown every frame
    }

    private void UpdateTarget()
    {
        targets.Clear();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemiesTag);
        // Find the closest enemy within range
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= turretRange)
            {
                targets.Add(enemy.transform);
            }
        }
    }

    private void DamageTarget()
    {
        if (targets != null)  // Use currentTarget instead of target
        {
            // Try to get the Enemy_HP component from the target
            foreach (Transform target in targets)
            {
                Enemy_HP enemyHP = target.GetComponent<Enemy_HP>();  // Use currentTarget
                if (enemyHP != null)
                {
                    // Apply damage to the enemy's health
                    enemyHP.health -= damageAmount;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRange);  // Draw the range in the scene view, using turretRange
    }
}
