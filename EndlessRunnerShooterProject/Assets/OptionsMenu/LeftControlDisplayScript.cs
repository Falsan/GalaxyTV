using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class LeftControlDisplayScript : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Text>().text = InputManagerScript.instance.allCommands[2].GetKeyCode();
        }
    }
}