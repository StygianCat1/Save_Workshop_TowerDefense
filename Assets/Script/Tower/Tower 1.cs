using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tower1 : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range = 15f;
    [SerializeField] public float firerate =1f;
    [SerializeField] private float firecountdown = 0f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] public string EnemiesTag = "Enemies";
    [SerializeField] public Transform partRotate;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] public int resellPrice = 150;
    [SerializeField] public int upgradePricegoldlvl2 = 75;
    [SerializeField] public int upgradePricescraplvl2 = 0;
    [SerializeField] public int upgradePricegoldlvl3 = 120;
    [SerializeField] public int upgradePricescraplvl3 = 7;
    
    [SerializeField] private GameObject VFX_Spark;


    [SerializeField] public GameObject nextTower;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      InvokeRepeating("UpdateTarget", 0f, 0.5f);  
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {

            return;

        }
        
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        partRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
        
        
        if (firecountdown <= 0)
        {
            //VFX_Spark.SetActive(false);
            //VFX_Spark.SetActive(true);
            Shoot();
            firecountdown = firerate;
        }
        
        firecountdown -= Time.deltaTime;
        
        
    }

    void UpdateTarget()
    {

        GameObject[] Enemies = GameObject.FindGameObjectsWithTag(EnemiesTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in Enemies)
        {
            //float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            float distanceToEnemy = Vector3.Distance(new Vector3(transform.position.x, 0 , transform.position.z),new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z));
            
            if (distanceToEnemy < shortestDistance)
            {

                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }
        }

        if(nearestEnemy !=null && shortestDistance <= range)
        {
            
            target = nearestEnemy.transform;
            
        }
        else
        {
            
            target = null;
            
        }
    }
    
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }


    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
            
            if(bullet != null)
        {
            
            bullet.Seek(target);
            
        }
        
    }
}
