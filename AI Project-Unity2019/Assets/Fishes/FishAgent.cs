using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAgent : MonoBehaviour
{
    public FlockManager manager;
    float speed;


    // Start is called before the first frame update
    void Start(){
        speed = Random.Range(manager.minSpeed, manager.maxSpeed);
    }

    // Update is called once per frame
    void Update(){
        ApplyRules();
        MoveForward();
    }

    void ApplyRules(){
        GameObject[] neighbours;
        neighbours = manager.fishes;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;

        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach (var n in neighbours){
            if(n != this.gameObject){
                nDistance = Vector3.Distance(n.transform.position, transform.position);
                if(nDistance <= manager.neighbourDistance){
                    vcentre = vcentre + n.transform.position;
                    groupSize++;

                    if(nDistance < 1.0f){
                        vavoid = vavoid + (transform.position - n.transform.position);
                    }

                    FishAgent anotherAgent = n.GetComponent<FishAgent>();
                    gSpeed = gSpeed + anotherAgent.speed;
                }
            }
        }

        if(groupSize > 0){
            vcentre = vcentre/groupSize;
            speed = gSpeed/groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if(direction != Vector3.zero){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), manager.rotationSpeed * Time.deltaTime);
            }
        }
    }

    void MoveForward(){
        transform.Translate(0,0,Time.deltaTime * speed);
    }
}
