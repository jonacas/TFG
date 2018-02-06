using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 3;
    public float fireRate = 0.5f;
    public bool left = true;
    public bool right = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Inputs();
	}

    void Inputs() {

        float m_move = Input.GetAxis("Horizontal");

        if (right && m_move >= 0) { this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0); }
        else if (left && m_move <= 0) { this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0); }
    }
}
