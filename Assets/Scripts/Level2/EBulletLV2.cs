using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletLV2 : MonoBehaviour {

    float speed = 5;
    Vector2 ScreenBounds;
    Vector3 playerPosition;
    Vector3 pathToPlayer;
    // Use this for initialization
    void Awake()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Start()
    {

        playerPosition = PlayerMovementLV2.currentInstance.transform.position;
        //float angleZ = Vector2.Angle(new Vector2(this.transform.position.x,this.transform.position.y), new Vector2(playerPosition.x, playerPosition.y));
        this.transform.LookAt(playerPosition);
        this.transform.localEulerAngles = new Vector3(0,0,transform.localEulerAngles.z);
        pathToPlayer = (playerPosition - transform.position)/ Vector3.Distance(playerPosition,transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(pathToPlayer * speed*Time.deltaTime);
        InWorld();
    }

    void InWorld()
    {

        if (this.transform.position.y < -ScreenBounds.y + this.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2)
        {

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Level2M.currentInstance.death = true;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }
}
