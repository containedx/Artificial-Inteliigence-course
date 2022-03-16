using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject goal;
    public NavMeshAgent agent;


    void Start()
    {
        agent.SetDestination(goal.transform.position);
    }

}
