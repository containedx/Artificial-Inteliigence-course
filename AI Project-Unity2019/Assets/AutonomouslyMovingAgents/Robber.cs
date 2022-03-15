using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Robber : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Seek(target.transform.position);
    }


    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }
}
