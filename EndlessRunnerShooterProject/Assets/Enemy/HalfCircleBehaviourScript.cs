using UnityEngine;
using System.Collections;

public class HalfCircleBehaviourScript : BaseEnemyScript {

    public enum HalfCircleStates
    {
        spin,
        flyStraight
    }

    public HalfCircleStates currentFlyerState;
    Rigidbody rb;
    Coroutine switchingCoroutine;

    bool goDown;

    protected float switchToStraightTime;
    protected float switchToCurveTime;

    int circleSwitcher;

    public override void Start()
    {
        base.Start();
        currentFlyerState = HalfCircleStates.flyStraight;
        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        //switchingCoroutine = StartCoroutine(SwitchToSpin());
        circleSwitcher = 0;

        switchToStraightTime = 1.5f;
        switchToCurveTime = 1.5f;
        goDown = true;
    }


    public override void Update()
    {
        base.Update();
        if (GameManager.instance.GetGameState() != "Pause")
        {
            Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);


            if (switchingCoroutine == null)
            {
                if (currentFlyerState == HalfCircleStates.flyStraight)
                {
                    if (goDown == true)
                    {
                        transform.rotation = Quaternion.identity;
                    }
                    else if (goDown == false)
                    {
                        transform.rotation = new Quaternion(0.0f, 0.0f, 180.0f, 0.0f);
                    }
                    rb.angularVelocity = Vector3.zero;
                    switchingCoroutine = StartCoroutine(SwitchToSpin());
                }
                else if (currentFlyerState == HalfCircleStates.spin)
                {
                    switchingCoroutine = StartCoroutine(SwitchToStraight());
                }
            }

            if (currentFlyerState == HalfCircleStates.flyStraight)
            {
                //velocity = new Vector3(0.0f, -200.0f, 0.0f);
                rb.angularVelocity = Vector3.zero;

                rb.AddRelativeForce(Vector3.up * -speed, ForceMode.Force);

            }
            else if (currentFlyerState == HalfCircleStates.spin)
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
        currentFlyerState = HalfCircleStates.spin;
        switchingCoroutine = null;
        if(goDown == true)
        {
            goDown = false;
        }
        else if (goDown == false)
        {
            goDown = true;
        }
    }

    IEnumerator SwitchToStraight()
    {
        yield return new WaitForSeconds(switchToStraightTime);
        currentFlyerState = HalfCircleStates.flyStraight;
        switchingCoroutine = null;
    }


}
