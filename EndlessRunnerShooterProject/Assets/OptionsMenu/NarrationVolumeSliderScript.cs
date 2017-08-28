using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Options
{

    public class NarrationVolumeSliderScript : MonoBehaviour
    {
        void Trigger()
        {
            GlobalOptionsSettingsScript.instance.SetNarrationVolume(GetComponent<Slider>().value);
        }

    }

}