using UnityEngine;
using System.Collections;

namespace UI
{
    public class PrimaryWeaponInfoScript : MonoBehaviour
    {

        void PlayWeaponInfo()
        {
            if(GameObject.Find("PrimaryImage").GetComponent<LoadoutImageScript>().GetSelectedGun() == "wingguns")
            {
                AudioManagerScript.instance.CreateNewSound("WingGunsInfo");
            }
            else if(GameObject.Find("PrimaryImage").GetComponent<LoadoutImageScript>().GetSelectedGun() == "machinegun")
            {
                AudioManagerScript.instance.CreateNewSound("MachineGunInfo");
            }
        }
    }
}