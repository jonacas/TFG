using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLV5 : MonoBehaviour {

    public Transform target;
    public GameObject Bullet;
    public Transform bulletExit1;
    public Transform bulletExit2;
    public float fireRate = 0.5f;
    public float LP = 4;
    Vector3 initialPosition;
    float speed = 10f;
    float rotationOffset = 0.5f;
    float offset = 2f;
    float detectionDis = 60f;
	// Use this for initialization
	void Start () {

        initialPosition = this.gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {


        if (Vector3.Distance(target.position, initialPosition) <= 500) {
            Move();
            Detection();
        }
        else{

            this.transform.position = Vector3.MoveTowards(this.transform.position, initialPosition, 20 * Time.deltaTime);

        }

        
        if (Vector3.Distance(this.transform.position, target.transform.position) < 300 && fireRate <= -2) {

            Shoot();


        }
        fireRate = fireRate - Time.deltaTime;
	}


    void Move() {

        transform.position += transform.forward * speed * Time.deltaTime;

    }

    void Turn() {

        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationOffset * Time.deltaTime);


    }

    void Detection() {

        Vector3 left = transform.position - Vector3.right * offset;
        Vector3 right = transform.position - Vector3.left * offset;
        Vector3 down = transform.position - Vector3.up * offset;
        Vector3 up = transform.position - Vector3.down * offset;

        RaycastHit rayCast;
        Vector3 RayCastOffset = Vector3.zero;

        Debug.DrawRay(left,transform.forward * detectionDis,Color.cyan);
        Debug.DrawRay(right, transform.forward * detectionDis, Color.cyan);
        Debug.DrawRay(up, transform.forward * detectionDis, Color.cyan);
        Debug.DrawRay(down, transform.forward * detectionDis, Color.cyan);

        if (Physics.Raycast(left,transform.forward, out rayCast, detectionDis)) {

            RayCastOffset += Vector3.right;
            if (rayCast.collider.gameObject.tag == "Player") {

                Shoot();

            }

        }
        else if (Physics.Raycast(right, transform.forward, out rayCast, detectionDis))
        {
            RayCastOffset += Vector3.left;
            if (rayCast.collider.gameObject.tag == "Player")
            {

                Shoot();

            }
        }
        if (Physics.Raycast(up,transform.forward, out rayCast, detectionDis)) {

            RayCastOffset += Vector3.down;
            if (rayCast.collider.gameObject.tag == "Player")
            {

                Shoot();

            }

        }
        else if (Physics.Raycast(down, transform.forward, out rayCast, detectionDis))
        {
            RayCastOffset += Vector3.up;
            if (rayCast.collider.gameObject.tag == "Player")
            {

                Shoot();

            }
        }

        if (RayCastOffset != Vector3.zero)
        {

            transform.Rotate(RayCastOffset * 5 * Time.deltaTime);

        }
        else {
            Turn();

        }

    }

    void Shoot() {

        if (fireRate <= 0) {

            fireRate = 0.5f;
            Instantiate(Bullet, bulletExit1.position, bulletExit1.rotation);
            Instantiate(Bullet, bulletExit2.position, bulletExit2.rotation);


        }

    }


    public void Damage() {

        LP -= 1;
        
        if (LP <= 0) {

            PlayerStatsLV5.currentInstance.specialShootBar.value += 1;
            Instantiate(Level5Manager.currentInstance.explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject,0.25f);
            

        }


    }

    public void Defeat() {


        Instantiate(Level5Manager.currentInstance.explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject, 0.25f);


    } 
}
