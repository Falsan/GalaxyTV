using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class Fire2ControlDisplayScript : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Text>().text = InputManagerScript.instance.allCommands[5].GetKeyCode();
        }
    }
}