using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPause = false;
    public GameObject fondo;
    public Text[] Text;
    int index = 0;
    bool Up = false;
    bool Down = false;
    // Use this for initialization
    void Start()
    {

        fondo.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isPause)
        {
            Menu();
            //ResumeGame();
        }
        else
        {
            PauseGame();
        }



    }

    void PauseGame()
    {

        if (Input.GetAxis("Pause") != 0)
        {
            isPause = true;
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            index = 0;
            fondo.SetActive(true);
           
        }

    }

    void Menu() {

        MenuInputs();
        switch (index) {

            case 0:
                Text[0].fontSize = 36;
                Text[0].color = Color.red;
                Text[1].fontSize = 26;
                Text[1].color = Color.white;
                Text[2].fontSize = 26;
                Text[2].color = Color.white;
                break;
            case 1:
                Text[0].fontSize = 26;
                Text[0].color = Color.white;
                Text[1].fontSize = 36;
                Text[1].color = Color.red;
                Text[2].fontSize = 26;
                Text[2].color = Color.white;
                break;
            case 2:
                Text[0].fontSize = 26;
                Text[0].color = Color.white;
                Text[1].fontSize = 26;
                Text[1].color = Color.white;
                Text[2].fontSize = 36;
                Text[2].color = Color.red;
                break;

        }

    }

    void MenuInputs() {


        if ((Input.GetAxis("Vertical") > 0.5 || (Input.GetKeyDown(KeyCode.W))) && !Up)
        {

            index -= 1;
            Up = true;
            Down = false;
            if (index <= -1)
            {

                index = 2;

            }

        }
        else if ((Input.GetAxis("Vertical") < -0.5 || Input.GetKeyDown(KeyCode.S)) && !Down)
        {

            index += 1;
            Down = true;
            Up = false;
            if (index >= 3)
            {

                index = 0;

            }
        }

        else if(Input.GetAxis("Vertical") == 0) {

            Up = false;
            Down = false;

        }

        
        if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.AltGr) ) {

            switch (index)
            {

                case 0:
                    ResumeGame();
                    break;
                case 1:
                    MainMenu();
                    break;
                case 2:
                    Application.Quit();
                    break;

            }

        }


    }

    void ResumeGame()
    {

        isPause = false;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        fondo.SetActive(false);
    }

    void MainMenu() {

        LevelChange.currentInstance.LoadLevel("Menu");

    }

}
