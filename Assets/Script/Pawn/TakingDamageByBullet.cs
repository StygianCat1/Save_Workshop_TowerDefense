using UnityEngine;
using UnityEngine.UI;

public class TakingDamage : MonoBehaviour
{
    [SerializeField] private int health = 100;

    public Image HealthBar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void TakeDamage(int amont)
    {
        
        health -= amont;

        if (health <= 0)
        {

            EnemyDie();

        }
        
    }

    void EnemyDie()
    {
        
        
        Destroy(gameObject);
        
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
