using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTheNextLevel : MonoBehaviour {

    public string LevelName;
	// Use this for initialization
	void Start () {

        LevelChange.currentInstance.LoadLevel(LevelName);

	}
	
}
