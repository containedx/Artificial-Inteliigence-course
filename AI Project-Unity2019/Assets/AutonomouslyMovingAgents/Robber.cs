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
        Hide();
    }


    // Steering Behaviours : 

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - transform.position;
        agent.SetDestination(transform.position - fleeVector);
    }

    void Pursue()
    {
        Vector3 targetDir = target.transform.position - transform.position;

        float relativeHeading = Vector3.Angle(transform.forward, transform.TransformVector(target.transform.forward));
        float toTarget = Vector3.Angle(transform.forward, transform.TransformVector(targetDir));

        if( (toTarget > 90 && relativeHeading < 20) || target.GetComponent<Drive>().currentSpeed < 0.01f){
            Seek(target.transform.position);
            return;
        }

        float lookAhead = targetDir.magnitude/(agent.speed + target.GetComponent<Drive>().currentSpeed);
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    void Evade()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        float lookAhead = targetDir.magnitude/(agent.speed + target.GetComponent<Drive>().currentSpeed);

        Flee(target.transform.position + target.transform.forward * lookAhead);
    }


    Vector3 wanderTarget = Vector3.zero;

    void Wander()
    {
        // seek around circle with bit jitter(to make it more natural) - just wandering around without goal
        float wanderRadius = 10;
        float wanderDistance = 10;
        float wanderJitter = 5;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocalPosition = wanderTarget + new Vector3(0,0, wanderDistance);
        Vector3 targetWorldPosition = gameObject.transform.InverseTransformVector(targetLocalPosition);
        
        Seek(targetWorldPosition);
    }


    void Hide()
    {
        float dist = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;

        foreach (var spot in World.Instance.GetHidingSpots())
        {
            Vector3 hideDirection = spot.transform.position - target.transform.position;
            Vector3 hidePosition = spot.transform.position + hideDirection.normalized * 5;

            var distanceFromHideSpot = Vector3.Distance(transform.position, hidePosition);

            if (distanceFromHideSpot < dist )
            {
                chosenSpot = hidePosition;
                dist = distanceFromHideSpot;
            }
        }

        Seek(chosenSpot);
    }
}
