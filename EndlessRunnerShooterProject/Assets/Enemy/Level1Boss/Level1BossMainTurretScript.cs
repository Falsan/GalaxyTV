using UnityEngine;
using System.Collections;

public class Level1BossMainTurretScript : MonoBehaviour {

    GameObject leftSide;
    GameObject rightSide;
    GameObject centre;

    GameObject weakPoint1;
    GameObject weakPoint2;

    GameObject previousTarget;
    GameObject target;
    Coroutine shootingCoroutine;

    GameObject chargingParticleSystem;

    public GameObject bulletPrefab;

    float timeToCharge = 3.0f;

    bool waiting;

    bool isAlive;

	// Use this for initialization
	void Start ()
    {
        leftSide = GameObject.Find("LeftSidePoint");
        rightSide = GameObject.Find("RightSidePoint");
        centre = GameObject.Find("CentrePoint");
        weakPoint1 = GameObject.Find("Level1BossTurretWeakPoint");
        weakPoint2 = GameObject.Find("Level1BossTurretWeakPoint2");
        waiting = true;
        shootingCoroutine = null;
        isAlive = true;
        previousTarget = null;
        target = null;

        chargingParticleSystem = transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        if (!weakPoint1.GetComponent<Level1BossTurretWeakPointScript>().GetAlive() &&
        !weakPoint2.GetComponent<Level1BossTurretWeakPointScript>().GetAlive())
        {
            isAlive = false;
        }

        if (isAlive)
        {
            if (weakPoint1.GetComponent<Level1BossTurretWeakPointScript>().GetAlive() &&
                weakPoint2.GetComponent<Level1BossTurretWeakPointScript>().GetAlive())
            {
                timeToCharge = 3.0f;
            }
            else if (!weakPoint1.GetComponent<Level1BossTurretWeakPointScript>().GetAlive() ||
                !weakPoint2.GetComponent<Level1BossTurretWeakPointScript>().GetAlive())
            {
                timeToCharge = 6.0f;
            }

            if (shootingCoroutine == null)
            {
                if (waiting == true)
                {
                    shootingCoroutine = StartCoroutine(WaitToShoot());
                }
                else if (waiting == false)
                {
                    shootingCoroutine = StartCoroutine(PrepareToFire());
                }
            }
        }

    }

    public void Fire()
    {
        GameObject temp = Instantiate(bulletPrefab);
        temp.transform.position = transform.position;
        //temp.transform.LookAt(target.transform);

        if (target == rightSide)
        {
            temp.transform.Rotate(0.0f, 0.0f, 40.0f);
        }
        else if (target == centre)
        {
            temp.transform.Rotate(0.0f, 0.0f, 0.0f);
        }
        else if (target == leftSide)
        {
            temp.transform.Rotate(0.0f, 0.0f, -40.0f);
        }
        temp.transform.position = transform.position;
        temp.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        temp.GetComponent<LineRenderer>().SetPosition(1, target.transform.position);

        if (target == centre)
        {
            temp.transform.Rotate(new Vector3(-90.0f, 0.0f, 0.0f));
        }
    }

    void SwitchVulnerable()
    {
        weakPoint1.GetComponent<Level1BossTurretWeakPointScript>().MakeVulnerable();
        weakPoint2.GetComponent<Level1BossTurretWeakPointScript>().MakeVulnerable();

        if (chargingParticleSystem.GetComponent<ParticleSystem>().isPlaying)
        {
            chargingParticleSystem.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            chargingParticleSystem.GetComponent<ParticleSystem>().Play();
        }
    }

    IEnumerator SwitchVulnerableCountdown()
    {
        yield return new WaitForSeconds(3.0f);
        SwitchVulnerable();
    }

    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(10.0f);
        waiting = false;
        shootingCoroutine = null;
    }

    IEnumerator PrepareToFire()
    {
        SwitchVulnerable();

        if (target != null)
        {
            previousTarget = target;
            target = null;
        }
        if(previousTarget == null)
        {
            previousTarget = centre;
        }

        float leftDistance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, leftSide.transform.position);
        float rightDistance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, rightSide.transform.position);
        float centreDistance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, centre.transform.position);

        if (leftDistance < centreDistance)
        {
            target = leftSide;
            if(previousTarget == rightSide)
            {
                transform.Rotate(0.0f, 0.0f, 40.0f);
                transform.Rotate(0.0f, 0.0f, 40.0f);
            }
            else if(previousTarget == centre)
            {
                transform.Rotate(0.0f, 0.0f, 40.0f);
            }
            else if(previousTarget == leftSide)
            {

            }

        }
        else if (rightDistance < centreDistance)
        {
            target = rightSide;
            if (previousTarget == leftSide)
            {
                transform.Rotate(0.0f, 0.0f, -40.0f);
                transform.Rotate(0.0f, 0.0f, -40.0f);
            }
            else if (previousTarget == centre)
            {
                transform.Rotate(0.0f, 0.0f, -40.0f);
            }
            else if (previousTarget == rightSide)
            {

            }

        }
        else
        {
            target = centre;
            if (previousTarget == leftSide)
            {
                transform.Rotate(0.0f, 0.0f, -40.0f);
            }
            else if (previousTarget == centre)
            {

            }
            else if (previousTarget == rightSide)
            {
                transform.Rotate(0.0f, 0.0f, 40.0f);
            }

        }



        yield return new WaitForSeconds(timeToCharge);

        Fire();

        SwitchVulnerable();
        waiting = true;
        shootingCoroutine = null;
    }
}
