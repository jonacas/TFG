using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLV3 : MonoBehaviour {

    public static PlayerMovementLV3 currentInstance;
    public float speed = 3;
    public float fireRate = 0.1f;
    public float impulseForce = 200;
    public float dashDistance;
    public float rotationOffset = -25f;
    public GameObject bullet;
    public GameObject specialBullet;
    public Transform bulletExit1;
    public Transform bulletExit2;
    public GameObject Collider;
    bool left = true;
    bool right = true;
    bool up = true;
    bool down = true;
    bool m_right = false;
    bool m_left = false;
    Vector2 ScreenBounds;
    Vector2 PlayerBounds;
    float impulseRate = 0.5f;
    bool dashing = false;
    float impulse = 2;
    float impulseSide;
    // Use this for initialization
    void Awake()
    {
        currentInstance = this;
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
        #region Movement
        if (!dashing) { Move(); }
        #endregion

        #region Shoot
        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }

        if (Input.GetAxis("Fire2") != 0 && LV3Manager.currentInstance.specialShootBar.value == 4) {

            SpecialShoot();


        }

        #endregion

        #region Dash
        if (Input.GetAxis("Bumper1") != 0 && impulseRate <= 0 && !dashing) {

            impulseSide = Input.GetAxis("Bumper1");
            if (impulseSide < 0 && left) {

                dashing = true;
                impulse = 2;
                Collider.SetActive(false);


            }
            else if (impulseSide > 0 && right) {

                dashing = true;
                impulse = 2;
                Collider.SetActive(false);

            }
           
        }
        if (dashing) {

            Dash();

        }
        #endregion
    }

    void Dash() {

        if (impulse <= 0)
        {

            dashing = false;
            impulse = 2;
            impulseRate = 0.5f;
            Collider.SetActive(true);
        }
        else if (impulseSide < 0 && !left)
        {

            dashing = false;
            impulse = 2;
            impulseRate = 0.5f;
            Collider.SetActive(true);

        }
        else if (impulseSide > 0 && !right)
        {

            dashing = false;
            impulse = 2;
            impulseRate = 0.5f;
            Collider.SetActive(true);

        }
        this.transform.Translate(Vector3.right * impulseForce * impulseSide * Time.deltaTime);
        impulse -= impulseForce * Time.deltaTime;
  
    }


    void Move() {

        float m_move = Input.GetAxis("Horizontal");
        float m_up = Input.GetAxis("Vertical");

        if (right && m_move > 0.3f)
        {
            this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0);
            if (!m_right) { Rotation(1); }
            m_right = true;
            m_left = false;

        }
        else if (left && m_move < -0.3f)
        {
            this.transform.position = this.transform.position + new Vector3(m_move * Time.deltaTime * speed, 0, 0);
            if (!m_left) { Rotation(-1); }
            m_right = false;
            m_left = true;
        }
        else /*if (m_move == 0)*/
        {
            if (m_left)
            {
                Rotation(1);
            }
            else if (m_right)
            {
                Rotation(-1);
            }
            m_right = false;
            m_left = false;
        }
        if (up && m_up >= 0) { this.transform.position = this.transform.position + new Vector3(0, m_up * Time.deltaTime * speed, 0); }
        else if (down && m_up < 0) { this.transform.position = this.transform.position + new Vector3(0, m_up * Time.deltaTime * speed, 0); }
    } 

    void Shoot()
    {

        fireRate = 0.1f;
        Instantiate(bullet, new Vector3(bulletExit1.position.x, bulletExit1.position.y, 0), Quaternion.identity);
        Instantiate(bullet, new Vector3(bulletExit2.position.x, bulletExit2.position.y, 0), Quaternion.identity);

    }
    void SpecialShoot() {

        if (EnemySpecialShootManager.currentInstance.Enemies.Count <= 0) {

            return;
        }
        LV3Manager.currentInstance.specialShootBar.value = 0;
        foreach (Transform enemyTransform in EnemySpecialShootManager.currentInstance.Enemies) {

           GameObject specialBulletObject = Instantiate(specialBullet, new Vector3((bulletExit1.position.x + bulletExit2.position.x) / 2, (bulletExit1.position.y + bulletExit2.position.y) / 2, 0), Quaternion.identity);

            specialBulletObject.GetComponent<SpecialBulletLV3>().GoFor(enemyTransform);

        }


    }
    void MoveBounds()
    {
        left = true;
        right = true;
        up = true;
        down = true;
        Vector3 playerBounds = Camera.main.WorldToViewportPoint(this.transform.position);
        if (playerBounds.x <= 0.05)
        {
            left = false;
        }
        else
        {
            if (playerBounds.x >= 0.95)
            {
                right = false;
            }
        }
        if (playerBounds.y <= 0.05)
        {

            down = false;

        }
        else
        {

            if (playerBounds.y >= 0.95)
            {

                up = false;

            }

        }
    }
    void Rotation(float x) {

        this.transform.eulerAngles= new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, x * rotationOffset);

    }

    public bool GetDasing() {

        return dashing;

    }
}
