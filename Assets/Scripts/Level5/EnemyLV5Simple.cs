using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLV5Simple : EnemyLV5 {

    public int damage = 10;
    float enemySpeed = 50f;
    float enemyRotationOffset = 0.5f;
    float enemyOffset = 2f;
    float enemyDetectionDis = 20f;
    Vector3 enemyInitialPosition;
    // Use this for initialization

    void Start()
    {

        enemyInitialPosition = this.gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(target.position, enemyInitialPosition) <= 400)
        {
            Move();
            Detection();
        }
        else
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position, enemyInitialPosition, 20 * Time.deltaTime);

        }
    }

    void Move()
    {

        transform.position += transform.forward * enemySpeed * Time.deltaTime;

    }

    void Turn()
    {

        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, enemyRotationOffset * Time.deltaTime);


    }

    void Detection()
    {

        Vector3 left = transform.position - Vector3.right * enemyOffset;
        Vector3 right = transform.position - Vector3.left * enemyOffset;
        Vector3 down = transform.position - Vector3.up * enemyOffset;
        Vector3 up = transform.position - Vector3.down * enemyOffset;

        RaycastHit rayCast;
        Vector3 RayCastOffset = Vector3.zero;

        Debug.DrawRay(left, transform.forward * enemyDetectionDis, Color.cyan);
        Debug.DrawRay(right, transform.forward * enemyDetectionDis, Color.cyan);
        Debug.DrawRay(up, transform.forward * enemyDetectionDis, Color.cyan);
        Debug.DrawRay(down, transform.forward * enemyDetectionDis, Color.cyan);

        if (Physics.Raycast(left, transform.forward, out rayCast, enemyDetectionDis))
        {

            RayCastOffset += Vector3.right;


        }
        else if (Physics.Raycast(right, transform.forward, out rayCast, enemyDetectionDis))
        {
            RayCastOffset += Vector3.left;

        }
        if (Physics.Raycast(up, transform.forward, out rayCast, enemyDetectionDis))
        {

            RayCastOffset += Vector3.down;

        }
        else if (Physics.Raycast(down, transform.forward, out rayCast, enemyDetectionDis))
        {
            RayCastOffset += Vector3.up;

        }

        if (RayCastOffset != Vector3.zero)
        {

            transform.Rotate(RayCastOffset * 5 * Time.deltaTime);

        }
        else
        {
            Turn();

        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {

            collision.gameObject.GetComponent<PlayerStatsLV5>().Damage(damage);
            Destroy(this.gameObject);


        }
    }
}
