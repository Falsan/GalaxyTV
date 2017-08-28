using UnityEngine;
using System.Collections;

public class KeyClass : ScriptableObject
{
    bool isPressed = false;
    string command;
    string key;

    public bool GetIsPressed()
    {
        return isPressed;
    }
    public void SetIsPressed(bool toSet)
    {
        isPressed = toSet;
    }

    public string GetCommand()
    {
        return command;
    }
    public void SetCommand(string toSet)
    {
        command = toSet;
    }

    public string GetKeyCode()
    {
        return key;
    }

    public void SetKeyCode(string toSet)
    {
        key = toSet;
    }
}
