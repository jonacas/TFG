using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static bool isPause = false;
    public Text[] Text;
    public Text[] Levels;
    int index = 0;
    int indexLevels = 0;
    bool Up = false;
    bool Down = false;
    bool mainMenu = true;
    bool selecLevelMenu = false;
    bool controls = false;
    float activator = 0.5f;


	// Use this for initialization
	void Start () {

        foreach (Text level in Levels)
        {

            level.enabled = false;

        }

    }
	
	// Update is called once per frame
	void Update () {


        if (mainMenu)
        {
            MenuInputs();
        }
        else if (selecLevelMenu)
        {

            LevelsInputs();
            activator -= Time.deltaTime;

        }
        else if (controls) {

            Controls();
        }
        

	}


    void MenuInputs()
    {

        MainMenuText();
        if ((Input.GetAxis("Vertical") > 0.5 || (Input.GetKeyDown(KeyCode.W))) && !Up)
        {

            index -= 1;
            Up = true;
            Down = false;
            if (index <= -1)
            {

                index = 3;

            }

        }
        else if ((Input.GetAxis("Vertical") < -0.5 || Input.GetKeyDown(KeyCode.S)) && !Down)
        {

            index += 1;
            Down = true;
            Up = false;
            if (index >= 4)
            {

                index = 0;

            }
        }

        else if (Input.GetAxis("Vertical") == 0)
        {

            Up = false;
            Down = false;

        }


        if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.AltGr))
        {

            switch (index)
            {

                case 0:
                    LevelChange.currentInstance.LoadLevel("Level1");
                    break;
                case 1:
                    selecLevelMenu = true;
                    mainMenu = false;
                    foreach (Text option in Text) {
                        option.enabled = false;

                    }
                    foreach (Text level in Levels) {

                        level.enabled = true;

                    }
                    activator = 0.5f;
                    break;
                case 2:
                    mainMenu = false;
                    foreach (Text option in Text)
                    {
                        option.enabled = false;

                    }
                    controls = true;
                    break;
                case 3:
                    Application.Quit();
                    break;

            }

        }


    }

    void MainMenuText() {

        switch (index)
        {

            case 0:
                Text[0].fontSize = 36;
                Text[0].color = Color.red;
                Text[1].fontSize = 26;
                Text[1].color = Color.white;
                Text[2].fontSize = 26;
                Text[2].color = Color.white;
                Text[3].fontSize = 26;
                Text[3].color = Color.white;
                break;
            case 1:
                Text[0].fontSize = 26;
                Text[0].color = Color.white;
                Text[1].fontSize = 36;
                Text[1].color = Color.red;
                Text[2].fontSize = 26;
                Text[2].color = Color.white;
                Text[3].fontSize = 26;
                Text[3].color = Color.white;
                break;
            case 2:
                Text[0].fontSize = 26;
                Text[0].color = Color.white;
                Text[1].fontSize = 26;
                Text[1].color = Color.white;
                Text[2].fontSize = 36;
                Text[2].color = Color.red;
                Text[3].fontSize = 26;
                Text[3].color = Color.white;
                break;
            case 3:
                Text[0].fontSize = 26;
                Text[0].color = Color.white;
                Text[1].fontSize = 26;
                Text[1].color = Color.white;
                Text[2].fontSize = 26;
                Text[2].color = Color.white;
                Text[3].fontSize = 36;
                Text[3].color = Color.red;
                break;

        }



    }

    void LevelsInputs()
    {

        LevelsMenuText();
        if ((Input.GetAxis("Vertical") > 0.5 || (Input.GetKeyDown(KeyCode.W))) && !Up)
        {

            indexLevels -= 1;
            Up = true;
            Down = false;
            if (indexLevels <= -1)
            {

                indexLevels = 4;

            }

        }
        else if ((Input.GetAxis("Vertical") < -0.5 || Input.GetKeyDown(KeyCode.S)) && !Down)
        {

            indexLevels += 1;
            Down = true;
            Up = false;
            if (indexLevels >= 5)
            {

                indexLevels = 0;

            }
        }

        else if (Input.GetAxis("Vertical") == 0)
        {

            Up = false;
            Down = false;

        }


        if ((Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.AltGr)) && activator < 0)
        {

            switch (indexLevels)
            {

                case 0:
                    LevelChange.currentInstance.LoadLevel("Level1");
                    break;
                case 1:
                    LevelChange.currentInstance.LoadLevel("Level2");
                    break;
                case 2:
                    LevelChange.currentInstance.LoadLevel("Level3");
                    break;
                case 3:
                    LevelChange.currentInstance.LoadLevel("Level4");
                    break;
                case 4:
                    LevelChange.currentInstance.LoadLevel("Level5");
                    break;

            }

        }
        if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.RightControl)){

            selecLevelMenu = false;
            mainMenu = true;
            foreach (Text option in Text)
            {
                option.enabled = true;

            }
            foreach (Text level in Levels)
            {

                level.enabled = false;

            }

        }


    }

    void LevelsMenuText()
    {

        switch (indexLevels)
        {

            case 0:
                Levels[0].fontSize = 36;
                Levels[0].color = Color.red;
                Levels[1].fontSize = 26;
                Levels[1].color = Color.white;
                Levels[2].fontSize = 26;
                Levels[2].color = Color.white;
                Levels[3].fontSize = 26;
                Levels[3].color = Color.white;
                Levels[4].fontSize = 26;
                Levels[4].color = Color.white;
                break;
            case 1:
                Levels[0].fontSize = 26;
                Levels[0].color = Color.white;
                Levels[1].fontSize = 36;
                Levels[1].color = Color.red;
                Levels[2].fontSize = 26;
                Levels[2].color = Color.white;
                Levels[3].fontSize = 26;
                Levels[3].color = Color.white;
                Levels[4].fontSize = 26;
                Levels[4].color = Color.white;
                break;
            case 2:
                Levels[0].fontSize = 26;
                Levels[0].color = Color.white;
                Levels[1].fontSize = 26;
                Levels[1].color = Color.white;
                Levels[2].fontSize = 36;
                Levels[2].color = Color.red;
                Levels[3].fontSize = 26;
                Levels[3].color = Color.white;
                Levels[4].fontSize = 26;
                Levels[4].color = Color.white;
                break;
            case 3:
                Levels[0].fontSize = 26;
                Levels[0].color = Color.white;
                Levels[1].fontSize = 26;
                Levels[1].color = Color.white;
                Levels[2].fontSize = 26;
                Levels[2].color = Color.white;
                Levels[3].fontSize = 36;
                Levels[3].color = Color.red;
                Levels[4].fontSize = 26;
                Levels[4].color = Color.white;
                break;
            case 4:
                Levels[0].fontSize = 26;
                Levels[0].color = Color.white;
                Levels[1].fontSize = 26;
                Levels[1].color = Color.white;
                Levels[2].fontSize = 26;
                Levels[2].color = Color.white;
                Levels[3].fontSize = 26;
                Levels[3].color = Color.white;
                Levels[4].fontSize = 36;
                Levels[4].color = Color.red;
                break;

        }



    }

    void Controls() {

        if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.RightControl))
        {

            controls = false;
            mainMenu = true;
            foreach (Text option in Text)
            {
                option.enabled = true;

            }

        }

    } 
}
