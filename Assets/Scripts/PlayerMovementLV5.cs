using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLV5 : MonoBehaviour {

    public float speed = 5;
    public float turnSpeed = 5;
    Rigidbody rbd;
	// Use this for initialization
	void Awake () {

        rbd = this.gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        ReadInputs();

	}

    void ReadInputs() {

        /*this.transform.position = this.transform.position + new Vector3(turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Time.deltaTime * turnSpeed * Input.GetAxis("Vertical"), Time.deltaTime * speed);
        this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Time.deltaTime * turnSpeed * Input.GetAxis("Vertical"), 0);*/
        rbd.velocity = new Vector3(turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Time.deltaTime * turnSpeed * Input.GetAxis("Vertical"), Time.deltaTime * speed);
        this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(turnSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Time.deltaTime * turnSpeed * Input.GetAxis("Horizontal"), 0);

    }
}
