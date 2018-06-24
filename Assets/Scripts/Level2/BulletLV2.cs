using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLV2 : MonoBehaviour {
    float speed = 6;
    Vector2 ScreenBounds;
    // Use this for initialization
    void Awake()
    {

        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, speed * Time.deltaTime, 0);
        InWorld();
    }

    void InWorld()
    {

        if (this.transform.position.y > ScreenBounds.y + this.GetComponent<SpriteRenderer>().bounds.size.y / 2)
        {

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<EnemyIALevel2>().Damage();
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "PowerUp") {

            if (collision.gameObject.name.Contains("Double")) {

                PlayerMovementLV2.currentInstance.SpecialShootTimer = 5;
                PlayerMovementLV2.currentInstance.SpecialShoot = true;
                PlayerMovementLV2.currentInstance.shoot = Shoot.Double;
                

            }

            else if (collision.gameObject.name.Contains("Special")) {

                PlayerMovementLV2.currentInstance.SpecialShootTimer = 5;
                PlayerMovementLV2.currentInstance.SpecialShoot = true;
                PlayerMovementLV2.currentInstance.shoot = Shoot.Special;

            }

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }
}
