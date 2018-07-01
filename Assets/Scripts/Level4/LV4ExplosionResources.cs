using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV4ExplosionResources : MonoBehaviour {

    public static LV4ExplosionResources currentInstance;
    public GameObject explosion;
	// Use this for initialization
	void Start () {

        currentInstance = this;
	}

}
