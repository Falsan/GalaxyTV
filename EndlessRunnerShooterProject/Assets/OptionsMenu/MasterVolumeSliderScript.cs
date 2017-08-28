using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Options
{

    public class MasterVolumeSliderScript : MonoBehaviour
    {
        void Trigger()
        {
            GlobalOptionsSettingsScript.instance.SetMasterVolume(GetComponent<Slider>().value);
        }

    }

}