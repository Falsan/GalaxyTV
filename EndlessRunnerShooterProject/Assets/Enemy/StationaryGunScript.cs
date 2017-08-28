using UnityEngine;
using System.Collections;

public class StationaryGunScript : BaseEnemyScript {

    Rigidbody rb;

    // Use this for initialization
    public override void Start ()
    {
        base.health = 4;
        rb = GetComponent<Rigidbody>();

        rb.drag = 20.0f;
        StartCoroutine(Timeout());
	}
	
	// Update is called once per frame
	public override void Update ()
    {
        base.Update();
        if (GameManager.instance.GetGameState() != "Pause")
        {
            Vector3 velocity = new Vector3(0.0f, -50.0f, 0.0f);

            rb.AddForce(velocity);
        }

    }

    public override void OnTriggerEnter(Collider _collider)
    {
        base.OnTriggerEnter(_collider);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(20.0f);
        Die();
    }

}
