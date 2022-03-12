﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    GameObject[] agents;

    void Start(){
        agents = GameObject.FindGameObjectsWithTag("ai");
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;

            //shoot to mouse position
            if( Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)){
                foreach (GameObject a in agents){
                    //move toward hit point
                    a.GetComponent<NPC_Controller>().agent.SetDestination(hit.point);
                }
            }

        }
    }
}
