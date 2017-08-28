using UnityEngine;
using System.Collections;

public class PlayerEnergyShieldScript : PlayerWeaponBaseScript
{


	// Use this for initialization
	public override void Start ()
    {
        SetCooldownTimer(30.0f);
        SetCanFire(true);
        //GetComponent<PlayerStatusScript>().SetTempHealth(10);
	}
	
	// Update is called once per frame
	public override void Fire ()
    {
        base.Fire();

        if (GetCanFire() == true)
        {
            GetComponent<PlayerStatusScript>().SetTempHealth(10);
            StartCoroutine(ShieldTimer());
            SetCanFire(false);
        }

    }

    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(10.0f);
        GetComponent<PlayerStatusScript>().SetTempHealth(0);
    }
}
