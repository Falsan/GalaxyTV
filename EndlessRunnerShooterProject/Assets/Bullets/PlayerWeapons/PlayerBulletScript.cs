using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {

    Rigidbody rb;
    public GameObject hitEffect;

    public virtual void Start () {
        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        StartCoroutine(Timeout());
    }

    // Update is called once per frame
    public virtual void Update ()
    {

        Vector3 velocity = new Vector3(0.0f, 800.0f, 0.0f);

        rb.AddRelativeForce(velocity);
    }

    public virtual void OnTriggerEnter(Collider _collider)
    {

        if (_collider.tag == "Enemy")
        {
            _collider.GetComponent<BaseEnemyScript>().ReduceHealth(1);
            AudioManagerScript.instance.CreateNewSound("ShipHit");
            Die();
        }
        else if(_collider.tag == "EnemyBullet")
        {
            AudioManagerScript.instance.CreateNewSound("ShipHit");
            if (_collider.GetComponent<EnemyBulletScript>())
            {
                _collider.GetComponent<EnemyBulletScript>().Die();
                Die();
            }
            else if(_collider.GetComponent<EnemyConcussionBulletScript>())
            {
                _collider.GetComponent<EnemyConcussionBulletScript>().Die();
                Die();
            }
        }
    }

    public virtual void Die()
    {
        StopAllCoroutines();
        Instantiate(hitEffect).transform.position = transform.position;
        Destroy(gameObject);
    }

    public virtual IEnumerator Timeout()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
