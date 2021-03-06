﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulletLV3 : MonoBehaviour {


    Transform Objective;
    bool attack = false;
    public int damage = 100;
    public float speed = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (attack) {

            if (Objective == null) {

                Destroy(this.gameObject);

            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, Objective.position, speed * Time.deltaTime);

        }


	}

    public void GoFor(Transform enemy) {

        Objective = enemy;
        attack = true;


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<LV3EnemyIA>().Damage(damage);
            Destroy(this.gameObject);

        }
    }

}
