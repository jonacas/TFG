using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 3;
    public float fireRate = 0.5f;
    public bool left = true;
    public bool right = true;
    public GameObject bullet;
    public Transform bulletPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fireRate = fireRate - Time.deltaTime;
        Inputs();
        
	}

    void Inputs() {

        float m_move = Input.GetAxis("Horizontal");

        if (right && m_move >= 0) { this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0); }
        else if (left && m_move <= 0) { this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0); }

        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }
    }
    void Shoot() {

        fireRate = 0.3f;
        Instantiate(bullet,new Vector3(this.transform.position.x,this.transform.position.y + this.GetComponent<SpriteRenderer>().bounds.size.y/2,0), Quaternion.identity);

    }
}
