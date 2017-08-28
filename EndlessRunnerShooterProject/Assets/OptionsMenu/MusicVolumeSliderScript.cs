using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Options
{

    public class MusicVolumeSliderScript : MonoBehaviour
    {
        void Trigger()
        {
            GlobalOptionsSettingsScript.instance.SetMusicVolume(GetComponent<Slider>().value);
            AudioManagerScript.instance.ResetMusicVolume();
        }

    }

}