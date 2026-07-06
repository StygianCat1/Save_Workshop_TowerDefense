using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawn_Tower : MonoBehaviour
{
    //chose tower to spawn
    [SerializeField] public GameObject tower;
    
    
    // update is called once per frame
    void Update()
    {
        //use Ray to  change spot into defense structure
        ChoosePlacementTower();
    }

    
    //function to spawn the tower to a determined placement
    void ChoosePlacementTower()
    {
        //create a ray from the camera to the position of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //set the gameObject the ray collided with as an ''info point'' + debug that give the name of the object collided by the ray
        if (Physics.Raycast(ray, out RaycastHit hitInfo)) //{ Debug.Log(hitInfo.collider.name); };
        //verify the tag of the object collided by the ray
        if (hitInfo.collider.CompareTag("ChangePoint"))
        {
            //hide the object by changing the MeshRenderer
            hitInfo.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
            //spawn the tower in the collided surface position
            Instantiate(tower,hitInfo.collider.gameObject.transform.position, hitInfo.collider.gameObject.transform.rotation);
        }
    }
}
