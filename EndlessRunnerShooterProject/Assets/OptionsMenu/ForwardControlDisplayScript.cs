using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class ForwardControlDisplayScript : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Text>().text = InputManagerScript.instance.allCommands[1].GetKeyCode();
        }
    }
}