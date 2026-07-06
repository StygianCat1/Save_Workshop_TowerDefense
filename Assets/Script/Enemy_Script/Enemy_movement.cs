using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_movement : MonoBehaviour
{
    //Create a list of waypoints for the enemy destination
    [SerializeField] private List<GameObject> waypoints;
    
    //Choose enemy speed
    [SerializeField] public float enemySpeed = 1.0f ;
    
    //Get ref to navMeshAgent
    private NavMeshAgent enemyAgent;
    
    //Set gameObject goal
    private Transform goal;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set goal as the position of the base
        goal = GameObject.FindGameObjectWithTag("Base").transform;
        //get the gameObject NavMeshAgent 
        enemyAgent = GetComponent<NavMeshAgent>();
        //Start the Coroutine MovingToDestination
        StartCoroutine("MovingToDestination");
    }

    
    // Update is called once per frame
    void Update()
    {
        //make the enemys speed the NavMeshSpeed
        enemyAgent.speed = enemySpeed;
    }

    
    private IEnumerator MovingToDestination()
    {
        //verify the number of waypoint in the list, if they're more than 0
        if (waypoints.Count != 0)
        {
            //during the lenght of the list
            for (int i = 0; i < waypoints.Count; i++)
            {
                //set enemy destination as a waypoints
                enemyAgent.destination = waypoints[i].transform.position;
                //wait for changes until the enemy arrives near his destination
                yield return new WaitUntil(() => Vector3.Distance(transform.position, waypoints[i].transform.position) < 4.0f);
            }
            //choose the goal position as the gameObject final destination
            enemyAgent.destination = goal.position;
        }
        //else... (nothing more to say)
        else
        {
            //choose the goal position as the gameObject destination
            enemyAgent.destination = goal.position;
        }
    }
}
