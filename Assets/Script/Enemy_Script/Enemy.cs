  using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int damageToBase;

    private GameObject baseRef;
    
    //Set gameObject goal
    private Transform goal;
    
    void Start()
    {
        baseRef = GameObject.FindGameObjectWithTag("Base");
        goal = baseRef.transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(goal.position.x, transform.position.y, goal.position.z)) < 4.0f)
        {
            baseRef.GetComponent<BaseHP>().baseHP -= damageToBase;
            Destroy(this.gameObject);
        }
    }

    
}


