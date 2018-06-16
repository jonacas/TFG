using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLV3 : MonoBehaviour {

    public float speed = 3;
    public float fireRate = 0.1f;
    public float impulseForce = 2;
    public float rotationOffset = -25f;
    public GameObject bullet;
    public Transform bulletExit1;
    public Transform bulletExit2;
    public Camera m_camera;
    bool left = true;
    bool right = true;
    bool up = true;
    bool down = true;
    bool m_right = false;
    bool m_left = false;
    Vector2 ScreenBounds;
    Vector2 PlayerBounds;
    float impulseRate = 0.5f;
    // Use this for initialization
    void Awake()
    {

        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        PlayerBounds = this.GetComponent<MeshRenderer>().bounds.size;

    }

    // Update is called once per frame
    void Update()
    {
        fireRate = fireRate - Time.deltaTime;
        impulseRate = impulseRate - Time.deltaTime;
        Inputs();
        MoveBounds();

    }

    void Inputs()
    {
        float m_move = Input.GetAxis("Horizontal");
        float m_up = Input.GetAxis("Vertical");

        if (right && m_move > 0) {
            this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0);
            if (!m_right) { Rotation(1); }
            m_right = true;
            m_left = false;
         
        }
        else if (left && m_move < 0) {
            this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0);
            if (!m_left) { Rotation(-1); }
            m_right = false;
            m_left = true;
        }
        else if (m_move == 0) {
            if (m_left) {
                Rotation(1);
            }
            else if (m_right) {
                Rotation(-1);
            }
            m_right = false;
            m_left = false;
        }
        if (up && m_up >= 0) { this.transform.position = this.transform.position + new Vector3(0, m_up * Time.deltaTime * speed, 0); }
        else if (down && m_up < 0) { this.transform.position = this.transform.position + new Vector3(0, m_up * Time.deltaTime * speed, 0); }

        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }

        if (Input.GetAxis("Bumper1") != 0 && impulseRate <= 0) {

            this.transform.Translate(Vector3.right * impulseForce * Input.GetAxis("Bumper1"));
            impulseRate = 0.5f;
        }
    }
    void Shoot()
    {

        fireRate = 0.1f;
        Instantiate(bullet, new Vector3(bulletExit1.position.x, bulletExit1.position.y, 0), Quaternion.identity);
        Instantiate(bullet, new Vector3(bulletExit2.position.x, bulletExit2.position.y, 0), Quaternion.identity);

    }
    void MoveBounds()
    {
        left = true;
        right = true;
        up = true;
        down = true;
        if (this.transform.position.x <= (-(ScreenBounds.x) + PlayerBounds.x / 2))
        {
            left = false;
        }
        else
        {
            if (this.transform.position.x >= ((ScreenBounds.x) - PlayerBounds.x / 2))
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
    void Rotation(float x) {

        this.transform.eulerAngles= new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, x * rotationOffset);

    }
}
