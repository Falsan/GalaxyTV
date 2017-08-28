using UnityEngine;
using System.Collections;

public class PlayerWeaponBaseScript : MonoBehaviour {

    public GameObject baseBulletPrefab;

    float cooldownTimer;

    bool canFire;

    // Use this for initialization
    public virtual void Start()
    {
        canFire = true;
        cooldownTimer = 0.1f;
    }



    public virtual void Fire()
    {
        if (GetCanFire() == true)
        {



            StartCoroutine(Cooldown());
        }
    }

    public virtual IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);

        canFire = true;
    }

    public bool GetCanFire()
    {
        return canFire;
    }

    public void SetCanFire(bool toSet)
    {
        canFire = toSet;
    }

    public void SetCooldownTimer(float toSet)
    {
        cooldownTimer = toSet;
    }

    public float GetCooldownTimer()
    {
        return cooldownTimer;
    }

    public void SetBullet(GameObject toSet)
    {
        baseBulletPrefab = toSet;
    }
}
