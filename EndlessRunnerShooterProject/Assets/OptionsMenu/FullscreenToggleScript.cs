using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Options
{

    public class FullscreenToggleScript : MonoBehaviour
    {

        void Trigger()
        {
            GlobalOptionsSettingsScript.instance.SetFullscreen(GetComponent<Toggle>().isOn);
            GlobalOptionsSettingsScript.instance.UpdateScreenResolution();
        }
    }

}
