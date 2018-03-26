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


        MoveBounds();
        
        

	}

    public void MoveEnemy(Vector3 v) {

        transform.position = transform.position + v * Time.deltaTime;

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

        Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y - EnemyBounds.y / 2, 0), Quaternion.identity);

    }
  
}
