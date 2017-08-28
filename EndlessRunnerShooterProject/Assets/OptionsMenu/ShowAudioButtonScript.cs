using UnityEngine;
using System.Collections;

namespace Options
{

    public class ShowAudioButtonScript : MonoBehaviour
    {
        void Trigger()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            ShowOptionsScript.instance.ShowAudioOptions();
        }
        
    }
}