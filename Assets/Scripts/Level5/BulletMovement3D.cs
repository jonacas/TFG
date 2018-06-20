using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement3D : MonoBehaviour {

    float timer = 3f;
	// Update is called once per frame
	void Start () {

        GetComponent<Rigidbody>().AddForce(this.transform.up * 10000);
        
    }

    void Update()
    {

        timer = timer - Time.deltaTime;
        if (timer < 0 && this.gameObject.name.Contains("Clone")) {

            Destroy(this.gameObject);

        }

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") {

            collision.gameObject.GetComponent<EnemyLV5>().Damage();
            Destroy(this.gameObject);

        }
        
    }
}
