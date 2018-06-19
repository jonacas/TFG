using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLv4Manager : MonoBehaviour {

    public Slider lifeBar;
    float PlayerLife = 100;
    float PlayerCurrentLife;

	// Use this for initialization
	void Start () {

        lifeBar.value = PlayerLife;
        PlayerCurrentLife = PlayerLife;

	}
    public void Damage(float damage) {

        PlayerCurrentLife = PlayerCurrentLife - damage;
        lifeBar.value = PlayerCurrentLife;

        if (PlayerCurrentLife <= 0) {

            Destroy(this.gameObject);


        }




    }


}
