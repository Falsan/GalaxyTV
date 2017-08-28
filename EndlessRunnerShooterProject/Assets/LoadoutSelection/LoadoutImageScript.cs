using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace UI
{

    public class LoadoutImageScript : MonoBehaviour
    {
        bool done;
        public Sprite machineGunSprite;
        public Sprite thudGunSprite;
        public Sprite energyShieldSprite;
        public Sprite scilthromeGunSprite;
        public Sprite pointDefenceSprite;
        public Sprite wingGunsSprite;

        protected string selectedGun;

        protected List<Sprite> sprites;

        public virtual void Start()
        {
            done = false;
            sprites = new List<Sprite>();

            sprites.Add(machineGunSprite);
            sprites.Add(wingGunsSprite);
            sprites.Add(thudGunSprite);
            sprites.Add(energyShieldSprite);
            sprites.Add(scilthromeGunSprite);
            sprites.Add(pointDefenceSprite);

            GetComponent<Image>().sprite = sprites[0];
            selectedGun = GetComponent<Image>().sprite.name;
        }

        public void MoveDownList()
        {
            for (int iter = 0; iter < sprites.Count; iter++)
            {
                if (sprites[iter].name == GetComponent<Image>().sprite.name && done == false)
                {
                    if (iter == 0)
                    {
                        GetComponent<Image>().sprite = sprites[sprites.Count - 1];
                    }
                    else
                    {
                        GetComponent<Image>().sprite = sprites[iter - 1];
                    }
                    done = true;
                }
            }
            done = false;

            selectedGun = GetComponent<Image>().sprite.name;
        }

        public void MoveUpList()
        {
            for (int iter = 0; iter < sprites.Count; iter++)
            {
                if (sprites[iter].name == GetComponent<Image>().sprite.name && done == false)
                {
                    if (iter == sprites.Count - 1)
                    {
                        GetComponent<Image>().sprite = sprites[0];
                    }
                    else
                    {
                        GetComponent<Image>().sprite = sprites[iter + 1];
                    }

                    done = true;
                }
            }

            done = false;

            selectedGun = GetComponent<Image>().sprite.name;
        }

        public string GetSelectedGun()
        {
            return selectedGun;
        }
    }
}