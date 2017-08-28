using UnityEngine;
using System.Collections;

public class PlayerScilthromeGunScript : PlayerWeaponBaseScript
{

    // Use this for initialization
    public override void Start()
    {
        SetCooldownTimer(2.0f);
        SetCanFire(true);
    }

    // Update is called once per frame
    public override void Fire()
    {
        base.Fire();
        if (GetCanFire() == true)
        {
            GameObject temp = baseBulletPrefab;
            temp.transform.position = gameObject.transform.position;
            Instantiate(temp);
            temp.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
            Instantiate(temp);
            temp.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
            Instantiate(temp);
            temp.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
            Instantiate(temp);
            temp.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
            Instantiate(temp);
            temp.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
            Instantiate(temp);
            temp.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
            Instantiate(temp);
            temp.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
            Instantiate(temp);
            temp.transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f));
            Instantiate(temp);

            SetCanFire(false);
        }
    }
}
