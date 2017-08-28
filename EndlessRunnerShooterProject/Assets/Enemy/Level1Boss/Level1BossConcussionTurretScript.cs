using UnityEngine;
using System.Collections;

public class Level1BossConcussionTurretScript : BaseEnemyScript {

    bool turretAlive;

    Coroutine shootingCoroutine;
    GameObject mesh;

    public GameObject deathEffect;

    public override void Start()
    {
        base.Start();
        health = 10;
        turretAlive = true;
        SetCanShoot(false);
        mesh = gameObject.transform.GetChild(0).gameObject;
        mesh.transform.Rotate(0.0f, 0.0f, -85.0f);
    }

    public override void Update()
    {

        if (turretAlive && GetCanShoot())
        {
            base.Update();
            if (shootingCoroutine == null)
            {
                shootingCoroutine = StartCoroutine(ShootTimer());
            }
        }
    }

    void FixedUpdate()
    {
        if (turretAlive == true)
        {
            Vector3 vectorToTarget = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10.0f);
        }

        //transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);


        //transform.Rotate(0.0f, 0.0f, 80.0f);
    }

    public override void OnTriggerEnter(Collider _collider)
    {

        base.OnTriggerEnter(_collider);
        if (turretAlive == true && _collider.tag == "PlayerBullet")
        {
            Level1BossManagerScript.instance.ReduceTotalHealthBy(1);
        }
    }

    public override void Die()
    {
        GameObject temp = Instantiate(deathEffect);
        temp.transform.position = transform.position;
        temp.transform.Rotate(-90.0f, 0.0f, 0.0f);
        turretAlive = false;
    }

    public bool GetAlive()
    {
        return turretAlive;
    }

    public override void ReduceHealth(int toReduceBy)
    {
        if (turretAlive)
        {
            base.ReduceHealth(toReduceBy);
        }
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(4.0f);
        Instantiate(bullet).transform.position = transform.position;
        shootingCoroutine = null;
    }
}
