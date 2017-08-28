using UnityEngine;
using System.Collections;

public class DeleteAfterTimeScript : MonoBehaviour {

    float time;

	public void SetTimeThenWait(float toSet)
    {
        time = toSet;
        StartCoroutine(Wait());
    }
	
	IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
