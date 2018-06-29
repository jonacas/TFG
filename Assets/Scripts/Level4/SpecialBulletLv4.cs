using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulletLv4 : MonoBehaviour {


    Transform Objective;
    bool attack = false;
    public float speed = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (attack)
        {

            if (Objective == null)
            {

                Destroy(this.gameObject);

            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, Objective.position, speed * Time.deltaTime);

        }


    }

    public void GoFor(Transform enemy)
    {

        Objective = enemy;
        attack = true;


    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<EnemyIALv4>().Defeat();
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Obstacle") {


            Destroy(this);

        }
    }
}
