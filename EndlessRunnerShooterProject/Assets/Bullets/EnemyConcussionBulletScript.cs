using UnityEngine;
using System.Collections;

public class EnemyConcussionBulletScript : MonoBehaviour
{


    Rigidbody rb;
    public GameObject hitEffect;
    Vector3 deathPosition;

    void Start () {

        deathPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        transform.LookAt(deathPosition);
    }


    void Update()
    {
        rb.AddRelativeForce(Vector3.forward * 800.0f, ForceMode.Force);

        if(Vector3.Distance(transform.position, deathPosition) <= 1)
        {
            Die();
        }
    }

    protected void OnTriggerEnter(Collider _collider)
    {
        if (_collider.tag == "Player")
        {
            _collider.GetComponent<PlayerStatusScript>().ReduceHealth(1);
            Die();
        }
    }

    public void Die()
    {
        StopAllCoroutines();
        Instantiate(hitEffect).transform.position = transform.position;
        Destroy(gameObject);
    }
}
