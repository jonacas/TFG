using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV3EnemyIA : MonoBehaviour {

    public int HP = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Damage(int damage) {

        HP -= damage;
        if (HP <= 0) {

            LV3Manager.currentInstance.SliderChangeValue();
            Destroy(this.gameObject);

        }


    }
}
