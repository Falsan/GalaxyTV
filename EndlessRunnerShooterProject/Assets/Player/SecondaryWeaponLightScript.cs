using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI
{

    public class SecondaryWeaponLightScript : MonoBehaviour
    {

        GameObject player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }


        void LateUpdate()
        {
            SetColourOfSecondaryLight();
        }

        void SetColourOfSecondaryLight()
        {
            if (player.GetComponent<PlayerControlScript>().GetSecondaryWeapon() == "fistgun")
            {
                if (player.GetComponent<PlayerFistGunScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.green;
                }
                else if (!player.GetComponent<PlayerFistGunScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.red;
                }
            }
            else if (player.GetComponent<PlayerControlScript>().GetSecondaryWeapon() == "schiltron")
            {
                if (player.GetComponent<PlayerScilthromeGunScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.green;
                }
                else if (!player.GetComponent<PlayerScilthromeGunScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.red;
                }
            }
        }
    }
}