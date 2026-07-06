using System;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] public float firerate = 1f;
    [SerializeField] private float firecountdown = 0f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] public string EnemiesTag = "Enemies";
    [SerializeField] private float chainRange = 10f; // Range for chaining damage to next enemies
    [SerializeField] private int chainCount = 2;
    [SerializeField] private int towerRange = 15;// Number of enemies to chain the attack to
    [SerializeField] public int resellPrice = 600;
    [SerializeField] public int upgradePricegoldlvl2 = 300;
    [SerializeField] public int upgradePricescraplvl2 = 15;
    [SerializeField] public int upgradePricegoldlvl3 = 480;
    [SerializeField] public int upgradePricescraplvl3 = 30;
    
    [SerializeField] private GameObject VFX_Spark;
    
    [SerializeField] public GameObject nextTower;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        // Fire if countdown has expired
        if (firecountdown <= 0)
        {
            //VFX_Spark.SetActive(false);
            //VFX_Spark.SetActive(true);
            Shoot();
            firecountdown =  firerate;
        }

        firecountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemiesTag);
        //float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // Find the nearest enemy
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < towerRange)
            {
                //shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // Set the target to the nearest enemy
        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        ChainBullet bullet = bulletGO.GetComponent<ChainBullet>();

        if (bullet != null && target != null)
        {
            bullet.Initialize(target, chainCount, chainRange, 10, EnemiesTag);
        }
    }

    void ChainAttack(Transform firstTarget)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemiesTag);
        Transform currentTarget = firstTarget;

        for (int i = 0; i < chainCount; i++)
        {
            GameObject nextTarget = FindNextTarget(currentTarget);
            if (nextTarget != null)
            {
                // Create a new bullet to attack the next enemy
                GameObject bulletGO = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                Bullet bullet = bulletGO.GetComponent<Bullet>();

                if (bullet != null)
                {
                    bullet.Seek(nextTarget.transform);
                }

                currentTarget = nextTarget.transform; // Move to the next target for chaining
            }
            else
            {
                break; // Stop if no more enemies are found
            }
        }
    }

    GameObject FindNextTarget(Transform currentTarget)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemiesTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform == currentTarget) continue;  // Skip the current target

            float distanceToEnemy = Vector3.Distance(currentTarget.position, enemy.transform.position);
            if (distanceToEnemy <= chainRange && distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, towerRange); // Visualize tower range
    }
}