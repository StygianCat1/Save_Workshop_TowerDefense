using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectTower : MonoBehaviour
{
    //var to get Ref to script "Ressources"
    [SerializeField] private Ressources ressources;
    //var to get Ref to script "PreviewSystem"
    [SerializeField] private PreviewSystem preview;
        
    //var to get the player's gold from "Resssources"
    [SerializeField] private int playerGold;
       
    //var to get the DatabaseSO data 
    [SerializeField] public DatabaseSO database;
      
    //var to get the Sell icon
    [SerializeField] GameObject sellIcon;
    //var to get the Sell icon
    [SerializeField] GameObject upgradeIcon;
    //var to get the Management info
    [SerializeField] GameObject managementInfo;
        
    //var to get the Transform of the tower's platform 
    [SerializeField] public Transform towerTransform;
        
    //var to choose an object in a list with an index
    [SerializeField] public int selectedObjectIndex = -1;
    
    //bool to verify if the cursor is on a tower over a little platform
    [SerializeField] public bool smallPlatformtower;   
    //bool to verify if the cursor is on a tower over a little platform
    [SerializeField] public bool bigPlatformtower;
    //bool to verify if the player can sell the tower
    [SerializeField] public bool canSell = false;
    //bool to verify if the player can sell the tower
    [SerializeField] public bool canUpgrade = false;
    
    public int counterAchievement10 = 0;
    public int counterAchievement11 = 0;
    
    
    
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get ref of the "Ressources" script
        ressources = GameObject.FindWithTag("Base").GetComponent<Ressources>();
    }
    
        
    // update is called once per frame
    void Update()
    {
        //set playerGold as the var to get playerGold from "Ressources" 
        playerGold = ressources.playerGold;
        //ChooseTower function to show the position of the cursor in the game
        ChooseTower();
        //verify if the size of the parent platform allows for selling
        if (smallPlatformtower == true)
        {
            //canSell is true if the selected tower is on a small platform
            canSell = true;
            canUpgrade = true;
        }
        else if (bigPlatformtower == true)
        {
            //canSell is false if the selected tower is on a big platform 
            canSell = false;
            canUpgrade = true;
        }
        else
        {
            canSell = false;
            canUpgrade = false;
        }
        
        //sell tower command with Q in QWERTY or A in AZERTY
        if (sellIcon.activeSelf == true && Input.GetKey(KeyCode.Q))
        {
            SellTower();
            
        }
        
        //upgrade tower command with E in both QWERTY and AZERTY
        if (sellIcon.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            UpgradeTower();
        }
    }
    
    
    //function that begins only if the mouse left button is clicked (Tap) on a tower
    void OnMouseButton()
    {
        //if the tower is on a small platform (capable of being sold)
        if (canSell == true && canUpgrade == true)
        {
            //activate sell and upgrade icons
            sellIcon.SetActive(true);
            upgradeIcon.SetActive(true);
            managementInfo.SetActive(true);
        }
        else if (canSell == false && canUpgrade == true)
        {
            //activate upgrade icon
            sellIcon.SetActive(false);
            upgradeIcon.SetActive(true);
            managementInfo.SetActive(true);
        }
        else
        {
            //deactivate both icons
            sellIcon.SetActive(false);
            upgradeIcon.SetActive(false);
            managementInfo.SetActive(false);
        }
    }
        
        
    //function to sell the tower
    public void SellTower()
    {
        //sell T1 or T2 (on the UI)
        if (towerTransform.gameObject.GetComponent<Tower1>() != null)
        {
            //add the respective resell price to the player's resources
            ressources.playerGold += towerTransform.gameObject.GetComponent<Tower1>().resellPrice;
        }
            
        //sell T3 (on the UI)
        if (towerTransform.gameObject.GetComponent<TowerMortier>() != null)
        {
            //add the respective resell price to the player's resources
            ressources.playerGold += towerTransform.gameObject.GetComponent<TowerMortier>().resellPrice;
        }
        
        //sell T4 (on the UI)
        if (towerTransform.gameObject.GetComponent<Tower6>() != null)
        {
            //add the respective resell price to the player's resources
            ressources.playerGold += towerTransform.gameObject.GetComponent<Tower6>().resellPrice;
        }
        
        //destroy tower
        Destroy(towerTransform.gameObject);
        //add 1 to the sell counter
        counterAchievement11 += 1;
    }
    
    //function to upgrade the tower
    public void UpgradeTower()
    {
        //upgrade T1 or T2 (on the UI)
        if (towerTransform.gameObject.GetComponent<Tower1>() != null)
        {
            //verify if the tower can be upgraded
            if (towerTransform.gameObject.GetComponent<Tower1>().nextTower != null)
            {
                //spend the necessary gold and scrap to upgrade the tower
                ressources.playerGold -= towerTransform.gameObject.GetComponent<Tower1>().upgradePricegoldlvl2;
                ressources.playerMechanicScrap -= towerTransform.gameObject.GetComponent<Tower1>().upgradePricescraplvl2;
                //spawn the upgraded tower
                GameObject newTower = Instantiate(towerTransform.gameObject.GetComponent<Tower1>().nextTower, towerTransform.position, towerTransform.rotation);
                newTower.transform.parent = towerTransform.parent;
                //destroy the previous tower
                Destroy(towerTransform.gameObject);
                //assign the price for the newt upgrade
                newTower.gameObject.GetComponent<Tower1>().upgradePricegoldlvl2 = towerTransform.gameObject.GetComponent<Tower1>().upgradePricegoldlvl3;
                newTower.gameObject.GetComponent<Tower1>().upgradePricescraplvl2 = towerTransform.gameObject.GetComponent<Tower1>().upgradePricescraplvl3;
                //add 1 to the upgrade counter
                counterAchievement10 += 1;
            }
        }
        
        //upgrade T3 (on the UI)
        else if (towerTransform.gameObject.GetComponent<TowerMortier>() != null)
        {
            //verify if the tower can be upgraded
            if (towerTransform.gameObject.GetComponent<TowerMortier>().nextTower != null)
            {
                //spend the necessary gold and scrap to upgrade the tower
                ressources.playerGold -= towerTransform.gameObject.GetComponent<TowerMortier>().upgradePricegoldlvl2;
                ressources.playerMechanicScrap -= towerTransform.gameObject.GetComponent<TowerMortier>().upgradePricescraplvl2;;
                //spawn the upgraded tower
                GameObject newTower = Instantiate(towerTransform.gameObject.GetComponent<TowerMortier>().nextTower, towerTransform.position, towerTransform.rotation);
                newTower.transform.parent = towerTransform.parent;
                //destroy the previous tower
                Destroy(towerTransform.gameObject);
                //assign the price for the newt upgrade
                newTower.gameObject.GetComponent<TowerMortier>().upgradePricegoldlvl2 = towerTransform.gameObject.GetComponent<TowerMortier>().upgradePricegoldlvl3;
                newTower.gameObject.GetComponent<TowerMortier>().upgradePricescraplvl2 = towerTransform.gameObject.GetComponent<TowerMortier>().upgradePricescraplvl3;
                //add 1 to the upgrade counter
                counterAchievement10 += 1;
            }
        }
        
        
        //upgrade  T4 (on the UI)
        else if (towerTransform.gameObject.GetComponent<Tower6>() != null)
        {
            //verify if the tower can be upgraded
            if (towerTransform.gameObject.GetComponent<Tower6>().nextTower != null)
            {
                //spend the necessary gold and scrap to upgrade the tower
                ressources.playerGold -= towerTransform.gameObject.GetComponent<Tower6>().upgradePricegoldlvl2;
                ressources.playerMechanicScrap -= towerTransform.gameObject.GetComponent<Tower6>().upgradePricescraplvl2;;
                //spawn the upgraded tower
                GameObject newTower = Instantiate(towerTransform.gameObject.GetComponent<Tower6>().nextTower, towerTransform.position, towerTransform.rotation);
                newTower.transform.parent = towerTransform.parent;
                //destroy the previous tower
                Destroy(towerTransform.gameObject);
                //assign the price for the newt upgrade
                newTower.gameObject.GetComponent<Tower6>().upgradePricegoldlvl2 = towerTransform.gameObject.GetComponent<Tower6>().upgradePricegoldlvl3;
                newTower.gameObject.GetComponent<Tower6>().upgradePricescraplvl2 = towerTransform.gameObject.GetComponent<Tower6>().upgradePricescraplvl3;
                //add 1 to the upgrade counter
                counterAchievement10 += 1;
            }
        }

        //upgrade T5 (on the UI)
        else if (towerTransform.gameObject.GetComponent<Tower2>() != null)
        {
            //verify if the tower can be upgraded
            if (towerTransform.gameObject.GetComponent<Tower2>().nextTower != null)
            {
                //spend the necessary gold and scrap to upgrade the tower
                ressources.playerGold -= towerTransform.gameObject.GetComponent<Tower2>().upgradePricegoldlvl2;
                ressources.playerMechanicScrap -= towerTransform.gameObject.GetComponent<Tower2>().upgradePricescraplvl2;;
                //spawn the upgraded tower
                GameObject newTower = Instantiate(towerTransform.gameObject.GetComponent<Tower2>().nextTower, towerTransform.position, towerTransform.rotation);
                newTower.transform.parent = towerTransform.parent;
                //destroy the previous tower
                Destroy(towerTransform.gameObject);
                //assign the price for the newt upgrade
                newTower.gameObject.GetComponent<Tower2>().upgradePricegoldlvl2 = towerTransform.gameObject.GetComponent<Tower2>().upgradePricegoldlvl3;
                newTower.gameObject.GetComponent<Tower2>().upgradePricescraplvl2 = towerTransform.gameObject.GetComponent<Tower2>().upgradePricescraplvl3;
                //add 1 to the upgrade counter
                counterAchievement10 += 1;
            }
        }

        //upgrade T6 (on the UI)
        else if (towerTransform.gameObject.GetComponent<Tower4>() != null)
        {
            //verify if the tower can be upgraded
            if (towerTransform.gameObject.GetComponent<Tower4>().nextTower != null)
            {
                //spend the necessary gold and scrap to upgrade the tower
                ressources.playerGold -= towerTransform.gameObject.GetComponent<Tower4>().upgradePricegoldlvl2;
                ressources.playerMechanicScrap -= towerTransform.gameObject.GetComponent<Tower4>().upgradePricescraplvl2;;
                //spawn the upgraded tower
                GameObject newTower = Instantiate(towerTransform.gameObject.GetComponent<Tower4>().nextTower, towerTransform.position, towerTransform.rotation);
                newTower.transform.parent = towerTransform.parent;
                //destroy the previous tower
                Destroy(towerTransform.gameObject);
                //assign the price for the newt upgrade
                newTower.gameObject.GetComponent<Tower4>().upgradePricegoldlvl2 = towerTransform.gameObject.GetComponent<Tower4>().upgradePricegoldlvl3;
                newTower.gameObject.GetComponent<Tower4>().upgradePricescraplvl2 = towerTransform.gameObject.GetComponent<Tower4>().upgradePricescraplvl3;
                //add 1 to the upgrade counter
                counterAchievement10 += 1;
            }
        }
    }
        
    
    void ChooseTower()
    {
        //create a ray from the camera to the position of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //set the gameObject the ray collided with as an ''info point''
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
            //verify the tag of the object collided by the ray and the number of its children
            if (hitInfo.collider.CompareTag("Tower") && hitInfo.collider.transform.parent.CompareTag("3x3"))
            {
                //set towerTransform as the transform of the collided GameObject
                towerTransform = hitInfo.collider.transform;
                //tower is on a small platform
                smallPlatformtower = true;
            }
            //verify the tag of the object collided by the ray and the number of its children
            else if (hitInfo.collider.CompareTag("Tower") && hitInfo.collider.transform.parent.CompareTag("5x5"))
            {
                //set towerTransform as the transform of the collided GameObject
                towerTransform = hitInfo.collider.transform;
                print(towerTransform);
                //tower is on a big platform
                bigPlatformtower = true;
            }
            else
            {
                //set platformTransform as null
                towerTransform = null;
                //littlePlatformtower is false
                smallPlatformtower = false;
                //bigPlatformtwer is false
                bigPlatformtower = false;
            }
    }
}

