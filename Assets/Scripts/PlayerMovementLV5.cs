using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLV5 : MonoBehaviour {

    public float speed = 5;
    public float turnSpeed = 5;
    public float fireRate = 0.2f;
    public GameObject bullet1;
    public GameObject bullet2;
    public Transform bulletExit1;
    public Transform bulletExit2;
    public float rotationOffset = -25f;
    public GameObject playerShip;
    Rigidbody rbd;
    int rotationAxis = 0;
    bool barrelRolling = false;
    Quaternion auxiliar;

	// Use this for initialization
	void Awake () {

        rbd = this.gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

       
        fireRate = fireRate - Time.deltaTime;
        ReadInputs();
        //BarrellRoll();
       

    }



    void ReadInputs() {

        if (Input.GetAxis("Horizontal") > 0.5f && (playerShip.transform.eulerAngles.z > 330 || playerShip.transform.eulerAngles.z < 30))
        {

            rotationAxis = 1;
            Rotation(rotationAxis);


        }
        else if (Input.GetAxis("Horizontal") < -0.5f && (playerShip.transform.eulerAngles.z < 30 || playerShip.transform.eulerAngles.z > 330))
        {

            rotationAxis = -1;
            Rotation(rotationAxis);

        }
        else if (Input.GetAxis("Horizontal") > -0.3f && Input.GetAxis("Horizontal") < 0.3f)
        {
            rotationAxis = 0;
            Rotation(rotationAxis);

        }
        if ((this.transform.eulerAngles.x > 270 || this.transform.eulerAngles.x < 90) && Input.GetAxis("Vertical") > 0.3)
        {

            this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(turnSpeed * Time.deltaTime * -Input.GetAxis("Vertical"), Time.deltaTime * turnSpeed * Input.GetAxis("Horizontal"), 0);
        }
        else if ((this.transform.eulerAngles.x > 260 || this.transform.eulerAngles.x < 80) && Input.GetAxis("Vertical") < -0.3)
        {

            this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(turnSpeed * Time.deltaTime * -Input.GetAxis("Vertical"), Time.deltaTime * turnSpeed * Input.GetAxis("Horizontal"), 0);

        }
        else {

            this.transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, Time.deltaTime * turnSpeed * Input.GetAxis("Horizontal"), 0);

        }
        this.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }

    }
    void Shoot()
    {

        fireRate = 0.2f;
        Instantiate(bullet1, bulletExit1.position, bulletExit1.rotation);
        Instantiate(bullet2, bulletExit2.position, bulletExit2.rotation);

    }
    void Rotation(float x)
    {
        if (x == 0)
        {

            if (playerShip.transform.eulerAngles.z >= 300 && playerShip.transform.eulerAngles.z != 0)
            {


                if (playerShip.transform.eulerAngles.z > 355)
                {

                    playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x, this.transform.eulerAngles.y, 0);

                }
                else {

                    playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x, this.transform.eulerAngles.y, playerShip.transform.eulerAngles.z - rotationOffset * Time.deltaTime);

                }

            }
            else if (playerShip.transform.eulerAngles.z <= 60 && playerShip.transform.eulerAngles.z != 0)
            {
                if (playerShip.transform.eulerAngles.z < 5)
                {

                    playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x, this.transform.eulerAngles.y, 0);

                }
                else {

                    playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x, this.transform.eulerAngles.y, playerShip.transform.eulerAngles.z + rotationOffset * Time.deltaTime);


                }
            }
        }
        else
        {
            playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x, this.transform.eulerAngles.y, playerShip.transform.eulerAngles.z + x * rotationOffset * Time.deltaTime);
        }  
       

    }
    void BarrellRoll() {

        //En proceso de funcionar
        if (Input.GetKeyDown(KeyCode.Z) && !barrelRolling)
        {
            auxiliar = this.transform.rotation;
            barrelRolling = true;
            auxiliar.y = auxiliar.y + 180;
            
        }
        else if(barrelRolling){

            this.transform.Rotate(Vector3.up * 10 * Time.deltaTime);
            if (this.transform.rotation.y == auxiliar.y) {

                barrelRolling = false;

            }

        }


    }
}
