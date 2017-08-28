using UnityEngine;
using System.Collections;

public class PlayerMachineGunScript : PlayerWeaponBaseScript {
	

    public override void Fire()
    {
        base.Fire();
        if (GetCanFire() == true)
        {
            Vector3 spawnpos = gameObject.transform.position + new Vector3(0.0f, 1.0f, 0.0f);

            Instantiate(baseBulletPrefab).transform.position = spawnpos;
            SetCanFire(false);
            AudioManagerScript.instance.CreateNewSound("ShotSound");

        }
    }

}
