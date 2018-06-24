using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ereaser : MonoBehaviour {

    public float ereaserTime = 3.5f;
    SpriteRenderer sprite;
    // Use this for initialization

    void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - Time.deltaTime/4);
        ereaserTime -= Time.deltaTime;
        if (ereaserTime <= 0) {

            Destroy(this.gameObject);

        }

	}
}
