using UnityEngine;
using System.Collections;

public class EnemyBeamBulletScript : MonoBehaviour {

    bool isDeadly = false;

	// Use this for initialization
	void Start () {

        StartCoroutine(Timeout());
        StartCoroutine(KillTimer());
        
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        
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

    IEnumerator KillTimer()
    {
        yield return new WaitForSeconds(2);
        isDeadly = true;
    }

    protected IEnumerator Timeout()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
