using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class Fire1ControlDisplayScript : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Text>().text = InputManagerScript.instance.allCommands[0].GetKeyCode();
        }
    }
}