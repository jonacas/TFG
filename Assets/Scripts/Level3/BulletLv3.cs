using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLv3 : MonoBehaviour {


    public float speed = 3;
    public float rotation = 30;
	// Use this for initialization
	void Start () {

        transform.Rotate(Vector3.forward * rotation);

    }
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.name.Contains("Clone"))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
	}
}
