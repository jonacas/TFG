using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

    public static LevelChange currentInstance;
    public GameObject plane;
    public Text text;


    void Start()
    {

        currentInstance = this;

    }
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {

            LoadLevel("Level2");


        }
    }*/

    public void LoadLevel(string level) {

        plane.SetActive(true);
        StartCoroutine(LoadAsync(level));

    }

    IEnumerator LoadAsync(string level) {

        AsyncOperation chargeLevel = SceneManager.LoadSceneAsync(level);

        while (!chargeLevel.isDone) {

            float progress = Mathf.Clamp01(chargeLevel.progress / .9f);
            text.text = "Loading " + progress * 100 + "%";
           //Debug.Log(progress);

            yield return null;

        }

    }


}
