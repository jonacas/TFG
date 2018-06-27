using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLv3Shoot : MonoBehaviour {

    public Transform[] bullets;
    public MoveOnPathLv3 path;
    float fireRate = 0.15f;
	// Use this for initialization
	void Start () {

        bullets = this.GetComponentsInChildren<Transform>();

    }
	
	// Update is called once per frame
	void Update () {

        fireRate -= Time.deltaTime;

        if (path.transform.position == path.PathToFollow.pathPoints[path.currentWayPoint].position && path.stop && fireRate <= 0) {

            foreach (Transform bullet in bullets)
            {
                if (bullet.tag == "bullet") {
                    Instantiate(bullet.gameObject, this.transform.position, Quaternion.identity);
                }
                
            }
            fireRate = 0.15f;
        }
        
		
	}
}
