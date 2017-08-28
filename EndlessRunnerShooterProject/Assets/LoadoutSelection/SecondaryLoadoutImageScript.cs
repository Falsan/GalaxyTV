using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UI
{
    public class SecondaryLoadoutImageScript : LoadoutImageScript
    {

        public override void Start()
        {
            base.Start();
            sprites.Remove(wingGunsSprite);
            sprites.Remove(machineGunSprite);
            sprites.Remove(pointDefenceSprite);
            sprites.Remove(energyShieldSprite);

            GetComponent<Image>().sprite = sprites[0];
            selectedGun = GetComponent<Image>().sprite.name;
        }



    }
}