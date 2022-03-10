using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsGoal : MonoBehaviour
{

    public Transform Goal;
    
    public float speed;
    public float accuracy; 


    void LateUpdate(){
        var goal_direction = Goal.position - transform.position;
        if (goal_direction.magnitude > accuracy){
            transform.Translate(goal_direction.normalized * speed * Time.deltaTime);
        }
    }
}
