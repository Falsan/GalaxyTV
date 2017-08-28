using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UI
{
    public class InputNewLeftScript : NewInputScript
    {

        bool inputNewValue;

        void Awake()
        {
            inputNewValue = false;
        }

        void Trigger()
        {
            inputNewValue = true;
        }

        void Update()
        {
            if (inputNewValue == true)
            {
                //disable all buttons
                if (Input.anyKeyDown)
                {
                    foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(kcode))
                        {
                            InputManagerScript.instance.allCommands[2].SetKeyCode(GetInputStringFromKeyCode(kcode));
                        }
                    }

                    inputNewValue = false;
                }
            }
            else
            {
                //enable all buttons
            }
        }
    }
}