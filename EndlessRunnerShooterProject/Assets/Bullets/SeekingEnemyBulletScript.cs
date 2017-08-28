using UnityEngine;
using System.Collections;

public class SeekingEnemyBulletScript : EnemyBulletScript
{

    Rigidbody rb;
    public GameObject hitEffect;

    Vector3 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        StartCoroutine(Timeout());



    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        rb.AddRelativeForce(Vector3.forward * 200.0f, ForceMode.Force);
    }

    void OnTriggerEnter(Collider _collider)
    {
        base.OnTriggerEnter(_collider);
    }

    public void Die()
    {
        base.Die();
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
