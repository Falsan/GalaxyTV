using UnityEngine;
using System.Collections;

public class LeftToRightBehaviourScript : BaseEnemyScript {

    enum Directions
    {
        left,
        right
    }

    Directions currentDirection;

    Rigidbody rb;
    Coroutine swapDirectionCoroutine;

    // Use this for initialization
    public override void Start()
    {

        base.Start();

        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        swapDirectionCoroutine = null;

        currentDirection = Directions.right;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (GameManager.instance.GetGameState() != "Pause")
        {

            if (swapDirectionCoroutine == null)
            {
                swapDirectionCoroutine = StartCoroutine(SwapDirection());
            }

            if (currentDirection == Directions.right)
            {
                transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
            }
            else if (currentDirection == Directions.left)
            {
                transform.localEulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
            }

            rb.AddRelativeForce(Vector3.up * -speed, ForceMode.Force);

        }
    }

    public override void OnTriggerEnter(Collider _collider)
    {
        base.OnTriggerEnter(_collider);
    }

    IEnumerator SwapDirection()
    {
        yield return new WaitForSeconds(4.0f);

        if(currentDirection == Directions.left)
        {
            currentDirection = Directions.right;
        }
        else if(currentDirection == Directions.right)
        {
            currentDirection = Directions.left;
        }

        swapDirectionCoroutine = null;
    }
}
