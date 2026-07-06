using System.Collections;

using UnityEngine;

public class Invisibility_Behavior : MonoBehaviour
{
    //Get ref to Mesh renderer
    [SerializeField] private MeshRenderer meshRenderer;
    
    //Time before the invisibility
    [SerializeField] float timeBeforeSmallInvisibility = 2.0f;
    //Duration of the invisibility
    [SerializeField] float invisibilityDuration = 3.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the gameObject Mesh renderer
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        //Start the Coroutine invisibility
        StartCoroutine(Invisibility());
    }

    
    //Invisibility Coroutine
    private IEnumerator Invisibility()
    {
        //Wait time after spawn
        yield return new WaitForSeconds(timeBeforeSmallInvisibility);
        //hide the mesh with Mesh renderer
        meshRenderer.enabled = false;
        //time before showing the gameObject
        yield return new WaitForSeconds(invisibilityDuration);
        //show the mesh with Mesh renderer
        meshRenderer.enabled = true;
    }
}
