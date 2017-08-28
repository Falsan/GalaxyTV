using UnityEngine;
using System.Collections;

namespace UI
{

    public class OptionsMenuButtonScript : MonoBehaviour
    {
        
        void GoToOptionsMenu()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            ApplicationManagerScript.instance.SetCurrentApplicationState("OPTIONSSCENE");
        }
    }
}