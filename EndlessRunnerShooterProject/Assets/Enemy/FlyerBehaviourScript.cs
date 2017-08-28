using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyerBehaviourScript : BaseEnemyScript {

    public enum FlyerStates
    {
        spin,
        flyStraight
    }

    public FlyerStates currentFlyerState;
    Rigidbody rb;
    Coroutine switchingCoroutine;

    protected float switchToStraightTime;
    protected float switchToCurveTime;

    int circleSwitcher;

    public override void Start ()
    {
        base.Start();
        currentFlyerState = FlyerStates.flyStraight;
        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        switchingCoroutine = StartCoroutine(SwitchToSpin());
        circleSwitcher = 0;

        switchToStraightTime = 2.9f;
        switchToCurveTime = 2.0f;
    }


    public override void Update ()
    {
        base.Update();
        if (GameManager.instance.GetGameState() != "Pause")
        {
            Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);


            if (switchingCoroutine == null)
            {
                if (currentFlyerState == FlyerStates.flyStraight)
                {
                    transform.rotation = Quaternion.identity;
                    rb.angularVelocity = Vector3.zero;
                    switchingCoroutine = StartCoroutine(SwitchToSpin());
                }
                else if (currentFlyerState == FlyerStates.spin)
                {
                    switchingCoroutine = StartCoroutine(SwitchToStraight());
                }
            }

            if (currentFlyerState == FlyerStates.flyStraight)
            {
                velocity = new Vector3(0.0f, -speed, 0.0f);
                rb.angularVelocity = Vector3.zero;
                rb.AddForce(velocity);
            }
            else if (currentFlyerState == FlyerStates.spin)
            {

                if (circleSwitcher == 0)
                {


                    rb.AddTorque(transform.forward * 20.0f * 20.0f);

                    circleSwitcher++;
                }
                else if (circleSwitcher == 3)
                {
                    circleSwitcher = 0;
                }
                else
                {
                    circleSwitcher++;
                }

                rb.AddRelativeForce(Vector3.up * -speed, ForceMode.Force);
                rb.angularVelocity = Vector3.zero;

            }
        }
    }

    public override void OnTriggerEnter(Collider _collider)
    {
        base.OnTriggerEnter(_collider);
    }

    IEnumerator SwitchToSpin()
    {
        yield return new WaitForSeconds(switchToCurveTime);
        currentFlyerState = FlyerStates.spin;
        switchingCoroutine = null;
    }

    IEnumerator SwitchToStraight()
    {
        yield return new WaitForSeconds(switchToStraightTime);
        currentFlyerState = FlyerStates.flyStraight;
        switchingCoroutine = null;
    }

}
