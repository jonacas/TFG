using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet3DLevel4 : MonoBehaviour {

    public float speed = 1;
    float timer = 2f;
    public float damage = 5;
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
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLv4Manager>().Damage(damage);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Obstacle")
        {

            Destroy(this.gameObject);

        }
    }
}
