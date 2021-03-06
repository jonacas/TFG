﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour {


    public PathEditor PathToFollow;
    public int currentWayPoint = 0;
    public float speed;
    private float reachDistance = 1;
    public float rotationSpeed = 5;
    public float timeStop = 0f;
    public int wayPointStop = 0;
    public float stopRotation = 90;
    public bool stop = false;
    public GameObject Padre;


    Vector3 currentPosition;
	// Use this for initialization
	void Start () {

        currentWayPoint = 0;
    
		
	}
	
	// Update is called once per frame
	void Update () {


        if (wayPointStop == currentWayPoint)
        {

            stop = true;
            if (timeStop >= 0)
            {
                timeStop = timeStop - Time.deltaTime;
            }
            else
            {
                stop = false;
            }


        }
        Move();

	}

    void Move() {

        float distance = Vector3.Distance(PathToFollow.pathPoints[currentWayPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathPoints[currentWayPoint].position, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        var rotation = Quaternion.LookRotation(PathToFollow.pathPoints[currentWayPoint].position);
        transform.LookAt(PathToFollow.pathPoints[currentWayPoint].position);
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, 0);

        if (stop && this.transform.position == PathToFollow.pathPoints[currentWayPoint].position) {
            transform.eulerAngles = new Vector3(0,0,-stopRotation);
            

        }
        if (distance <= reachDistance && !stop)
        {

            currentWayPoint++;
        }

        if (currentWayPoint >= PathToFollow.pathPoints.Count)
        {
            currentWayPoint = PathToFollow.pathPoints.Count;
            Destroy(Padre, 1);

        }
    }
}
