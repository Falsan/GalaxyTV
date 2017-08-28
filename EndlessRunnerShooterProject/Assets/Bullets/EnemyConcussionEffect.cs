using UnityEngine;
using System.Collections;

public class EnemyConcussionEffect : MonoBehaviour {

    bool isDeadly;

    // Use this for initialization
    void Start () {

        isDeadly = true;
    }
	
	// Update is called once per frame
	void Update () {

        transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
        GetComponent<SphereCollider>().transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);

        if (transform.localScale.x > 7.0f)
        {
            Destroy(gameObject);
        }
	}

    protected void OnTriggerStay(Collider _collider)
    {
        if (_collider.tag == "Player" && isDeadly == true)
        {
            _collider.GetComponent<PlayerStatusScript>().ReduceHealth(1);
            isDeadly = false;
            StartCoroutine(HurtDelay());
        }
    }

    IEnumerator HurtDelay()
    {
        yield return new WaitForSeconds(0.1f);
        isDeadly = true;
    }
}
