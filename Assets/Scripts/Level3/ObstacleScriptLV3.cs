using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScriptLV3 : MonoBehaviour {


    public float speed = 2;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            LV3Manager.currentInstance.death = true;
            Destroy(PlayerMovementLV3.currentInstance.gameObject);

        }
        
    }

}
