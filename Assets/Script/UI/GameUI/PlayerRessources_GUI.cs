using UnityEngine;
using TMPro;

public class PlayerRessources_GUI : MonoBehaviour
{
    //image var to show th number of gold the player owns
    [SerializeField] public TMP_Text textUI_Gold;
    //image var to show th number of mechanic scrap the player owns
    [SerializeField] public TMP_Text textUI_MechanicScrap;
    
    //image var to show th number of gold the player owns
    [SerializeField] [HideInInspector] private Ressources ressources;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ref to the component "Ressources" script from "Base"
        ressources = GameObject.FindGameObjectWithTag("Base").GetComponent<Ressources>();
    }

    // Update is called once per frame
    void Update()
    {
        //set the player gold as a string to show it  
        textUI_Gold.text = ressources.playerGold.ToString();
        //set the player mechanic scrap as a string to show it  
        textUI_MechanicScrap.text = ressources.playerMechanicScrap.ToString();
    }
}
