using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {


    int life = 100;


    public void Damage() {

        life -= 1;
        if (life <= 0) {

            Level5Manager.currentInstance.ObjectiveDestroy();
            Destroy(this.gameObject);


        }

    }
}
