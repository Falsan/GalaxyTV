using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Options
{

    public class FXVolumeSliderScript : MonoBehaviour
    {
        void Trigger()
        {
            GlobalOptionsSettingsScript.instance.SetFXVolume(GetComponent<Slider>().value);
        }

    }

}