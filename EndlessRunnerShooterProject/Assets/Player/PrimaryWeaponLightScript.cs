using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI
{

    public class PrimaryWeaponLightScript : MonoBehaviour
    {

        GameObject player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }


        void LateUpdate()
        {
            SetColourOfPrimaryLight();
        }

        void SetColourOfPrimaryLight()
        {
            if (player.GetComponent<PlayerControlScript>().GetPrimaryWeapon() == "machinegun")
            {
                if (player.GetComponent<PlayerMachineGunScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.green;
                }
                else if(!player.GetComponent<PlayerMachineGunScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.red;
                }
            }
            else if (player.GetComponent<PlayerControlScript>().GetPrimaryWeapon() == "wingguns")
            {
                if (player.GetComponent<PlayerWingGunsScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.green;
                }
                else if (!player.GetComponent<PlayerWingGunsScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.red;
                }
            }
        }
    }
}