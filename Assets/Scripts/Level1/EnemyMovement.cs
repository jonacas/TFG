using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject bullet;
    Vector2 ScreenBounds;
    Vector2 EnemyBounds;

    void Awake()
    {

        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        EnemyBounds = this.GetComponent<SpriteRenderer>().bounds.size;


    }
    // Update is called once per frame
    void Update () {

        if (Level1Manager.currentInstance.right)
        {

            transform.position = transform.position + Vector3.right * Time.deltaTime;
        }
        else {

            transform.position = transform.position + Vector3.left * Time.deltaTime;

        }
        MoveBounds();

	}

    void MoveBounds()
    {
        if (this.transform.position.x <= (-(ScreenBounds.x) + EnemyBounds.x / 2))
        {

            Level1Manager.currentInstance.right = true;

        }

        else if (this.transform.position.x >= ((ScreenBounds.x) - EnemyBounds.x / 2)) {

            Level1Manager.currentInstance.right = false;

        }
    }

    public void Shoot() {


    }
  
}
