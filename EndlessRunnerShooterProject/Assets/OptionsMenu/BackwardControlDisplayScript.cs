using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class BackwardControlDisplayScript : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Text>().text = InputManagerScript.instance.allCommands[4].GetKeyCode();
        }
    }
}