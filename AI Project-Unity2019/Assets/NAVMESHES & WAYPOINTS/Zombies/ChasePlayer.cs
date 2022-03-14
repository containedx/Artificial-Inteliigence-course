using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    GameObject target; //player
    NavMeshAgent agent;


    void Start(){
        target = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        agent.SetDestination(target.transform.position);
    }
}
