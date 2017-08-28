using UnityEngine;
using System.Collections;

public class Level1BossFighterSpawnerScript : BaseEnemyScript {

    bool spawnerAlive;
    public bool canSpawn;

    public GameObject ship;
    Coroutine spawningCoroutine;

    public GameObject deathEffect;

    public override void Start()
    {
        base.Start();
        health = 10;
        spawnerAlive = true;
        SetCanShoot(false);
        canSpawn = false;
    }

    public override void Update()
    {

        if (spawnerAlive && canSpawn)
        {
            base.Update();
            if (spawningCoroutine == null)
            {
                spawningCoroutine = StartCoroutine(ShootTimer());
            }
        }
    }

    public override void OnTriggerEnter(Collider _collider)
    {

        base.OnTriggerEnter(_collider);
        if (spawnerAlive == true && _collider.tag == "PlayerBullet")
        {
            Level1BossManagerScript.instance.ReduceTotalHealthBy(1);
        }

    }

    public override void Die()
    {
        GameObject temp = Instantiate(deathEffect);
        temp.transform.position = transform.position;
        temp.transform.Rotate(-90.0f, 0.0f, 0.0f);
        spawnerAlive = false;
    }

    public override void ReduceHealth(int toReduceBy)
    {
        if (spawnerAlive)
        {
            base.ReduceHealth(toReduceBy);
        }
    }

    public bool GetAlive()
    {
        return spawnerAlive;
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(10.0f);
        GameObject newShip = ship;
        newShip.GetComponent<BaseEnemyScript>().bullet = EnemySpawningScript.instance.ReturnBulletTypeForString("Bullet");
        newShip.GetComponent<BaseEnemyScript>().SetTimeToTurn(4.0f);
        newShip.GetComponent<BaseEnemyScript>().SetCanShoot(true);
        newShip.GetComponent<BaseEnemyScript>().SetShootingDelay(shootingDelay);
        newShip.GetComponent<BaseEnemyScript>().SetSpeed(300.0f);
        Instantiate(newShip).transform.position = transform.position;
        spawningCoroutine = null;
    }
}
