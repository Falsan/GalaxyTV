using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Options
{

    public class DisplayOptionsDropdownScript : MonoBehaviour
    {

        void Trigger()
        {
            switch(GetComponent<Dropdown>().value)
            {
                case 0:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(800);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(600);
                    break;
                case 1:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1024);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(768);
                    break;
                case 2:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1280);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(720);
                    break;
                case 3:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1280);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(768);
                    break;
                case 4:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1280);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(800);
                    break;
                case 5:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1280);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(1024);
                    break;
                case 6:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1366);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(768);
                    break;
                case 7:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1440);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(900);
                    break;
                case 8:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1600);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(900);
                    break;
                case 9:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1680);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(1050);
                    break;
                case 10:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1920);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(1080);
                    break;
                case 11:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(1920);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(1200);
                    break;
                case 12:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(2560);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(1080);
                    break;
                case 13:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(2560);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(1440);
                    break;
                case 14:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(3440);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(1440);
                    break;
                case 15:
                    GlobalOptionsSettingsScript.instance.SetResolutionWidth(3840);
                    GlobalOptionsSettingsScript.instance.SetResolutionHeight(2160);
                    break;
            }

            GlobalOptionsSettingsScript.instance.UpdateScreenResolution();
        }
    }

}
