using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIALevel2 : MonoBehaviour {


    public GameObject player;
    public GameObject bullet;
    public GameObject Padre;
    public float attackDistance;
    public int HP = 2;
    float shootDealay = 0.5f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        shootDealay = shootDealay - Time.deltaTime;
       
        float distance = Mathf.Abs(transform.position.x - player.transform.position.x);
        
        if (distance < attackDistance && shootDealay <=0) {

            Shoot();
            
        }


	}

    void Shoot() {

        shootDealay = 2.5f;
        Instantiate(bullet, transform.position,transform.rotation);
        
        

    }

    public void Damage() {

        HP = HP - 1;
        if (HP <= 0) {

            Destroy(Padre);
            

        }


    }
}
