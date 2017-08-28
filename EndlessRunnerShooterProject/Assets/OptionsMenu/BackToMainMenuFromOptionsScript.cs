using UnityEngine;
using System.Collections;

namespace Options
{

    public class BackToMainMenuFromOptionsScript : MonoBehaviour
    {

        void Trigger()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            ApplicationManagerScript.instance.SetCurrentApplicationState("MAINMENU");
        }
    }

}