using Unity.VisualScripting;
using UnityEngine;

public class AchievementCode : MonoBehaviour
{
    //calling other scripts 
    public GameObject Achievement1;
    public Spawner spawner;
    public GameObject Achievement7;
    public Enemy_HP enemyHP;
    public GameObject Achievement9; 
    public Tower_Overcharge towerOvercharge;
    public GameObject Achievement10;
    public SelectTower selectTower;
    public GameObject Achievement12;
    public BaseHP basehp;
    
    // serialized fields for all achievement notification PNGs 
    [SerializeField] private GameObject achievementNotif_1;
    [SerializeField] private GameObject achievementNotif_2;
    [SerializeField] private GameObject achievementNotif_3;
    [SerializeField] private GameObject achievementNotif_4;
    [SerializeField] private GameObject achievementNotif_5;
    [SerializeField] private GameObject achievementNotif_6;
    [SerializeField] private GameObject achievementNotif_7;
    [SerializeField] private GameObject achievementNotif_8;
    [SerializeField] private GameObject achievementNotif_9;
    [SerializeField] private GameObject achievementNotif_10;
    [SerializeField] private GameObject achievementNotif_11;
    [SerializeField] private GameObject achievementNotif_12;
    
    //vars to verify if an achievement notification has already been called
    private int achievementActive1 = 0;
    private int achievementActive2 = 0;
    private int achievementActive3 = 0;
    private int achievementActive4 = 0;
    private int achievementActive5 = 0;
    private int achievementActive6 = 0;
    private int achievementActive7 = 0;
    private int achievementActive8 = 0;
    private int achievementActive9 = 0;
    private int achievementActive10 = 0;
    private int achievementActive11 = 0;
    private int achievementActive12 = 0;
    //public int a = 0;
    
    //add serialized fields for all platforms
    //normal platforms A
    [SerializeField] private GameObject platform_A1;
    [SerializeField] private GameObject platform_A2;
    [SerializeField] private GameObject platform_A3;
    [SerializeField] private GameObject platform_A4;
    [SerializeField] private GameObject platform_A5;
    [SerializeField] private GameObject platform_A6;
    [SerializeField] private GameObject platform_A7;
    [SerializeField] private GameObject platform_A8;
    [SerializeField] private GameObject platform_A9;
    [SerializeField] private GameObject platform_A10;
    [SerializeField] private GameObject platform_A11;
    [SerializeField] private GameObject platform_A12;
    [SerializeField] private GameObject platform_A13;
    [SerializeField] private GameObject platform_A14;
    [SerializeField] private GameObject platform_A15;
    [SerializeField] private GameObject platform_A16;
    [SerializeField] private GameObject platform_A17;
    [SerializeField] private GameObject platform_A18;
    [SerializeField] private GameObject platform_A19;
    //special platforms B
    [SerializeField] private GameObject platform_B1;
    [SerializeField] private GameObject platform_B2;
    [SerializeField] private GameObject platform_B3;
    
    //calling the Spawner script
    [SerializeField] [HideInInspector] private Spawner spawnerRef;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get all the useful scripts 
        selectTower = Achievement10.GetComponent< SelectTower >();
        towerOvercharge = Achievement9.GetComponent< Tower_Overcharge >();
        enemyHP = Achievement7.GetComponent< Enemy_HP>();
        basehp = Achievement12.GetComponent< BaseHP >();
        spawner = Achievement1.GetComponent< Spawner>();
        
        //get ref to the script "Spawner"
        spawnerRef = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //Achievement 1: Survive the first wave
        if (spawner.waveIndex == 2 && achievementActive1 == 0)
        {
            //make the achievement 1 active
            achievementNotif_1.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive1 += 1;
        }
            
        //Achievement 2: Survive the fifth wave
        if (spawner.waveIndex == 6 && achievementActive2 == 0)
        {
            //make the achievement 2 active
            achievementNotif_2.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive2 += 1;
        }
        
        //Achievement 3: Survive the fifteenth wave
        if (spawner.waveIndex == 15 && spawnerRef.totalNumberOfEnemies <= 0 && achievementActive3 == 0)
        {
            //make the achievement 3 active
            achievementNotif_3.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive3 += 1;
        }
        
        //Achievement 4: Build one tower in each of the regular platforms 
        if (platform_A1.transform.childCount == 1 && platform_A2.transform.childCount == 1 && achievementActive4 == 0)
        {
            //make the achievement 4 active
            achievementNotif_4.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive4 += 1;
        }
        
        //Achievement 5: Build a tower in each of the special platforms 
        if (platform_B1.transform.childCount == 1 && platform_B2.transform.childCount == 1 && achievementActive5 == 0)
        {
            //make the achievement 5 active
            achievementNotif_5.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive5 += 1;
        }
        
        //Achievement 6: Build a tower in each of the available platforms
        if (platform_A1.transform.childCount == 1 && platform_A2.transform.childCount == 1 && platform_B1.transform.childCount == 1 && platform_B2.transform.childCount == 1 && achievementActive6 == 0)
        {
            //make the achievement 6 active
            achievementNotif_6.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive6 += 1;
        }
        
        //Achievement 7: Kill 100 enemies
        if (enemyHP.counterAchievement7 == 100 && achievementActive7 == 0)
        {
            //make the achievement 7 active
            achievementNotif_7.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive7 += 1;
        }
        
        //Achievement 8: Kill 500 enemies
        if (enemyHP.counterAchievement7 == 500 && achievementActive8 == 0)
        {
            //make the achievement 8 active
            achievementNotif_8.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive8 += 1;
        }
        
        //Achievement 9: Use ten amplification effects (boosts) in a single match
        if (towerOvercharge.counterAchievement9 == 10 && achievementActive9 == 0)
        {
            //make the achievement 9 active
            achievementNotif_9.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive9 += 1;
        }
        
        //Achievement 10: Upgrade 10 towers in a single match
        if (selectTower.counterAchievement10 == 10 && achievementActive10 == 0)
        {
            //make the achievement 10 active
            achievementNotif_10.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive10 += 1;
        }
        
        //Achievement 11: Sell 10 towers
        if (selectTower.counterAchievement11 == 10 && achievementActive11 == 0)
        {
            //make the achievement 11 active
            achievementNotif_11.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive11 += 1;
        }
        
        //Achievement 12: Finish a level with your base at full health points
        if (spawner.waveIndex == 15 && spawnerRef.totalNumberOfEnemies <= 0 && basehp.baseHP == 100 && achievementActive12 == 0)
        {
            //make the achievement 12 active
            achievementNotif_12.SetActive(true);
            //count the number of times the achievement has been active (to prevent repetition)
            achievementActive12 += 1;
        }

    }
    
    public void DisappearAchievement()
    {
        //make the achievements disappear upon clicking on one of them as a button
        achievementNotif_1.SetActive(false);
        achievementNotif_2.SetActive(false);
        achievementNotif_3.SetActive(false);
        achievementNotif_4.SetActive(false);
        achievementNotif_5.SetActive(false);
        achievementNotif_6.SetActive(false);
        achievementNotif_7.SetActive(false);
        achievementNotif_8.SetActive(false);
        achievementNotif_9.SetActive(false);
        achievementNotif_10.SetActive(false);
        achievementNotif_11.SetActive(false);
        achievementNotif_12.SetActive(false);
    }
    
}
