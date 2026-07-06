using UnityEngine;
using UnityEngine.InputSystem;

public class Placement : MonoBehaviour
{
    //var to get Ref to script "Ressources"
    [SerializeField] private Ressources ressources;
    //var to get Ref to script "PreviewSystem"
    [SerializeField] private PreviewSystem preview;
    
    //var to get the player's gold from "Resssources"
    [SerializeField] public int actualPlayerGold;
    
    //var to get the DatabaseSO data 
    [SerializeField] public DatabaseSO database;
    
    //var to get the Transform of the tower's platform 
    [SerializeField] public Transform platformTransform;
    
    //var to choose an object in a list with an index
    [SerializeField] public int selectedObjectIndex = -1;

    //bool to verify if the cursor is on the little platform
    [SerializeField] public bool littlePlatform;   
    //bool to verify if the cursor is on the big platform
    [SerializeField] public bool  bigPlatform;
    //bool to verify the player can place the tower
    [SerializeField] public bool canPlace = true;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get ref of the "Ressources" script
        ressources = GameObject.FindWithTag("Base").GetComponent<Ressources>();
        //StopPlacement function called to put index to -1 in case it's not well set
        StopPlacement();
    }

    
    // Update is called once per frame
    void Update()
    {
        //ChoosePlacementTower function to show the pre visualisation of the Prefab in the scene and the position of the cursor in the game
        ChoosePlacementTower();
        // verify if the size of the GameObject in DatabaseSO is correct for the platform it will be put on
        if (database.objectsData[selectedObjectIndex].Size == 5 && bigPlatform != true)
        {
            //can place is false if the GameObject Size is not appropriate for the platform 
            canPlace = false;
        }
        else
        {
            //can place is true if the GameObject Size is appropriate for the platform 
            canPlace = true;
        }

        if (actualPlayerGold < database.objectsData[selectedObjectIndex].Price)
        {
            StopPlacement();
        }
    }


    //function that begin only if the mouse left button is clicked (Tap) from InputManager
    void OnMouseButton()
    {
        //set playerGold as the var to get playerGold from "Ressources" 
        actualPlayerGold = ressources.playerGold;
        //if the Transform ref is not null
        if (platformTransform != null)
        {
            // if the Gameobject has a big size
            if (database.objectsData[selectedObjectIndex].Size == 5)
            {
                //and if the platform is big
                if (bigPlatform)
                {
                    //can PlaceTower
                    PlaceTower();
                }
                else
                {
                //    Play sound to tell the player it's impossible
                }
            }
            //if GameObject is small
            else
            {
                //can place it on any platform
                PlaceTower();
            }
        }
        //if no platform is selected
        else
        {
            //remove the pre visualisation and put back the index to -1
            StopPlacement();
        }

    }
    
    
    //function that place the tower to a specific position
    void PlaceTower()
    {
        //instantiate a GameObject to a platform position
        GameObject towerRef = Instantiate(database.objectsData[selectedObjectIndex].Turret, platformTransform.position, Quaternion.identity);
        //Set the Prefab as the platform child
        towerRef.transform.parent = platformTransform;
        // decrement the player gold for instantiating a turret / tower
        ressources.playerGold -= database.objectsData[selectedObjectIndex].Price;
        //Stop placement after having placed one tower
        StopPlacement();
    }

    
    //function to get the ID of the used GameObject
    public void StartPlacement(int ID)
    {
        //Stop Placement to reset the var (selectedObjectIndex);
        StopPlacement();
        //make the var the int that the player chosed
        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        //Start showing the preview of the GameObject 
        preview.StartShowingPlacementPreview(database.objectsData[selectedObjectIndex].Prefab);
    }

    
    //stop the placement function (sort of reset function)
    void StopPlacement()
    {
        //reset the selectedObjectIndex var
        selectedObjectIndex = -1;
        //stop showing the preview
        preview.StopShowingPlacementPreview();
    }
    
    
    void ChoosePlacementTower()
    {
        //create a ray from the camera to the position of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //set the gameObject the ray collided with as an ''info point'' + debug that give the name of the object collided by the ray
        if (Physics.Raycast(ray, out RaycastHit hitInfo)) //{ Debug.Log(hitInfo.collider.name); };
        //verify the tag of the object collided by the ray and the number of it's children
        
        if (hitInfo.collider.CompareTag("3x3") && hitInfo.collider.transform.childCount == 0)
        {
            //set platformTransform as the transform of the collided GameObject
            platformTransform = hitInfo.collider.transform;
            //littlePlatform is true
            littlePlatform = true;
        }
        //verify the tag of the object collided by the ray and the number of it's children
        else if (hitInfo.collider.CompareTag("5x5") && hitInfo.collider.transform.childCount == 0)
        {
            //set platformTransform as the transform of the collided GameObject
            platformTransform = hitInfo.collider.transform;
            //bigPlatform is true
            bigPlatform = true;
        }
        else
        {
            //set platformTransform as null
            platformTransform = null;
            //littlePlatform is false
            littlePlatform = false;
            //bigPlatform is false
            bigPlatform = false;
        }
        //Update the preview position depending on the hitpoint and the color depending on the bool to verify ifthe player can pause the platform
        preview.UpdatePosition(hitInfo.point, bigPlatform || littlePlatform && canPlace);
    }
}
