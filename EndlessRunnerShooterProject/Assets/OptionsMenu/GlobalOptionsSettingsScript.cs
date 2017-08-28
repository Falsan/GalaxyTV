using UnityEngine;
using System.Collections;

namespace Options
{

    public class GlobalOptionsSettingsScript : MonoBehaviour
    {
        public static GlobalOptionsSettingsScript instance;

        float masterVolume;
        float musicVolume;
        float narrationVolume;
        float fxVolume;

        public int resolutionHeight;
        public int resolutionWidth;

        bool fullScreen;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            masterVolume = 1.0f;
            musicVolume = 1.0f;
            narrationVolume = 1.0f;
            fxVolume = 1.0f;

            resolutionHeight = Screen.currentResolution.height;
            resolutionWidth = Screen.currentResolution.width;
        }

        public void UpdateScreenResolution()
        {
            Screen.SetResolution(resolutionWidth, resolutionHeight, fullScreen);
        }

        public void SetMasterVolume(float toSet)
        {
            masterVolume = toSet;
        }

        public float GetMasterVolume()
        {
            return masterVolume;
        }

        public void SetMusicVolume(float toSet)
        {
            musicVolume = toSet;
        }

        public float GetMusicVolume()
        {
            return musicVolume;
        }

        public void SetNarrationVolume(float toSet)
        {
            narrationVolume = toSet;
        }

        public float GetNarrationVolume()
        {
            return narrationVolume;
        }

        public void SetFXVolume(float toSet)
        {
            fxVolume = toSet;
        }

        public float GetFXVolume()
        {
            return fxVolume;
        }

        public void SetResolutionHeight(int toSet)
        {
            resolutionHeight = toSet;
        }

        public int GetResolutionHeight()
        {
            return resolutionHeight;
        }
        
        public void SetResolutionWidth(int toSet)
        {
            resolutionWidth = toSet;
        }

        public int GetResolutionWidth()
        {
            return resolutionWidth;
        }

        public void SetFullscreen(bool toSet)
        {
            fullScreen = toSet;
        }

        public bool GetFullScreen()
        {
            return fullScreen;
        }
    }
}