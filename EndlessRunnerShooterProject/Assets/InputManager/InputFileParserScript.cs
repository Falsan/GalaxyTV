using UnityEngine;
using System.Collections;
using System.IO;

public class InputFileParserScript : MonoBehaviour {

    public static InputFileParserScript instance;
    StreamReader controls;
    StreamWriter controlsToWrite;

    string path;

    string moveForward;
    string moveBackward;
    string moveLeft;
    string moveRight;
    string fire1;
    string fire2;
    string fire3;
    string bringUpMenu;
    string skip;

    void Start ()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        path = Application.dataPath + "/Resources/Input.txt";
        UpdateControlStrings();
    }


    void UpdateControlStrings()
    {
        controls = new StreamReader(path);

        moveForward = controls.ReadLine();
        moveBackward = controls.ReadLine();
        moveLeft = controls.ReadLine();
        moveRight = controls.ReadLine();
        fire1 = controls.ReadLine();
        fire2 = controls.ReadLine();
        fire3 = controls.ReadLine();
        bringUpMenu = controls.ReadLine();
        skip = controls.ReadLine();
        
        controls.Close();
        controls = null;
    }

    public void SetNewControlString(int controlToChange, string toSet)
    {
        controlsToWrite = new StreamWriter(path);
        controls = new StreamReader(path);

        for(int iter = 0; 7 > iter; iter++)
        {
            if (iter == controlToChange)
            {
                controlsToWrite.WriteLine(toSet);
            }
            else
            {
                controlsToWrite.WriteLine(controls.ReadLine());
            }
        }

        UpdateControlStrings();
    }

    public string GetMoveForward()
    {
        return moveForward;
    }
    public string GetMoveBackward()
    {
        return moveBackward;
    }
    public string GetMoveLeft()
    {
        return moveLeft;
    }
    public string GetMoveRight()
    {
        return moveRight;
    }
    public string GetFire1()
    {
        return fire1;
    }
    public string GetFire2()
    {
        return fire2;
    }
    public string GetFire3()
    {
        return fire3;
    }
    public string GetGameMenu()
    {
        return bringUpMenu;
    }
    public string GetSkip()
    {
        return skip;
    }
}
