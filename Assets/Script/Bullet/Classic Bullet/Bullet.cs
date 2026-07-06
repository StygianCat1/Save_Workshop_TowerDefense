using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Transform target;

    [SerializeField] private float speed = 70f;
    [SerializeField] public int damage = 50;

    [SerializeField] private Enemy_HP enemyHp;
    
    
    
    public void Seek(Transform _target)
    {
        target = _target;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("aled");
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (target != null)
        {
            enemyHp = target.gameObject.GetComponent<Enemy_HP>();
            Vector3 dir = target.transform.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
            }
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != target.gameObject)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        Damage(enemyHp);
        Destroy(this.gameObject);
    }

    public void Damage(Enemy_HP hp)
    {
        hp.TakeDamage(damage);
    }
}

