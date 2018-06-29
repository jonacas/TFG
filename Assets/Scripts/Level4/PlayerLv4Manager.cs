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

            LevelChange.currentInstance.LoadLevel("Level4");

            Destroy(this.gameObject);


        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") {

            Damage(10);
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;


        }
    }


}
