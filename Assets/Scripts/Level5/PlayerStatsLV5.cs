using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsLV5 : MonoBehaviour {

    public static PlayerStatsLV5 currentInstance;
    public int LP = 100;
    public Slider lifeBar;
    public Slider specialShootBar;
    int currentLP;
	// Use this for initialization
	void Start () {

        currentInstance = this;
        currentLP = LP;
        lifeBar.value = currentLP;
    }


    public void Damage(int damage) {

        currentLP = currentLP - damage;
        lifeBar.value = currentLP;
        if (currentLP <= 0 ) {
            LevelChange.currentInstance.LoadLevel("Level5");
            Destroy(this.gameObject);

        }
    }
}
