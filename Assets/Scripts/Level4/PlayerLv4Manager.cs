using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLv4Manager : MonoBehaviour {

    float PlayerLife = 100;
    float PlayerCurrentLife;

	// Use this for initialization
	void Start () {

        PlayerCurrentLife = PlayerLife;

	}
    public void Damage(float damage) {

        PlayerCurrentLife = PlayerCurrentLife - damage;

        if (PlayerCurrentLife <= 0) {

            Destroy(this.gameObject);


        }




    }


}
