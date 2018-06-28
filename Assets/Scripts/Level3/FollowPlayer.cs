using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public static FollowPlayer currentInstance;
	// Use this for initialization
	void Start () {

        currentInstance = this;

	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerMovementLV3.currentInstance == null)
        {
            this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            
        }
        else {

            this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            this.transform.position = PlayerMovementLV3.currentInstance.transform.position;
        }

       
	}

}
