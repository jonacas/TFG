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
            Visible();
        }

	}

    void Visible() {

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        if ((screenPoint.x < 0 || screenPoint.x > 1) || (screenPoint.y < 0 || screenPoint.y > 1))
        {

            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            LV3Manager.currentInstance.death = true;
            Destroy(PlayerMovementLV3.currentInstance.gameObject);
            Destroy(this.gameObject);

        }

        
    }
}
