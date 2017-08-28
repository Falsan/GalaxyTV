using UnityEngine;
using System.Collections;

namespace UI
{
    public class DefenceWeaponInfoScript : MonoBehaviour
    {

        void PlayWeaponInfo()
        {
            if (GameObject.Find("DefenceImage").GetComponent<LoadoutImageScript>().GetSelectedGun() == "energyshield")
            {
                AudioManagerScript.instance.CreateNewSound("EnergyShieldInfo");
            }
            else if (GameObject.Find("DefenceImage").GetComponent<LoadoutImageScript>().GetSelectedGun() == "pointdefence")
            {
                AudioManagerScript.instance.CreateNewSound("PointDefenceInfo");
            }
        }
    }
}