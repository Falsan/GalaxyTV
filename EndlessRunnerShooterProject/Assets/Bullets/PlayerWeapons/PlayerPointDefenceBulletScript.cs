using UnityEngine;
using System.Collections;

public class PlayerPointDefenceBulletScript : PlayerBulletScript
{
    bool hasTarget;
    Rigidbody rb;
    GameObject target;

	// Use this for initialization
	public override void Start ()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        StartCoroutine(Timeout());
    }

    public override void Update()
    {
        if (hasTarget == true)
        {
            //Vector3 velocity = new Vector3(0.0f, 200.0f, 0.0f);
            transform.LookAt(target.transform);
            rb.AddRelativeForce(Vector3.forward * 200.0f, ForceMode.Force);
        }
    }

    public void SetTargetAndShoot(GameObject toSet)
    {
        target = toSet;
        transform.LookAt(target.transform);
        hasTarget = true;
    }
}
