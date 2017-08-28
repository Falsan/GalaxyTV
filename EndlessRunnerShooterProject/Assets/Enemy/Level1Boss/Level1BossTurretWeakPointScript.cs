using UnityEngine;
using System.Collections;

public class Level1BossTurretWeakPointScript : BaseEnemyScript {

    bool vulnerable;
    bool weakPointAlive;

    public GameObject deathEffect;

    public override void Start()
    {
        base.Start();
        health = 10;
        vulnerable = false;
        weakPointAlive = true;
    }

    public override void Update()
    {

        if (weakPointAlive)
        {
            base.Update();
            
        }
    }

    public override void OnTriggerEnter(Collider _collider)
    {

        base.OnTriggerEnter(_collider);
        if (weakPointAlive == true && vulnerable == true && _collider.tag == "PlayerBullet")
        {
            Level1BossManagerScript.instance.ReduceTotalHealthBy(1);
        }
    }

    public override void Die()
    {
        GameObject temp = Instantiate(deathEffect);
        temp.transform.position = transform.position;
        temp.transform.Rotate(-90.0f, 0.0f, 0.0f);
        weakPointAlive = false;
    }

    public override void ReduceHealth(int toReduceBy)
    {
        if (weakPointAlive && vulnerable == true)
        {
            base.ReduceHealth(toReduceBy);
        }
    }

    public void MakeVulnerable()
    {
        StartCoroutine(VulnerableCountdown());
    }

    public bool GetAlive()
    {
        return weakPointAlive;
    }

    IEnumerator VulnerableCountdown()
    {
        if (vulnerable == false)
        {
            //play animation
            yield return new WaitForSeconds(1.0f);
            //for debug
            GetComponent<MeshRenderer>().material.color = new Color(255.0f, 0.0f, 0.0f);
            vulnerable = true;
        }
        else if (vulnerable == true)
        {
            //play animation
            yield return new WaitForSeconds(1.0f);
            //for debug
            GetComponent<MeshRenderer>().material.color = new Color(255.0f, 255.0f, 255.0f);
            vulnerable = false;
        }
    }
}
