using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	GameObject[] goalLocations;
	UnityEngine.AI.NavMeshAgent agent;

	Animator animator;


	// Use this for initialization
	void Start () {
		goalLocations = GameObject.FindGameObjectsWithTag("goal");
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		animator = GetComponent<Animator>();

		PickRandomGoal();
		//trigger walking animation
		animator.SetTrigger("isWalking");
	}

	void Update(){
		// if goal reached, pick another goal
		if (agent.remainingDistance < 1){
			PickRandomGoal();
		}
	}

	void PickRandomGoal(){
		agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);
	}
	
}
