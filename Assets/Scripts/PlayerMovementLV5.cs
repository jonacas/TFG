using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLV5 : MonoBehaviour {

    public float speed = 5;
    public float turnSpeed = 5;
    public float fireRate = 0.2f;
    public GameObject bullet1;
    public GameObject bullet2;
    public Transform bulletExit1;
    public Transform bulletExit2;
    public float rotationOffset = -25f;
    Rigidbody rbd;
    int rotationAxis = 0;
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

        if (Input.GetAxis("Horizontal") > 0.5f && rotationAxis <= 0)
        {

            rotationAxis = 1;
            Rotation(rotationAxis);


        }
        else if (Input.GetAxis("Horizontal") < -0.5f && rotationAxis >= 0)
        {

            rotationAxis = -1;
            Rotation(rotationAxis);

        }
        else if(Input.GetAxis("Horizontal") > -0.15f && Input.GetAxis("Horizontal") < 0.15f)
        {
            rotationAxis = 0;
            Rotation(rotationAxis);

        }
        this.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
        this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(turnSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Time.deltaTime * turnSpeed * Input.GetAxis("Horizontal"), 0);
        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }

    }
    void Shoot()
    {

        fireRate = 0.2f;
        Instantiate(bullet1, bulletExit1.position, bulletExit1.rotation);
        Instantiate(bullet2, bulletExit2.position, bulletExit2.rotation);

    }
    void Rotation(float x)
    {

        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, x * rotationOffset);

    }
}
