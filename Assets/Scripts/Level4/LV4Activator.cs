using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV4Activator : MonoBehaviour {

    public GameObject enemy;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + Vector3.down * 5 * Time.deltaTime;
        Vector3 comprobar = Camera.main.WorldToViewportPoint(transform.position);
        if (comprobar.x > 0 && comprobar.x < 1 && comprobar.y > 0 && comprobar.y < 1 && comprobar.z < 40)
        {

            enemy.SetActive(true);
        }

    }
}
