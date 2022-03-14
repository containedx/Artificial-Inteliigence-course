using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject WaypointsManager;
    public GameObject[] waypoints;
    UnityEngine.AI.NavMeshAgent NavMeshAgent;



    // Start is called before the first frame update
    void Start()
    {
        //waypoints = WaypointsManager.GetComponent<WPManager>().waypoints;
        NavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    public void GoToOilField(){
        //Oilfield == WP005 
        NavMeshAgent.SetDestination(waypoints[14].transform.position);
    }

    public void GoToRocks(){
        //rocks == WP013
        NavMeshAgent.SetDestination(waypoints[17].transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {

    }
}
