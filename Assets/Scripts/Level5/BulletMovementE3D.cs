using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementE3D : MonoBehaviour {

    float timer = 2f;
    public int damage = 5;
    // Update is called once per frame
    void Start()
    {

        //GetComponent<Rigidbody>().AddForce(this.transform.up * 10000);

    }

    void Update()
    {
        transform.position += transform.forward * 300 * Time.deltaTime;
        timer = timer - Time.deltaTime;
        if (timer < 0 && this.gameObject.name.Contains("Clone"))
        {

            Destroy(this.gameObject);

        }

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerStatsLV5>().Damage(damage);
            Destroy(this.gameObject);

        }

    }
}
