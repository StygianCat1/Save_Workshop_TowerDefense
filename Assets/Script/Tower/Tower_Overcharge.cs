using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class Tower_Overcharge : MonoBehaviour
{
    [SerializeField] private string towerTag = "Tower";

    [SerializeField] public Button overchargeButton;
    
    [SerializeField] private float overchargeRate = 1.5f;
    [SerializeField] private float overchargeTime = 20f;
    [SerializeField] private float overchargeCooldown = 30f;
    [SerializeField] private float countdown = 0f;

    public int counterAchievement9 = 0;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        
    }

    public void PlayOvercharge()
    {
        StartCoroutine(Overcharging());
    }

    private IEnumerator Overcharging()
    {
        if (countdown <= 0f)
        {
            Overcharge();
            yield return new WaitForSeconds(overchargeTime); 
            StopOvercharge();
            countdown = overchargeCooldown;
            yield return new WaitForSeconds(overchargeCooldown);
            overchargeButton.image.color = new Color(1f, 1f, 1f, 1f);
            overchargeButton.interactable = true;
            counterAchievement9 += 1;
        }
    }
    
    
    void Overcharge()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag(towerTag);
        foreach (GameObject tower in towers)
        {
            if(tower.GetComponent<Tower1>() != null)
            {
                tower.GetComponent<Tower1>().firerate /= overchargeRate;
            }
            else if(tower.GetComponent<Tower2>() != null)
            {
                tower.GetComponent<Tower2>().firerate /= overchargeRate;
            }
            else if(tower.GetComponent<Tower4>() != null)
            {
                tower.GetComponent<Tower4>().firerate /= overchargeRate;
            }
            else if(tower.GetComponent<TowerMortier>() != null)
            {
                tower.GetComponent<TowerMortier>().firerate /= overchargeRate;
            }
            else if(tower.GetComponent<Tower6>() != null)
            {
                tower.GetComponent<Tower6>().firerate /= overchargeRate;
            }
        }
        overchargeButton.image.color = new Color(1f, 1f, 1f, 0f);
        overchargeButton.interactable = false;
    }
    
    void StopOvercharge()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag(towerTag);
        foreach (GameObject tower in towers)
        {
            if(tower.GetComponent<Tower1>() != null)
            {
                tower.GetComponent<Tower1>().firerate *= overchargeRate;
            }
            else if(tower.GetComponent<Tower2>() != null)
            {
                tower.GetComponent<Tower2>().firerate *= overchargeRate;
            }
            else if(tower.GetComponent<Tower4>() != null)
            {
                tower.GetComponent<Tower4>().firerate *= overchargeRate;
            }
            else if(tower.GetComponent<TowerMortier>() != null)
            {
                tower.GetComponent<TowerMortier>().firerate *= overchargeRate;
            }
            else if(tower.GetComponent<Tower6>() != null)
            {
                tower.GetComponent<Tower6>().firerate *= overchargeRate;
            }
        }
    }
}
