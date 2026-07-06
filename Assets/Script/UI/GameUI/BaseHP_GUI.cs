using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BaseHP_GUI : MonoBehaviour
{
    //might delete 
    [SerializeField] public TMP_Text textUI_PV;
    
    //ref to the image that manage the player (base)'s Health
    public Image healthBarFill;
    
    // var to get ref from script "BaseHP"
    private BaseHP hp;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
        //get BaseHP from the "Base"
        hp = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseHP>();
    }

    // Update is called once per frame
    void Update()
    {
        //might disappear 
        textUI_PV.text = hp.baseHP.ToString();
        //change health bar fill amount 
        healthBarFill.fillAmount = (hp.baseHP / 100f);
    }
}
