using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MortierBullets : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] public float Speed = 70f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Speed,ForceMode.Impulse);
    }

    public void SeekTheEnemies(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position; 
        float distanceThisFrame = Speed * Time.deltaTime;
       
        //transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }


    void OnTriggerEnter(Collider other)
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        explosion.SetActive(true);
        Destroy(this.gameObject, 1f);
    }
}