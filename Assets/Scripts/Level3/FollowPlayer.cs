using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerMovementLV3.currentInstance == null)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
        }
        else {

            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        }

        this.transform.position = PlayerMovementLV3.currentInstance.transform.position;
	}

}
