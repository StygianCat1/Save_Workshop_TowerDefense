using UnityEngine;
using Image = UnityEngine.UI.Image;


public class Enemy_HP : MonoBehaviour
{
    [SerializeField] [HideInInspector] private Spawner spawner;
    [SerializeField] [HideInInspector] private Ressources ressources;
    
    [SerializeField]  public Image healthBar;
    
     [SerializeField] public GameObject healthCanvas;
    
    //var about enemy's health
    [SerializeField] public int health = 100;
    [SerializeField] public int goldDrop;
    
    [SerializeField] [HideInInspector] private GameObject camCanvas;
    
    [SerializeField] [HideInInspector] private int totalHealth;

    public int counterAchievement7 = 0;
    

    void Start()
    {
        totalHealth = health;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        ressources = GameObject.FindGameObjectWithTag("Base").GetComponent<Ressources>();
        camCanvas = Camera.main.gameObject;
    }

    
    // Update is called once per frame
    void Update()
    {
        healthCanvas.transform.LookAt(camCanvas.transform); 
        healthBar.fillAmount = (float)health / totalHealth;
        // if the health is equal or inferior to 0
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        ressources.playerGold += goldDrop;
        spawner.totalNumberOfEnemies -= 1;
        counterAchievement7 += 1;
    }


    public void TakeDamage(int amount)
    {
        
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        
            Destroy(gameObject);
    }
    
    
    
    
}
