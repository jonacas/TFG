using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement1 : MonoBehaviour {

    float speed = 6;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, speed * Time.deltaTime, 0);
	}
}
