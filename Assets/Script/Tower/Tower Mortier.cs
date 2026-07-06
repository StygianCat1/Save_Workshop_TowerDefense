using System;
using UnityEngine;

public class TowerMortier : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range = 15f;
    [SerializeField] public float firerate =1f;
    [SerializeField] float firecountdown = 0f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] public string EnemiesTag = "Enemies";
    [SerializeField] public Transform partRotate;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] public int resellPrice = 300;
    [SerializeField] public int upgradePricegoldlvl2 = 150;
    [SerializeField] public int upgradePricescraplvl2 = 8;
    [SerializeField] public int upgradePricegoldlvl3 = 240;
    [SerializeField] public int upgradePricescraplvl3 = 15;
    
    [SerializeField] private GameObject VFX_Spark;
    
    [SerializeField] public GameObject nextTower;

    Rigidbody rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] public float forceBullet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      InvokeRepeating("UpdateTarget", 0f, 0.5f);  
      
      
      rb = GetComponent<Rigidbody>();
      
    }
    
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return; 
        }
        
        //Vector3 direction = target.position - transform.position;
        Vector3 direction = new Vector3(target.position.x, target.position.y + 20, target.position.z);
        partRotate.LookAt(direction);
        //Quaternion lookRotation = Quaternion.LookRotation(direction, new Vector3(0, direction.y + 40, 0));
        //Vector3 rotation = Quaternion.Lerp(partRotate.rotation, new Quaternion(lookRotation.x, lookRotation.y, lookRotation.z + 1, lookRotation.w), Time.deltaTime*turnSpeed).eulerAngles;
        //Vector3 rotation = Quaternion.Lerp(partRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        //partRotate.rotation = Quaternion.Euler(41f, rotation.y, 2f);
        
        if (firecountdown <= 0)
        {
            //VFX_Spark.SetActive(false);
            //VFX_Spark.SetActive(true);
            AddForceBullet();
            //Shoot();
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
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            
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


    void AddForceBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.transform.position, firepoint.transform.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(firepoint.transform.forward * forceBullet);
        Destroy(bullet, 5f);
    }
    
}