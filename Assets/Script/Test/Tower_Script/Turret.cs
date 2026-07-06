using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
   [SerializeField] private float range = 15f;

    public string enemyTag = "enemy";

    public Transform partToRotate;

    [SerializeField] private float turnSpeed = 10f; 

    public float fireRate = 1f;
    [SerializeField] private float fireCountdown = 0f;

    public GameObject bullet;
    public Transform firepoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void UpdateTarget()
    {
        
        Debug.Log("Targeting");

        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy; 
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        

        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }


        fireCountdown -= Time.deltaTime;
         
    }
          void Shoot()
          {
             GameObject bulletGO = (GameObject)Instantiate(bullet, firepoint.position, firepoint.rotation);
             Bullet bullette = bulletGO.GetComponent<Bullet>();

              if (bullette != null)
              {
                  bullette.Seek(target);
 
              }

              Debug.Log("Tir");

 
          }

    private void OnDrawGizmosSelected()
        {
           Gizmos.DrawWireSphere(transform.position, range);
        }


    
}