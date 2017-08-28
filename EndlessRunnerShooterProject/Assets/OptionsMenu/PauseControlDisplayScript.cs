using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class PauseControlDisplayScript : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Text>().text = InputManagerScript.instance.allCommands[7].GetKeyCode();
        }
    }
}