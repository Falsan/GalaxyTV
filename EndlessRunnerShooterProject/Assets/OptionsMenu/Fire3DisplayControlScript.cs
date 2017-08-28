using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class Fire3DisplayControlScript : MonoBehaviour
    {
        void Update()
        {
            GetComponent<Text>().text = InputManagerScript.instance.allCommands[6].GetKeyCode();
        }
    }
}