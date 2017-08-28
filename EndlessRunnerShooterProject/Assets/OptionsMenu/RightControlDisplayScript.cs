using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class RightControlDisplayScript : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Text>().text = InputManagerScript.instance.allCommands[3].GetKeyCode();
        }
    }
}