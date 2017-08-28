using UnityEngine;
using System.Collections;

public class HitEffectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine(Timeout());

	}

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
