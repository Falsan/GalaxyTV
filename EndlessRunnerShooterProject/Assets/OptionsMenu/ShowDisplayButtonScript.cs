using UnityEngine;
using System.Collections;

namespace Options
{

    public class ShowDisplayButtonScript : MonoBehaviour
    {

        void Trigger()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            ShowOptionsScript.instance.ShowDisplayOptions();
        }
    }
}