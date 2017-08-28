using UnityEngine;
using System.Collections;

public class ScrollingBackgroundScript : MonoBehaviour {

    Rigidbody rb;
    bool isStopped;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        rb.drag = 20.0f;
        isStopped = false;
    }
	

	void Update ()
    {
        if (isStopped == false)
        {
            Vector3 velocity = new Vector3(0.0f, -50.0f, 0.0f);

            rb.drag = 20.0f;
            rb.AddForce(velocity);
        }
        else
        {
            Vector3 velocity2 = new Vector3(0.0f, 0.0f, 0.0f);

            rb.drag = 50000000.0f;
            rb.AddForce(velocity2);
        }
        if(transform.position.y <= -280)
        {
            transform.position = new Vector3(0.0f, 220.7f, 9.0f);
        }
    }

    public void SetIsStopped(bool toSet)
    {
        isStopped = toSet;
    }

    public bool GetIsStopped()
    {
        return isStopped;
    }
}
