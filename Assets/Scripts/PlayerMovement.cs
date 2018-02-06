using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 3;
    public float fireRate = 0.5f;
    public bool left = true;
    public bool right = true;
    public GameObject bullet;
    public Camera m_camera;
    Vector2 ScreenBounds;
    Vector2 PlayerBounds;
	// Use this for initialization
	void Awake () {

        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        PlayerBounds = this.GetComponent<SpriteRenderer>().bounds.size;

    }
	
	// Update is called once per frame
	void Update () {
        fireRate = fireRate - Time.deltaTime;
        Inputs();
        MoveBounds();
       
	}

    void Inputs() {

        float m_move = Input.GetAxis("Horizontal");

        if (right && m_move >= 0) { this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0); }
        else if (left && m_move <= 0) { this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0); }

        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }
    }
    void Shoot() {

        fireRate = 0.3f;
        Instantiate(bullet,new Vector3(this.transform.position.x,this.transform.position.y + PlayerBounds.y/2,0), Quaternion.identity);

    }
    void MoveBounds() {
        left = true;
        right = true;
        if (this.transform.position.x <= (-(ScreenBounds.x) + PlayerBounds.x / 2))
        {

            left = false;
            
        }
        else {
           
            if (this.transform.position.x >= ((ScreenBounds.x) - PlayerBounds.x / 2))
            {

                right = false;
               
            }

        }
    }
}
