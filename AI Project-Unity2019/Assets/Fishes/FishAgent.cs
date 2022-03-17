﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAgent : MonoBehaviour
{
    public FlockManager manager;
    float speed;

    bool turning = false;


    // Start is called before the first frame update
    void Start(){
        speed = Random.Range(manager.minSpeed, manager.maxSpeed);
    }

    // Update is called once per frame
    void Update(){
        KeepInBounds();

        if(!turning){
        if(Random.Range(0,100) < 20)
            ApplyRules();
        if(Random.Range(0,100) < 10)
            speed = Random.Range(manager.minSpeed, manager.maxSpeed);
        }

        
        MoveForward();
    }

    void KeepInBounds(){
        Bounds b = new Bounds(manager.transform.position, manager.swimLimits*2);

        if(!b.Contains(transform.position)){
            turning = true;
        }
        else{
            turning = false;
        }

        if(turning){
            Vector3 direction = manager.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), manager.rotationSpeed*Time.deltaTime);
        }
    }

    void ApplyRules(){
        GameObject[] neighbours = manager.fishes;

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
            vcentre = vcentre/groupSize + manager.goalPosition - transform.position;
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
