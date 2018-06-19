using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialShootManager : MonoBehaviour {

    public static EnemySpecialShootManager currentInstance;
    public List<Transform> Enemies;
	// Use this for initialization
	void Start () {

        currentInstance = this;
        MakeList(this.GetComponentsInChildren<Transform>());
		
	}
	
	// Update is called once per frame
	void Update () {

        MakeList(this.GetComponentsInChildren<Transform>());

    }

    void MakeList(Transform[] transforms) {

        Enemies.Clear();

        foreach(Transform item in transforms){

            if (item.gameObject.tag == "Enemy") {

                Enemies.Add(item);

            }


        }



    }
}
