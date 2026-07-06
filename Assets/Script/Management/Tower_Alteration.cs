using UnityEngine;
using UnityEngine.InputSystem;

public class Tower_Alteration : MonoBehaviour
{
    [SerializeField] public Ressources ressources;
    [SerializeField] private GameObject towerRef;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChooseTower();
    }
    
    //function that begins only if the mouse left button is clicked (Tap) on a tower
    void OnMouseButton()
    {
        
    }
    
    public void SellTower()
    {

    }

    void ChooseTower()
    {
        //create a ray from the camera to the position of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //set the gameObject the ray collided with as an ''info point''
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
            //verify the tag of the object collided by the ray and the number of its children
            if (hitInfo.collider.CompareTag("Tower"))
            {
                towerRef = hitInfo.collider.gameObject;
            }
            else
            {
                towerRef = null;
            }
    }
}
