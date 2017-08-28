using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UI
{

    public class StartGameButtonScript : MonoBehaviour
    {


        void StartGameButton()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            ApplicationManagerScript.instance.SetCurrentApplicationState("LOADOUTSCREEN");
        }

    }
}