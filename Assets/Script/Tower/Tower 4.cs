using System.Collections;
using UnityEngine;


public class Tower4 : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range = 15f;
    [SerializeField] public float firerate = 1f;
    [SerializeField] private float firecountdown = 0f;
    [SerializeField] public string EnemiesTag = "Enemies";
    [SerializeField] public string EnemiesTag2 = "Flying";
    [SerializeField] public Transform partRotate;
    [SerializeField] private Transform firepoint;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] public GameObject Laser;
    [SerializeField] public int resellPrice = 600;
    [SerializeField] public int upgradePricegoldlvl2 = 300;
    [SerializeField] public int upgradePricescraplvl2 = 15;
    [SerializeField] public int upgradePricegoldlvl3 = 480;
    [SerializeField] public int upgradePricescraplvl3 = 30;
    
    [SerializeField] public GameObject nextTower;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        if (Laser != null)
            Laser.SetActive(false);

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
        Vector3 rotation = Quaternion.Lerp(partRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);



        if (firecountdown <= 0)
        {
            
            Shoot();
            firecountdown = firerate;
        }

        firecountdown -= Time.deltaTime;

    }

    void UpdateTarget()
    {

        GameObject[] Enemies = GameObject.FindGameObjectsWithTag(EnemiesTag);
        GameObject[] FlyingEnemies = GameObject.FindGameObjectsWithTag(EnemiesTag2);
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

        foreach (GameObject flyingEnemy in FlyingEnemies)
        {
            //float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            float distanceToEnemy = Vector3.Distance(new Vector3(transform.position.x, 0 , transform.position.z),new Vector3(flyingEnemy.transform.position.x, 0, flyingEnemy.transform.position.z));

            if (distanceToEnemy < shortestDistance)
            {

                shortestDistance = distanceToEnemy;
                nearestEnemy = flyingEnemy;
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

    void Shoot()
    {
        if (Laser != null && target != null)
        {
           
            Laser.SetActive(true);

            
            StartCoroutine(DeactivateLaser());
        }
    }


    private IEnumerator DeactivateLaser()
    {
        yield return new WaitForSeconds(0.2f);
        if (Laser != null)
        {
            Laser.SetActive(false);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
