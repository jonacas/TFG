using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLv3Shoot : MonoBehaviour {

    public Transform[] bullets;
	// Use this for initialization
	void Start () {

        bullets = this.GetComponentsInChildren<Transform>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Z)) {

            foreach (Transform bullet in bullets)
            {
                if (bullet.tag == "bullet") {
                    Instantiate(bullet.gameObject, this.transform.position, Quaternion.identity);
                }
                
            }

        }
        
		
	}
}
