using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement3D : MonoBehaviour {

	
	// Update is called once per frame
	void Start () {

        GetComponent<Rigidbody>().AddForce(this.transform.up * 10000);

    }
}
