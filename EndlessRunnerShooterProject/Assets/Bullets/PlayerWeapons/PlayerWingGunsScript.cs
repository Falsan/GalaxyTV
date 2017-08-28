using UnityEngine;
using System.Collections;

public class PlayerWingGunsScript : PlayerWeaponBaseScript
{
    string leftOrRight = "Right";

    public override void Start()
    {
        base.Start();
        SetCooldownTimer(0.2f);
    }

    public override void Fire()
    {
        base.Fire();
        if (GetCanFire() == true)
        {
            Vector3 spawnpos = Vector3.zero;
            if (leftOrRight == "Right")
            {
                spawnpos = gameObject.transform.position + new Vector3(1.0f, 1.0f, 0.0f);
                leftOrRight = "Left";
            }
            else if(leftOrRight == "Left")
            {
                spawnpos = gameObject.transform.position + new Vector3(-1.0f, 1.0f, 0.0f);
                leftOrRight = "Right";
            }

            Instantiate(baseBulletPrefab).transform.position = spawnpos;
            SetCanFire(false);
            AudioManagerScript.instance.CreateNewSound("ShotSound");

        }
    }
}
