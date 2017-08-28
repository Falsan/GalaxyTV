using UnityEngine;
using System.Collections;

namespace UI
{
    public class MainMenuFromLevelSelectButtonScript : MonoBehaviour
    {

        void MainMenu()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            ApplicationManagerScript.instance.SetCurrentApplicationState("MAINMENU");
        }
    }
}