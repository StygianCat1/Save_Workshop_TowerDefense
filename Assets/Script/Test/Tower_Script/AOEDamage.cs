using UnityEngine;

public class AOEDamage : MonoBehaviour 
{ 
 
   [SerializeField] private int aoeDamage = 10;
    public float range = 20f;
    public string enemyTag = "enemy";

//Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
         InvokeRepeating("damageTick", 0f, 0.2f);
    }

    void damageTick()
    {

    }

    bool IsEnemyInRange()
    {
         GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
         foreach (GameObject enemy in enemies)
         {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= range)
            {
               return true;
            }

         }
      return false;
    }
     // Update is called once per frame
       void Update()
       {
         if (IsEnemyInRange())
         {
            EnemiesInRange();
         }

       }


     void EnemiesInRange()
     {
        Debug.Log("enemy in range");
     }


     private void OnDrawGizmosSelected()
     {
       Gizmos.DrawWireSphere(transform.position, range);
     }
}

