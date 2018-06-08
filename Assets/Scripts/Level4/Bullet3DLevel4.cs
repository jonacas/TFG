using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3DLevel4 : MonoBehaviour {

    public float speed = 100;
    float timer = 2f;

    void Start()
    {

    }

    void Update()
    {
        
        timer = timer - Time.deltaTime;
        if (timer < 0 && this.gameObject.name.Contains("Clone"))
        {

            Destroy(this.gameObject);

        }

    }
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.forward * speed * Time.fixedDeltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Enemy") {

            collision.gameObject.GetComponent<EnemyIALv4>().Damage();
            Destroy(this.gameObject);

        }
    }
}
