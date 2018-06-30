using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Manager : MonoBehaviour {

    public static Level5Manager currentInstance;
    int objectives = 4;

    private void Start()
    {
        currentInstance = this;
    }


    public void ObjectiveDestroy() {

        objectives -= 1;

        if (objectives <= 0) {

            LevelChange.currentInstance.LoadLevel("Level1");


        }


    }
}
