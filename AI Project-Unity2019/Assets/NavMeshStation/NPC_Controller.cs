using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    public NavMeshAgent agent;


    // Start is called before the first frame update
    void Start(){
        agent = GetComponent<NavMeshAgent>();
    }

}
