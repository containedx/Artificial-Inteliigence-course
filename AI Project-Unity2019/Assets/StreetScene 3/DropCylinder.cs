using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCylinder : MonoBehaviour {

	public GameObject obstacle;
	GameObject[] agents;
	public Camera camera;
	
	// Use this for initialization
	void Start () {
		agents = GameObject.FindGameObjectsWithTag("ai");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hitInfo;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
			{
				Instantiate(obstacle,hitInfo.point,obstacle.transform.rotation);
				foreach(GameObject a in agents)
				{
					a.GetComponent<AIControl>().DetectNewObstacle(hitInfo.point);
				}
			}
		}
	}
}
