using UnityEngine;
using System.Collections;

namespace UI
{
    public class SecondaryWeaponInfoScript : MonoBehaviour
    {

        void PlayWeaponInfo()
        {
            if (GameObject.Find("SecondaryImage").GetComponent<LoadoutImageScript>().GetSelectedGun() == "fistgun")
            {
                AudioManagerScript.instance.CreateNewSound("ThudGunInfo");
            }
            else if (GameObject.Find("SecondaryImage").GetComponent<LoadoutImageScript>().GetSelectedGun() == "schiltron")
            {
                AudioManagerScript.instance.CreateNewSound("SchiltronGunInfo");
            }
        }
    }
}