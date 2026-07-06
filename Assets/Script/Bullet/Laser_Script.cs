using System;
using UnityEngine;

public class Laser_Script : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private string tag = "Enemies";
    [SerializeField] private string tag2 = "Flying";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tag || other.tag == tag2)
        {
            other.transform.gameObject.GetComponent<Enemy_HP>().health -= damage;
        }
        
    }
}
