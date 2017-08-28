using UnityEngine;
using System.Collections;

public class SquarePathBehaviourScript : BaseEnemyScript {

    public enum SquareStates
    {
        spin,
        flyStraight
    }

    public SquareStates currentFlyerState;
    Rigidbody rb;
    Coroutine switchingCoroutine;

    protected float switchToStraightTime;
    protected float switchToCurveTime;

    int circleSwitcher;

    public int arcStage = 1;

    public override void Start()
    {
        base.Start();
        currentFlyerState = SquareStates.flyStraight;
        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        //switchingCoroutine = StartCoroutine(SwitchToSpin());
        circleSwitcher = 0;

        switchToStraightTime = 0.7f;
        switchToCurveTime = 1.5f;
        arcStage = 1;
    }


    public override void Update()
    {
        base.Update();
        if (GameManager.instance.GetGameState() != "Pause")
        {
            Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);


            if (switchingCoroutine == null)
            {
                if (currentFlyerState == SquareStates.flyStraight)
                {
                    rb.angularVelocity = Vector3.zero;
                    if (arcStage == 1)
                    {
                        transform.localEulerAngles = Vector3.zero;
                    }
                    else if (arcStage == 2)
                    {
                        transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                    }
                    else if (arcStage == 3)
                    {
                        transform.localEulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                    }
                    else if (arcStage == 4)
                    {
                        transform.localEulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
                    }

                    switchingCoroutine = StartCoroutine(SwitchToSpin());
                }
                else if (currentFlyerState == SquareStates.spin)
                {
                    switchingCoroutine = StartCoroutine(SwitchToStraight());
                }
            }

            if (currentFlyerState == SquareStates.flyStraight)
            {
                //velocity = new Vector3(0.0f, -200.0f, 0.0f);
                rb.angularVelocity = Vector3.zero;

                rb.AddRelativeForce(Vector3.up * -speed, ForceMode.Force);

            }
            else if (currentFlyerState == SquareStates.spin)
            {

                if (circleSwitcher == 0)
                {
                    Vector3 torque = new Vector3(0.0f, 0.0f, 200.0f);
                    rb.AddTorque(torque);


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
        currentFlyerState = SquareStates.spin;

        arcStage++;
        if(arcStage == 5)
        {
            arcStage = 1;
        }

        switchingCoroutine = null;
    }

    IEnumerator SwitchToStraight()
    {
        yield return new WaitForSeconds(switchToStraightTime);
        currentFlyerState = SquareStates.flyStraight;
        switchingCoroutine = null;
    }
}
