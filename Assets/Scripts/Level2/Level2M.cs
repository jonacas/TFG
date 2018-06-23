using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2M : MonoBehaviour {

    public static Level2M currentInstance;
    public GameObject PlayerLV2;
    public GameObject[] arrayLifes = new GameObject[3];
    public GameObject[] arrayMrks = new GameObject[3];
    public GameObject boxDoubleShoot;
    public GameObject boxSpecialShoot;
    int lifes = 3;
    float timerDeath = 1;
    int markSelected = 0;
    bool gameOver = false;
    public bool death = false;

    void Start()
    {

        currentInstance = this;

    }

    void Update()
    {
        Revive();
        MarksUpdate();

    }

    void Revive()
    {

        if (death && !gameOver)
        {

            timerDeath = timerDeath - Time.deltaTime;

            if (timerDeath <= 0)
            {

                Instantiate(PlayerLV2, Vector3.up * -3, Quaternion.identity);
                death = false;
                lifes--;
                timerDeath = 1;
                arrayLifes[lifes].SetActive(false);
            }
        }
        if (lifes == 0)
        {

            gameOver = true;

        }
    }

    void MarksUpdate() {

        switch (PlayerMovementLV2.currentInstance.shoot) { 

        case Shoot.Basic:
                arrayMrks[0].SetActive(true);
                arrayMrks[1].SetActive(false);
                arrayMrks[2].SetActive(false);
                break;
        case Shoot.Double:
                arrayMrks[1].SetActive(true);
                arrayMrks[0].SetActive(false);
                arrayMrks[2].SetActive(false);
                break;
        case Shoot.Special:
                arrayMrks[2].SetActive(true);
                arrayMrks[1].SetActive(false);
                arrayMrks[0].SetActive(false);
                break;
        }
    }
}
