using UnityEngine;

public class Flying_Movement : MonoBehaviour
{
    
    [SerializeField] private float heightAboveGround = 5f;
    //Choose enemy speed
    [SerializeField] public float enemySpeed = 1.0f ;
    
    //Set gameObject goal
    private Transform goal;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set goal as the position of the base
        goal = GameObject.FindGameObjectWithTag("Base").transform;
        transform.position = new Vector3(transform.position.x, transform.position.y + heightAboveGround, transform.position.z);
        transform.LookAt(new Vector3(goal.position.x, goal.position.y + heightAboveGround, goal.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime, Space.Self);
        
    }
}
