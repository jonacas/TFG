using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV3EnemyIA : MonoBehaviour {

    public int HP = 0;
    bool defeated = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Damage(int damage) {

        HP -= damage;
        if (HP <= 0) {

            if (damage != 100 && !defeated) {
                defeated = true;
                LV3Manager.currentInstance.SliderChangeValue();
            }
            Destroy(this.gameObject);

        }


    }
}
