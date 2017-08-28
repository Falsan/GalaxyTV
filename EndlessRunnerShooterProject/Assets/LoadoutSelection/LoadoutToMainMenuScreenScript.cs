using UnityEngine;
using System.Collections;

namespace UI
{
    public class LoadoutToMainMenuScreenScript : MonoBehaviour
    {

        void LoadoutToMainMenu()
        {
            ApplicationManagerScript.instance.SetCurrentApplicationState("MAINMENU");
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
        }
    }
}