using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLV5 : MonoBehaviour {

    public float speed = 5;
    public float turnSpeed = 5;
    public float fireRate = 0.1f;
    public GameObject bullet1;
    public GameObject bullet2;
    public Transform bulletExit1;
    public Transform bulletExit2;
    Rigidbody rbd;
	// Use this for initialization
	void Awake () {

        rbd = this.gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        fireRate = fireRate - Time.deltaTime;
        ReadInputs();
        

    }

    void ReadInputs() {

        /*this.transform.position = this.transform.position + new Vector3(turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Time.deltaTime * turnSpeed * Input.GetAxis("Vertical"), Time.deltaTime * speed);
        this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Time.deltaTime * turnSpeed * Input.GetAxis("Vertical"), 0);*/
        //rbd.velocity = new Vector3(turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Time.deltaTime * turnSpeed * Input.GetAxis("Vertical"), Time.deltaTime * speed);
        this.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
        this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(turnSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Time.deltaTime * turnSpeed * Input.GetAxis("Horizontal"), 0);
        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }

    }
    void Shoot()
    {

        fireRate = 0.1f;
        Instantiate(bullet1, new Vector3(bulletExit1.position.x, bulletExit1.position.y, bulletExit1.position.z), Quaternion.identity);
        Instantiate(bullet2, new Vector3(bulletExit2.position.x, bulletExit2.position.y, bulletExit2.position.z), Quaternion.identity);

    }
}
