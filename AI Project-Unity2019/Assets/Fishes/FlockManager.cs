using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numberOfFishes = 100;
    public GameObject[] fishes;
    public Vector3 swimLimits = new Vector3(5,5,5);
    public Vector3 goalPosition;

    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;



    void Start(){
        fishes = new GameObject[numberOfFishes];

        for (int i = 0; i < numberOfFishes; i++)
        {
            Vector3 pos = transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x), 
                                                           Random.Range(-swimLimits.y, swimLimits.y), 
                                                           Random.Range(-swimLimits.z, swimLimits.z) );
            fishes[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity);  
            fishes[i].GetComponent<FishAgent>().manager = this; 
        }
    }

    void Update(){
        if(Random.Range(0,100)<10) //10% chance of changing, to not change it every update
        {
            goalPosition = transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x), 
                                                           Random.Range(-swimLimits.y, swimLimits.y), 
                                                           Random.Range(-swimLimits.z, swimLimits.z) );
        }

    }

}
