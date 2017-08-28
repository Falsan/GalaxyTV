using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class SkipControlDisplayScript : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Text>().text = InputManagerScript.instance.allCommands[8].GetKeyCode();
        }
    }
}