using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shoot {Basic, Double, Special };

public class PlayerMovementLV2 : MonoBehaviour {

    public Shoot shoot = global::Shoot.Basic;
    public static PlayerMovementLV2 currentInstance;
    public float speed = 3;
    public float fireRate = 0.2f;
    public bool left = true;
    public bool right = true;
    public bool up = true;
    public bool down = true;
    public bool SpecialShoot;
    public GameObject bullet;
    public GameObject specialBullet;
    public Transform bulletExit1;
    public Transform bulletExit2;
    Vector2 ScreenBounds;
    Vector2 PlayerBounds;
    public float SpecialShootTimer = 5;
    
    
    // Use this for initialization
    void Awake()
    {
        currentInstance = this;
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        PlayerBounds = this.GetComponent<SpriteRenderer>().bounds.size;

    }

    // Update is called once per frame
    void Update()
    {
        fireRate = fireRate - Time.deltaTime;
        if (SpecialShoot)
        {

            SpecialShootTimer -= Time.deltaTime;

            if (SpecialShootTimer <= 0)
            {

                SpecialShoot = false;
                shoot = global::Shoot.Basic;
            }
        }
        else {

            shoot = global::Shoot.Basic;

        }
        Inputs();
        MoveBounds();

    }

    void Inputs()
    {

        float m_move = Input.GetAxis("Horizontal");
        float m_up = Input.GetAxis("Vertical");

        if (right && m_move >= 0) { this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0); }
        else if (left && m_move < 0) { this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0); }
        if (up && m_up >= 0) { this.transform.position = this.transform.position + new Vector3(0, m_up * Time.deltaTime * speed, 0); }
        else if (down && m_up < 0) { this.transform.position = this.transform.position + new Vector3(0, m_up * Time.deltaTime * speed, 0); }

        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }
    }
    void Shoot()
    {
        switch (shoot) {

            case global::Shoot.Basic:
                fireRate = 0.2f;
                Instantiate(bullet, new Vector3(this.transform.position.x, bulletExit1.position.y + (PlayerBounds.y/2), 0), Quaternion.identity);
                break;

            case global::Shoot.Double:
                fireRate = 0.2f;
                Instantiate(bullet, new Vector3(bulletExit1.position.x, bulletExit1.position.y, 0), Quaternion.identity);
                Instantiate(bullet, new Vector3(bulletExit2.position.x, bulletExit2.position.y, 0), Quaternion.identity);
                break;
            case global::Shoot.Special:
                fireRate = 0.2f;
                Instantiate(specialBullet, new Vector3(this.transform.position.x, bulletExit1.position.y + (PlayerBounds.y / 2), 0), Quaternion.identity);
                break;
        }
        

    }
    void MoveBounds()
    {
        left = true;
        right = true;
        up = true;
        down = true;
        if (this.transform.position.x <= (-(ScreenBounds.x/2) + PlayerBounds.x / 2))
        {
            left = false;
        }
        else
        {
            if (this.transform.position.x >= ((ScreenBounds.x/2) - PlayerBounds.x / 2))
            {
                right = false;
            }
        }
        if (this.transform.position.y <= (-(ScreenBounds.y) + PlayerBounds.y / 2))
        {

            down = false;

        }
        else
        {

            if (this.transform.position.y >= ((ScreenBounds.y) - PlayerBounds.y / 2))
            {

                up = false;

            }

        }
    }
}