using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV4EnemySimpleIA : EnemyIALv4 {

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {


            collision.gameObject.GetComponent<PlayerLv4Manager>().Damage(15);
            Destroy(this.gameObject);


        }
    }


}
