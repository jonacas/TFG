using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LV3Manager : MonoBehaviour {

    public static LV3Manager currentInstance;
    public GameObject playerLV3;
    public GameObject playerCollider;
    public GameObject[] arrayLifes = new GameObject[3];
    public Slider specialShootBar;
    int lifes = 3;
    float timerDeath = 1;
    float timerCollider = 0;
    public bool death = false;
    bool gameOver = false;

    void Start () {

        currentInstance = this;

	}
	
	// Update is called once per frame
	void Update () {

        Revive();
        if (timerCollider > 0)
        {

            timerCollider -= Time.deltaTime;
            PlayerMovementLV3.currentInstance.gameObject.GetComponent<MeshRenderer>().enabled = !PlayerMovementLV3.currentInstance.gameObject.GetComponent<MeshRenderer>().enabled;

        }
        else if(!playerCollider.activeSelf) {

            playerCollider.SetActive(true);
            PlayerMovementLV3.currentInstance.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

	}

    public void SliderChangeValue() {
        specialShootBar.value = specialShootBar.value + 1;
    }

    void Revive()
    {

        if (death && !gameOver)
        {

            timerDeath = timerDeath - Time.deltaTime;

            if (timerDeath <= 0)
            {

                Instantiate(playerLV3, Vector3.zero, playerLV3.transform.rotation);
                death = false;
                lifes--;
                timerDeath = 1;
                playerCollider.SetActive(false);
                timerCollider = 3;
                arrayLifes[lifes].SetActive(false);
            }
        }
        if (lifes == 0)
        {

            gameOver = true;

        }
    }

}
