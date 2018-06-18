using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementPLV3 : MonoBehaviour {

    public int damage = 1;
    float speed = 10;
    Vector3 ScreenBounds;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, speed * Time.deltaTime, 0);
        InWorld();
    }

    void InWorld()
    {
        ScreenBounds = Camera.main.WorldToViewportPoint(this.transform.position);
        if (ScreenBounds.y > 1.1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<LV3EnemyIA>().Damage(damage);
            Destroy(this.gameObject);

        }
    }
}
