using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath3D : MonoBehaviour
{

    public PathEditor PathToFollow;
    public int currentWayPoint = 0;
    public float speed;
    private float reachDistance = 1;
    public float rotationSpeed = 5;
    public float timeStop = 0f;
    public int wayPointStop = 0;
    bool stop = false;
    public GameObject Padre;


    Vector3 lastPosition;
    Vector3 currentPosition;
    // Use this for initialization
    void Start()
    {

        lastPosition = transform.position;


    }

    // Update is called once per frame
    void Update()
    {


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

    void Move()
    {

        float distance = Vector3.Distance(PathToFollow.pathPoints[currentWayPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathPoints[currentWayPoint].position, Time.deltaTime * speed);

        var rotation = Quaternion.LookRotation(PathToFollow.pathPoints[currentWayPoint].position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        transform.LookAt(PathToFollow.pathPoints[currentWayPoint].position);


        if (stop && this.transform.position == PathToFollow.pathPoints[currentWayPoint].position)
        {
            //rotation = Quaternion.LookRotation(PlayerMovementLV2.currentInstance.transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

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
