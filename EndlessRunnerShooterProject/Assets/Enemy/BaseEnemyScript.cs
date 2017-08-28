using UnityEngine;
using System.Collections;

public class BaseEnemyScript : MonoBehaviour {

    public int health;

    public GameObject hiteffect;

    public GameObject bullet;

    public bool canShoot;

    Coroutine shootingCoroutine;

    public float speed;

    public float shootingDelay;

    float timeToTurn;

    float timeAlreadyPassed;

    int scoreWorth;

    float waitingStarted;

    float realShootingDelay;

    float timeInstansiated;

    bool stopOperationsDone;

    public virtual void Awake()
    {
        scoreWorth = 0;
        timeInstansiated = Time.time;
    }

    public virtual void Start () {
        
        health = 1;

        realShootingDelay = shootingDelay;

        shootingCoroutine = null;

        if(shootingDelay == 0.0f)
        {
            shootingDelay = 2.0f;
        }

        if(bullet != null)
        {
            canShoot = true;
        }
        stopOperationsDone = false;
    }

    public virtual void Update ()
    {
        if (GameManager.instance.GetGameState() != "Pause")
        {
            if (health <= 0)
            {
                Die();
            }


            if (shootingCoroutine == null && canShoot == true && !PlayerStatusScript.instance.GetIsDead())
            {
                shootingCoroutine = StartCoroutine(ShootTimer());
            }
            stopOperationsDone = false;
        }
        else
        {
            if (stopOperationsDone == false)
            {
                float timeStopped = Time.time;

                StopCoroutine(ShootTimer());
                if (shootingCoroutine != null)
                {
                    StopCoroutine(shootingCoroutine);
                }
                shootingCoroutine = null;
                timeAlreadyPassed = timeStopped - waitingStarted;
                stopOperationsDone = true;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider _collider)
    {
        if(_collider.tag == "Player")
        {
            _collider.GetComponent<PlayerStatusScript>().ReduceHealth(1);
            AudioManagerScript.instance.CreateNewSound("ShipHit");
            //hurt player
            ReduceHealth(1);
        }
        else if(_collider.tag == "Killbox")
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Instantiate(hiteffect).transform.position = transform.position;
        ScoreManagerScript.instance.IncreaseScoreBy(scoreWorth, transform);
        Destroy(gameObject);
    }

    public virtual void ReduceHealth(int toReduceBy)
    {
        health = health - toReduceBy;
    }

    IEnumerator ShootTimer()
    {
        waitingStarted = Time.time;
        if(timeAlreadyPassed > 0)
        {
            realShootingDelay = shootingDelay - timeAlreadyPassed;
            timeAlreadyPassed = 0;
            yield return new WaitForSeconds(realShootingDelay);
        }
        else
        {
            yield return new WaitForSeconds(shootingDelay);
        }

        if (GameManager.instance.GetGameState() != "Pause")
        {
            AudioManagerScript.instance.CreateNewSound("ShotSound");
            Instantiate(bullet).transform.position = transform.position;
        }
        shootingCoroutine = null;
    }

    public void SetCanShoot(bool toSet)
    {
        canShoot = toSet;
    }

    public bool GetCanShoot()
    {
        return canShoot;
    }

    public void SetShootingDelay(float toSet)
    {
        shootingDelay = toSet;
    }

    public void SetSpeed(float toSet)
    {
        speed = toSet;
    }

    public void SetTimeToTurn(float toSet)
    {
        timeToTurn = toSet;
    }

    public float GetTimeToTurn()
    {
        return timeToTurn;
    }

    public void SetScoreWorth(int toSet)
    {
        scoreWorth = toSet;
    }

    public int GetScoreWorth()
    {
        return scoreWorth;
    }
}
