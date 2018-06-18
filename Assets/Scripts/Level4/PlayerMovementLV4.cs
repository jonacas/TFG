using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLV4 : MonoBehaviour {

    public static PlayerMovementLV4 currentInstance;
    public float fireRate = 0.2f;
    public float speed = 5f;
    public float rotationSpeed = -3f;
    public GameObject bullet1;
    public GameObject bullet2;
    public Transform bulletExit1;
    public Transform bulletExit2;
    bool left = true;
    bool right = true;
    bool up = true;
    bool down = true;
    float counterUp;
    float counterDown;
    float counterLeft;
    float counterRigth;
    int limit = 5;


    // Use this for initialization
    void Awake()
    {
        currentInstance = this;

    }

    // Update is called once per frame
    void Update () {

        fireRate = fireRate - Time.deltaTime;
        ReadInputs();
        MoveBounds();

	}

    void ReadInputs() {

        float m_move = Input.GetAxis("Horizontal");
        float m_up = Input.GetAxis("Vertical");

        if (right && m_move > 0) {

            this.gameObject.transform.position = this.transform.position + new Vector3(speed * Time.deltaTime * m_move,0, 0);

        }
        else if (left && m_move < 0) {

            this.gameObject.transform.position = this.transform.position + new Vector3(speed * Time.deltaTime * m_move,0, 0);

        }
        if (up && m_up > 0) {

            this.gameObject.transform.position = this.transform.position + new Vector3(0, speed * Time.deltaTime * m_up, 0);

        }
        else if (down && m_up < 0) {

            this.gameObject.transform.position = this.transform.position + new Vector3(0, speed * Time.deltaTime * m_up, 0);

        }
        CameraBoundsMove(m_move, m_up);
        if (m_move > 0.5f && (this.transform.eulerAngles.z > 330 || this.transform.eulerAngles.z < 30))
        {
            Rotation(m_move);
        }
        else if (m_move < -0.5f && (this.transform.eulerAngles.z < 30 || this.transform.eulerAngles.z > 330))
        {
            Rotation(m_move);
        }
        else if (m_move > -0.3f && m_move < 0.3f)
        {
            Rotation(0);
        }
        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }

    }
    void Shoot()
    {

        fireRate = 0.2f;
        Instantiate(bullet1, bulletExit1.position, bulletExit1.rotation);
        Instantiate(bullet2, bulletExit2.position, bulletExit2.rotation);

    }

    void MoveBounds()
    {
        left = true;
        right = true;
        up = true;
        down = true;
        Vector3 PlayerScreenPoint = Camera.main.WorldToViewportPoint(this.transform.position);

        if (PlayerScreenPoint.x <= 0.15)
        {
            left = false;
        }
        else if (PlayerScreenPoint.x >= 0.85) {

            right = false;
        }
        if (PlayerScreenPoint.y <= 0.15)
        {

            down = false;

        }
        else if(PlayerScreenPoint.y >= 0.85)
        {

            up = false;

        }
    }
    void CameraBoundsMove(float horizontal, float vertical) {

        if (!left && counterLeft < limit && horizontal < 0) {

            counterLeft += -(speed * Time.deltaTime * horizontal);
            counterRigth += speed * Time.deltaTime * horizontal;
            Camera.main.transform.position = Camera.main.transform.position + new Vector3(speed * Time.deltaTime * horizontal, 0, 0);

        }
        else if (!right && counterRigth < limit && horizontal > 0) {

            counterLeft += -(speed * Time.deltaTime * horizontal);
            counterRigth += speed * Time.deltaTime * horizontal;
            Camera.main.transform.position = Camera.main.transform.position + new Vector3(speed * Time.deltaTime * horizontal, 0, 0);

        }
        if (!down && counterDown < limit && vertical < 0)
        {

            counterDown += -(speed * Time.deltaTime * vertical);
            counterUp += speed * Time.deltaTime * vertical;
            Camera.main.transform.position = Camera.main.transform.position + new Vector3(0, speed * Time.deltaTime * vertical, 0);

        }
        else if (!up && counterUp < limit & vertical > 0) {

            counterDown += -(speed * Time.deltaTime * vertical);
            counterUp += speed * Time.deltaTime * vertical;
            Camera.main.transform.position = Camera.main.transform.position + new Vector3(0, speed * Time.deltaTime * vertical, 0);

        }

    }

    void Rotation(float horizontal) {

        if (horizontal == 0)
        {

            if (this.transform.eulerAngles.z >= 300 && this.transform.eulerAngles.z != 0)
            {


                if (this.transform.eulerAngles.z > 355)
                {

                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, 0);

                }
                else
                {

                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z - rotationSpeed * Time.deltaTime);

                }

            }
            else if (this.transform.eulerAngles.z <= 60 && this.transform.eulerAngles.z != 0)
            {
                if (this.transform.eulerAngles.z < 5)
                {

                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, 0);

                }
                else
                {

                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z + rotationSpeed * Time.deltaTime);


                }
            }
        }
        else
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z + horizontal * rotationSpeed * Time.deltaTime);
        }


    }


}

