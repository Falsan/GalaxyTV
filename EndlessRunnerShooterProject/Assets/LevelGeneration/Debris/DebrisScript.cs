using UnityEngine;
using System.Collections;

public class DebrisScript : MonoBehaviour {

    Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        rb.drag = 20.0f;
        StartCoroutine(Timeout());
    }
	
	void Update ()
    {
        if (GameManager.instance.GetGameState() != "Pause")
        {
            Vector3 velocity = new Vector3(0.0f, -50.0f, 0.0f);

            rb.AddForce(velocity);
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(20.0f);
        Die();
    }
}
