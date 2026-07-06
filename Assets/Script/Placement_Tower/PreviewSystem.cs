using System;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    //var to get the preview of the gameObject (the prefab)
    [SerializeField] private GameObject previewObject;
    
    //var of material that we want to put on the prefab
    [SerializeField] private Material previewMaterialPrefab;
    //var of the material of the object
    [SerializeField] private Material previewMaterialInstance;
    
    //var to put the preview a little above ground
    [SerializeField] private float previewYOffset = 0.06f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //set the previewMaterialPrefab as a new material for previewMaterialInstance
        previewMaterialInstance = new Material(previewMaterialPrefab);
    }

    //function to show the preview in the game
    public void StartShowingPlacementPreview(GameObject prefab)
    {
        //instantiate the prefab and make it the previewObject
        previewObject = Instantiate(prefab);
        //prepare for the change of previewObject
        PreparePreview(previewObject);
    }
    

    //prepare the material of the preview to change
    private void PreparePreview(GameObject previewObject)
    {
        // get a list of renderer of all the renderers of the GameObject in the prefab 
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();
        //for all the renderer in the list
        foreach (Renderer renderer in renderers)
        {
            //create a list of material from the renderer
            Material[] materials = renderer.materials;
            //for the lenght (number of materials)
            for (int i = 0; i < materials.Length; i++)
            {
                // make the materials change to the previewMaterialInstance materials 
                materials[i] = previewMaterialInstance;
            }
            //set the renderer material as it's new material
            renderer.materials = materials;
        }
    }

    //function to stop showing the prefab
    public void StopShowingPlacementPreview()
    {
        //it just destroy the gameObject that you want for the pre visualisation
        Destroy(previewObject);
    }

    //function to change the position and color of the preview
    public void UpdatePosition(Vector3 position, bool validity)
    {
        //function MovePreview for the position of the prefab
        MovePreview(position);
        //function ApplyFeedback for the color of the prefab
        ApplyFeedback(validity);
    }

    //function MovePreview for the position of the prefab
    private void MovePreview(Vector3 position)
    {
        //Set the preview as a chosen position + an offset for it no to be in the ground
        previewObject.transform.position = new Vector3(position.x, position.y + previewYOffset, position.z);
    }

    //function ApplyFeedback for the color of the prefab
    private void ApplyFeedback(bool validity)
    {
        //change the color depending on validity (white if true and red if false
        Color c = validity ? Color.white : Color.red;
        //change the alpha to 0.5
        c.a = 0.5f;
        //apply the changes
        previewMaterialInstance.color = c;
    }
}
