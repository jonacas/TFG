using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIALv4 : MonoBehaviour {

    public Transform bulletExit1;
    public Transform bulletExit2;
    public GameObject bullet;
    public GameObject Padre;
    public int HP = 10;
    float timer = 2;
	
	// Update is called once per frame
	void Update () {

        timer = timer - Time.deltaTime;
        if (timer<0) {
            Instantiate(bullet, bulletExit1.position, bulletExit1.rotation);
            Instantiate(bullet, bulletExit2.position,bulletExit2.rotation);
            timer = 2;
        }

	}

    public void Damage()
    {
        
        HP = HP - 1;
        if (HP <= 0)
        {

            Destroy(Padre);

        }
    }

}
