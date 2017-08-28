using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UI
{
    public class PrimaryLoadoutImageScript : LoadoutImageScript
    {

        public override void Start()
        {
            base.Start();
            sprites.Remove(energyShieldSprite);
            sprites.Remove(scilthromeGunSprite);
            sprites.Remove(pointDefenceSprite);
            sprites.Remove(thudGunSprite);

            GetComponent<Image>().sprite = sprites[0];
            selectedGun = GetComponent<Image>().sprite.name;
        }
        

        
    }
}