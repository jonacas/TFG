using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement1 : MonoBehaviour {

    float speed = 6;
    Vector2 ScreenBounds;
    // Use this for initialization
    void Awake () {

        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, speed * Time.deltaTime, 0);
        InWorld();
	}

    void InWorld() {

        if (this.transform.position.y > ScreenBounds.y + this.GetComponent<SpriteRenderer>().bounds.size.y/2) {

            Destroy(this.gameObject);
        }



    }
}
