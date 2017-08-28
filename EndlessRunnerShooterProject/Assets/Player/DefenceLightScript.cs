using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI
{

    public class DefenceLightScript : MonoBehaviour
    {

        GameObject player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }


        void LateUpdate()
        {
            SetColourOfDefenceLight();

        }

        void SetColourOfDefenceLight()
        {
            if (player.GetComponent<PlayerControlScript>().GetDefence() == "energyshield")
            {
                if (player.GetComponent<PlayerEnergyShieldScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.green;
                }
                else if (!player.GetComponent<PlayerEnergyShieldScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.red;
                }
            }
            else if (player.GetComponent<PlayerControlScript>().GetDefence() == "pointdefence")
            {
                if (player.GetComponent<PlayerPointDefenceScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.green;
                }
                else if (!player.GetComponent<PlayerPointDefenceScript>().GetCanFire())
                {
                    gameObject.GetComponent<Image>().color = Color.red;
                }
            }
        }
    }
}