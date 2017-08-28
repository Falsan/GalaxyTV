using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

    Rigidbody rb;
    public GameObject hitEffect;

    Vector3 velocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        StartCoroutine(Timeout());

        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetGameState() != "Pause")
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddRelativeForce(Vector3.forward * 600.0f, ForceMode.Force);
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    protected void OnTriggerEnter(Collider _collider)
    {
        if (_collider.tag == "Player")
        {
            AudioManagerScript.instance.CreateNewSound("ShipHit");
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

    protected IEnumerator Timeout()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

}
