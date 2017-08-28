using UnityEngine;
using System.Collections;

public class PlayerPointDefenceScript : PlayerWeaponBaseScript
{
    bool isFiring;

    Coroutine pointDefenceCoroutine;

    public override void Start()
    {
        isFiring = false;
        pointDefenceCoroutine = null;
        base.Start();
        SetCooldownTimer(10.0f);
        SetCanFire(true);
    }

    public override void Fire()
    {
        base.Fire();

        if(GetCanFire() == true)
        {
            pointDefenceCoroutine = StartCoroutine(PointDefenceTimer());
        }
    }

    void OnTriggerEnter(Collider _collider)
    {
        if(isFiring == true)
        {
            if (_collider.tag == "Enemy" || _collider.tag == "EnemyBullet")
            {
                GameObject temp = Instantiate(baseBulletPrefab);
                temp.transform.position = transform.position;
                temp.GetComponent<PlayerPointDefenceBulletScript>().SetTargetAndShoot(_collider.gameObject);

                //temp.transform.rotation.SetLookRotation(heading, Vector3.forward);

            }
        }
    }

    IEnumerator PointDefenceTimer()
    {
        isFiring = true;
        yield return new WaitForSeconds(10.0f);
        isFiring = false;
        SetCanFire(false);
        pointDefenceCoroutine = null;
    }
}
