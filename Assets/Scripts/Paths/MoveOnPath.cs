using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour {


    public PathEditor PathToFollow;
    public int currentWayPoint = 0;
    public float speed;
    private float reachDistance = 1;
    public float rotationSpeed = 5;

    Vector3 lastPosition;
    Vector3 currentPosition;
	// Use this for initialization
	void Start () {

        lastPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(PathToFollow.pathPoints[currentWayPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathPoints[currentWayPoint].position, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x,transform.position.y,0);

        var rotation = Quaternion.LookRotation(PathToFollow.pathPoints[currentWayPoint].position- transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, 0);


        if (distance <= reachDistance) {

            currentWayPoint++;
        }

        if (currentWayPoint >= PathToFollow.pathPoints.Count) {

            currentWayPoint = 0;

        }
	}
}
