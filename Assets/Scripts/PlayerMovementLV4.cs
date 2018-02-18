using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLV4 : MonoBehaviour {


    public float speed = 5f;
    bool left = true;
    bool right = true;
    bool up = true;
    bool down = true;
    Vector3 ScreenBounds;
    Vector2 PlayerBounds;

    // Use this for initialization
    void Awake()
    {

        ScreenBounds = new Vector2(10f, 5.5f);
        PlayerBounds = this.GetComponent<MeshRenderer>().bounds.size;

    }

    // Update is called once per frame
    void Update () {

        print(ScreenBounds);
        ReadInputs();
        MoveBounds();

	}

    void ReadInputs() {

        float m_move = Input.GetAxis("Horizontal");
        float m_up = Input.GetAxis("Vertical");

        if (right && m_move > 0) { this.gameObject.transform.position = this.transform.position + new Vector3(speed * Time.deltaTime * m_move,0, 0); }
        else if (left && m_move < 0) { this.gameObject.transform.position = this.transform.position + new Vector3(speed * Time.deltaTime * m_move,0, 0); }
        if (up && m_up > 0) { this.gameObject.transform.position = this.transform.position + new Vector3(0, speed * Time.deltaTime * m_up, 0); }
        else if (down && m_up < 0) { this.gameObject.transform.position = this.transform.position + new Vector3(0, speed * Time.deltaTime * m_up, 0); }

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

}
