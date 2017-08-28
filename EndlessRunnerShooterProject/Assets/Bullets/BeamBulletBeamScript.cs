using UnityEngine;
using System.Collections;

public class BeamBulletBeamScript : MonoBehaviour {

    bool isDeadly = false;

    void Start()
    {

        StartCoroutine(KillTimer());


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
}
