using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;

    public float speed = 3;
    public float rotation_speed = 1;
    public float accuracy; 

    void Start(){
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    void LateUpdate(){
        if ( waypoints.Length == 0)
            return;
        

        var direction = waypoints[current].transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotation_speed);
        if(direction.magnitude < accuracy){
            current++;
            if (current >= waypoints.Length){
                current = 0;
            }
        }
        transform.Translate(0,0, speed * Time.deltaTime);
    }
}
