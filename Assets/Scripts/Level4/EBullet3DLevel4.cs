using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet3DLevel4 : MonoBehaviour {

    public float speed = 1;
    float timer = 2f;
    Vector3 playerPosition;
    Vector3 pathToPlayer;

    void Start()
    {
        playerPosition = PlayerMovementLV4.currentInstance.transform.position;
        this.transform.LookAt(playerPosition);
        //pathToPlayer = (playerPosition - transform.position) / Vector3.Distance(playerPosition, transform.position);
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
        
        this.transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        //this.GetComponent<Rigidbody>().velocity = Vector3.back * speed * Time.fixedDeltaTime;
    }

    /*void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<EnemyIALv4>().Damage();
            Destroy(this.gameObject);

        }
    }*/
}
