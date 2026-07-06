using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private List<Transform> explosionTargets; 
    [SerializeField] private string tag= "Enemies";
    [SerializeField] private float explosionRange = 8f;
    [SerializeField] private int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= explosionRange)
            {
                explosionTargets.Add(enemy.transform);
            }
        }
        foreach (Transform enemy in explosionTargets)
        {
            Enemy_HP enemyHP = enemy.GetComponent<Enemy_HP>();  // Use currentTarget
            if (enemyHP != null)
            {
                // Apply damage to the enemy's health
                enemyHP.health -= damage;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
    
}
