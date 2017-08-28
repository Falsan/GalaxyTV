using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManagerScript : MonoBehaviour {

    public static InputManagerScript instance;

    List<KeyClass> keysPressed;
    public List<KeyClass> allCommands;

    bool assigned;

	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        keysPressed = new List<KeyClass>();
        allCommands = new List<KeyClass>();
        assigned = false;

    }

    void Update()
    {
        if (assigned == false)
        {
            if (InputFileParserScript.instance != null)
            {
                AssignInitialKeysToCommands();
                assigned = true;
            }


        }
        //if (ApplicationManagerScript.instance.currentApplicationState == "LEVEL1PLAY")
       // {
            CheckToSeeWhichKeysWerePressed();
       // }
    }


    void CheckToSeeWhichKeysWerePressed()
    {
        if(Input.GetKey(allCommands[0].GetKeyCode()))
        {
            AddCommandIfPressed(allCommands[0].GetKeyCode());
        }
        if (Input.GetKey(allCommands[5].GetKeyCode()))
        {
            AddCommandIfPressed(allCommands[5].GetKeyCode());
        }
        if (Input.GetKey(allCommands[6].GetKeyCode()))
        {
            AddCommandIfPressed(allCommands[6].GetKeyCode());
        }
        if (Input.GetKey(allCommands[1].GetKeyCode()))
        {
            AddCommandIfPressed(allCommands[1].GetKeyCode());
        }
        if (Input.GetKey(allCommands[4].GetKeyCode()))
        {
            AddCommandIfPressed(allCommands[4].GetKeyCode());
        }
        if (Input.GetKey(allCommands[2].GetKeyCode()))
        {
            AddCommandIfPressed(allCommands[2].GetKeyCode());
        }
        if (Input.GetKey(allCommands[3].GetKeyCode()))
        {
            AddCommandIfPressed(allCommands[3].GetKeyCode());
        }
        if(Input.GetKey(allCommands[7].GetKeyCode()))
        {
            AddCommandIfPressed(allCommands[7].GetKeyCode());
        }
        if(Input.GetKey(allCommands[8].GetKeyCode()))
        {
            AddCommandIfPressed(allCommands[8].GetKeyCode());
        }
    }

    void AssignCommandAndKey(string command, string key)
    {
        KeyClass newKey = (KeyClass)KeyClass.CreateInstance("KeyClass");

        newKey.SetCommand(command);
        newKey.SetKeyCode(key);

        allCommands.Add(newKey);
    }

    public void AssignNewKeyToCommand(string command, string key)
    {
        for (int iter = 0; iter < allCommands.Count; iter++)
        {
            if (allCommands[iter].GetCommand() == command)
            {
                allCommands[iter].SetKeyCode(key);
            }
        }
    }

    void AddCommandIfPressed(string keyPressed)
    {
        for(int iter = 0; iter < allCommands.Count; iter++)
        {
            //if this key was pressed, add it to the list of keys pressed
            if(allCommands[iter].GetKeyCode() == keyPressed)
            {
                keysPressed.Add(allCommands[iter]);
            }
        }
    }

    void AssignInitialKeysToCommands()
    {
        AssignCommandAndKey("Fire", InputFileParserScript.instance.GetFire1());
        AssignCommandAndKey("Forward", InputFileParserScript.instance.GetMoveForward());
        AssignCommandAndKey("Left", InputFileParserScript.instance.GetMoveLeft());
        AssignCommandAndKey("Right", InputFileParserScript.instance.GetMoveRight());
        AssignCommandAndKey("Back", InputFileParserScript.instance.GetMoveBackward());
        AssignCommandAndKey("FireSecondary", InputFileParserScript.instance.GetFire2());
        AssignCommandAndKey("Defend", InputFileParserScript.instance.GetFire3());
        AssignCommandAndKey("PauseMenu", InputFileParserScript.instance.GetGameMenu());
        AssignCommandAndKey("Skip", InputFileParserScript.instance.GetSkip());
    }

    public List<KeyClass> GetKeysPressed()
    {
        return keysPressed;
    }

    public void ClearKeysPressed()
    {
        keysPressed.Clear();
    }
}
