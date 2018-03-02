using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour {

    public static Level1Manager currentInstance;
    public bool right = false;
    public GameObject enemy;
    GameObject[,] enemies = new GameObject[11, 5];
    int initPosX = -5;
    int initPosY = 7;
    float offset = 1f;
    Vector2 enemyBounds;

	// Use this for initialization
	void Awake () {

        currentInstance = this;
        enemyBounds = enemy.GetComponent<SpriteRenderer>().bounds.size *1.35f;
        for (int row = 0; row < 11; row++) {
            for (int col = 0; col < 5; col++) {

                enemies[row, col] = Instantiate(enemy,new Vector2(initPosX + enemyBounds.x*row + offset, initPosY - enemyBounds.y*col - offset), Quaternion.identity);

            }
        }

		
	}

}
