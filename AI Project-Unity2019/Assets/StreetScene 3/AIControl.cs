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

		SimulteCrowd();
	}

	void Update(){
		// if goal reached, pick another goal
		if (agent.remainingDistance < 1){
			PickRandomGoal();
		}
	}

	void SimulteCrowd(){
		PickRandomGoal();
		//set some offset to avoid character syncing
		animator.SetFloat("wOffset", Random.Range(0,1));
		//trigger walking animation
		animator.SetTrigger("isWalking");
		//random moving speed
		float randomSpeed = Random.Range(0.1f, 1.8f);
		animator.SetFloat("speedMult", randomSpeed);
		agent.speed *= randomSpeed;
	}

	void PickRandomGoal(){
		agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);
	}
	
}
