using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLV5 : MonoBehaviour {

    public float speed = 5;
    public float turnSpeed = 5;
    public float fireRate = 0.2f;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject SpecialBullet;
    public Transform bulletExit1;
    public Transform bulletExit2;
    public Transform specialBulletExit;
    public float rotationOffset = -25f;
    public GameObject playerShip;
    bool specialShootHasObjective = false;
    int rotationAxisHorizontal = 0;
    int rotationAxisVertical = 0;
    bool lateralRolling = false;
    bool barrelRolling = false;
    float counterRotationUp = 0;
    float counterRotationDown = 0;
    int limitRotationVertical = 15;
    float lateralRotationCounter = 180;
    float barrelRotationCounter = 360;


    // Use this for initialization
    void Awake () {

        //rbd = this.gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        fireRate = fireRate - Time.deltaTime;
        if (!barrelRolling && !lateralRolling) {

            ReadInputs();

        }
       
        LateralRoll();
        BarellRoll();
       

    }



    void ReadInputs() {
        //Giro Horizontal
        if (Input.GetAxis("Horizontal") > 0.5f && (playerShip.transform.eulerAngles.z > 330 || playerShip.transform.eulerAngles.z < 30))
        {

            rotationAxisHorizontal = 1;
            RotationHorizontal(rotationAxisHorizontal);


        }
        else if (Input.GetAxis("Horizontal") < -0.5f && (playerShip.transform.eulerAngles.z < 30 || playerShip.transform.eulerAngles.z > 330))
        {

            rotationAxisHorizontal = -1;
            RotationHorizontal(rotationAxisHorizontal);

        }
        else if (Input.GetAxis("Horizontal") > -0.3f && Input.GetAxis("Horizontal") < 0.3f)
        {
            rotationAxisHorizontal = 0;
            RotationHorizontal(rotationAxisHorizontal);

        }
        //Giro vertical
        if (Input.GetAxis("Vertical") > 0.5f && (playerShip.transform.eulerAngles.x > 330 || playerShip.transform.eulerAngles.x < 30))
        {

            rotationAxisVertical = 1;
            RotationVertical(rotationAxisVertical);


        }
        else if (Input.GetAxis("Vertical") < -0.5f && (playerShip.transform.eulerAngles.x < 30 || playerShip.transform.eulerAngles.x > 330))
        {

            rotationAxisVertical = -1;
            RotationVertical(rotationAxisVertical);

        }
        else if (Input.GetAxis("Vertical") > -0.3f && Input.GetAxis("Vertical") < 0.3f)
        {
            rotationAxisVertical = 0;
            RotationVertical(rotationAxisVertical);

        }
        //Limite del movimiento vertical
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
        //Cambios de velocidad
        if (Input.GetAxis("Triggers") < -0.5f)
        {
            this.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed * 6));

        }
        else if (Input.GetAxis("Triggers") > 0.5)
        {
            this.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed / 4));
        }
        else {
            this.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
        }
        if (Input.GetAxis("Fire1") != 0 && (fireRate < 0)) { Shoot(); }

        if (Input.GetAxis("Fire2") != 0 && PlayerStatsLV5.currentInstance.specialShootBar.value == 5) {

            SpecialShoot();

        }

    }
    void Shoot()
    {

        fireRate = 0.2f;
        Instantiate(bullet1, bulletExit1.position, bulletExit1.rotation);
        Instantiate(bullet2, bulletExit2.position, bulletExit2.rotation);

    }

    void SpecialShoot() {

        foreach (Transform enemy in EnemySpecialShootManager.currentInstance.Enemies) {

            Vector3 enemyLocation = Camera.main.WorldToViewportPoint(enemy.position);
            if (enemyLocation.x >= 0 && enemyLocation.x <= 1 && enemyLocation.y >=0 && enemyLocation.y <= 1 && enemyLocation.z >= 0) {

                specialShootHasObjective = true;
                Instantiate(SpecialBullet, specialBulletExit.position, specialBulletExit.rotation).GetComponent<SpecialBulletLV5>().GoFor(enemy);


            }
        }
        if (specialShootHasObjective) {

            PlayerStatsLV5.currentInstance.specialShootBar.value = 0;
            specialShootHasObjective = false;

        }
        

    }
    void RotationHorizontal(float x)
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
    void RotationVertical(float y) {

        if (y == 1)
        {

            if (counterRotationUp < limitRotationVertical)
            {

                counterRotationUp += -(y * rotationOffset * Time.deltaTime);
                counterRotationDown += y * rotationOffset * Time.deltaTime;
                playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x + y * rotationOffset * Time.deltaTime, playerShip.transform.eulerAngles.y, playerShip.transform.eulerAngles.z);
            }

        }
        else if (y == -1)
        {

            if (counterRotationDown < limitRotationVertical)
            {

                counterRotationUp += -(y * rotationOffset * Time.deltaTime);
                counterRotationDown += y * rotationOffset * Time.deltaTime;
                playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x + y * rotationOffset * Time.deltaTime, playerShip.transform.eulerAngles.y, playerShip.transform.eulerAngles.z);
            }
        }
        else {

            if (counterRotationDown < counterRotationUp && counterRotationUp > 0) {

                counterRotationUp += rotationOffset * Time.deltaTime;
                counterRotationDown += -(rotationOffset * Time.deltaTime);
                playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x + -(rotationOffset * Time.deltaTime), playerShip.transform.eulerAngles.y, playerShip.transform.eulerAngles.z);
                if (counterRotationUp < 0.15)
                {
                    playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x - counterRotationUp, playerShip.transform.eulerAngles.y, playerShip.transform.eulerAngles.z);
                    counterRotationUp = 0;
                    counterRotationDown = 0;
                    


                }
            }
            else if (counterRotationDown > counterRotationUp && counterRotationDown >0) {

                counterRotationUp += -(rotationOffset * Time.deltaTime);
                counterRotationDown += rotationOffset * Time.deltaTime;
                playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x + rotationOffset * Time.deltaTime, playerShip.transform.eulerAngles.y, playerShip.transform.eulerAngles.z);
                if (counterRotationDown < 0.15) {

                    playerShip.transform.eulerAngles = new Vector3(playerShip.transform.eulerAngles.x - counterRotationDown, playerShip.transform.eulerAngles.y, playerShip.transform.eulerAngles.z);
                    counterRotationUp = 0;
                    counterRotationDown = 0;


                }

            }




        }


    }
    void LateralRoll() {

        if (Input.GetAxis("Fire3") > 0.2 && !lateralRolling && !barrelRolling)
        {
            lateralRolling = true;
            lateralRotationCounter = 180;
            
        }
        else if(lateralRolling){

            this.transform.Rotate(Vector3.up * 300 * Time.deltaTime);
            lateralRotationCounter -= Vector3.up.y * 300 * Time.deltaTime;
            if (lateralRotationCounter <= 0) {

                lateralRolling = false;

            }
        }
    }
    void BarellRoll()
    {

        //En proceso de funcionar
        if (Input.GetAxis("Fire4") > 0.2 && !barrelRolling && !lateralRolling)
        {

            barrelRolling = true;
            barrelRotationCounter = 360;

        }
        else if (barrelRolling)
        {

            this.transform.Rotate(Vector3.left * 200 * Time.deltaTime);
            barrelRotationCounter -= Vector3.forward.z * 200 * Time.deltaTime;
            if (barrelRotationCounter <= 0)
            {

                barrelRolling = false;

            }
        }
    }

}
