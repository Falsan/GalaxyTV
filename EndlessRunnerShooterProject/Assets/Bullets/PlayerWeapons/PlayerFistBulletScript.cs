using UnityEngine;
using System.Collections;

public class PlayerFistBulletScript : PlayerBulletScript {

    bool isDeadly;

    public override void Start()
    {
        base.Start();
        isDeadly = true;
    }

    public override void OnTriggerEnter(Collider _collider)
    {
        if (_collider.tag == "Enemy" && isDeadly == true)
        {
            AudioManagerScript.instance.CreateNewSound("ShipHit");
            _collider.GetComponent<BaseEnemyScript>().ReduceHealth(1);
            isDeadly = false;
            StartCoroutine(HurtDelay());

        }
        else if (_collider.tag == "EnemyBullet" && isDeadly == true)
        {
            AudioManagerScript.instance.CreateNewSound("ShipHit");
            if (_collider.GetComponent<EnemyBulletScript>())
            {
                _collider.GetComponent<EnemyBulletScript>().Die();
                isDeadly = false;
                StartCoroutine(HurtDelay());

            }
            else if (_collider.GetComponent<EnemyConcussionBulletScript>())
            {
                _collider.GetComponent<EnemyConcussionBulletScript>().Die();
                isDeadly = false;
                StartCoroutine(HurtDelay());

            }
        }
    }

    void OnTriggerStay(Collider _collider)
    {
        OnTriggerEnter(_collider);
    }

    IEnumerator HurtDelay()
    {
        yield return new WaitForSeconds(0.1f);
        isDeadly = true;
    }

}
