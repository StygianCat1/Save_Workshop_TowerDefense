using UnityEngine;

public class ChainBullet : MonoBehaviour
{
    [SerializeField] [HideInInspector] private Transform target; // Current target to seek
    [SerializeField] [HideInInspector] private int chainCount = 0; // Remaining chain count
    [SerializeField] [HideInInspector] private float chainRange; // Range for finding the next target
    [SerializeField] [HideInInspector] private int damage = 10; // Damage dealt by the bullet
    [SerializeField] [HideInInspector] private string enemiesTag; // Tag to identify enemies
    [SerializeField] [HideInInspector] private float speed = 70f; // Speed of the bullet

    // Initialize the bullet with all necessary properties
    public void Initialize(Transform _target, int _chainCount, float _chainRange, int _damage, string _enemiesTag)
    {
        target = _target;
        chainCount = _chainCount;
        chainRange = _chainRange;
        damage = _damage;
        enemiesTag = _enemiesTag;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Destroy the bullet if the target is null
            return;
        }

        // Move the bullet towards the current target
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        // Apply damage to the current target
        Enemy_HP enemyHP = target.GetComponent<Enemy_HP>();
        if (enemyHP != null)
        {
            enemyHP.TakeDamage(damage);
        }

        // Chain to the next target if chainCount > 0
        if (chainCount > 0)
        {
            GameObject nextTarget = FindNextTarget();
            if (nextTarget != null)
            {
                target = nextTarget.transform; // Set the new target
                chainCount--; // Reduce chain count
                return;
            }
        }

        // Destroy the bullet if no more chaining is possible
        Destroy(gameObject);
    }

    private GameObject FindNextTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemiesTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform == target) continue; // Skip the current target

            float distanceToEnemy = Vector3.Distance(target.position, enemy.transform.position);
            if (distanceToEnemy <= chainRange && distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}