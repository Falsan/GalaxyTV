using UnityEngine;
using System.Collections;

public class PlayerFistGunScript : PlayerWeaponBaseScript
{

    public GameObject fistGunBulletPrefab;

    public override void Start()
    {
        base.Start();
        SetCooldownTimer(2.0f);
    }

    public override void Fire()
    {
        base.Fire();

        if (GetCanFire() == true)
        {
            Vector3 spawnpos = gameObject.transform.position + new Vector3(0.0f, 1.0f, 0.0f);

            Instantiate(fistGunBulletPrefab).transform.position = spawnpos;
            SetCanFire(false);
            AudioManagerScript.instance.CreateNewSound("ThudGunShot");
        }
    }

}
