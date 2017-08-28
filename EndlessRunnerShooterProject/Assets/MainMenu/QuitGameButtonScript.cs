using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace UI
{

    public class QuitGameButtonScript : MonoBehaviour
    {

        // Use this for initialization
        void QuitGameButton()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            Application.Quit();
        }

    }
}