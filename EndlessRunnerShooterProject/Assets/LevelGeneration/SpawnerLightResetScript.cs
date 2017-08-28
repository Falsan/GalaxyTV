using UnityEngine;
using System.Collections;

public class SpawnerLightResetScript : MonoBehaviour {

    Coroutine lightReset = null;
	

	void LateUpdate ()
    {
	    if(GetComponent<Light>().intensity != 0)
        {
            if (lightReset == null)
            {
                lightReset = StartCoroutine(LightReset());
            }
        }
	}

    IEnumerator LightReset()
    {
        yield return new WaitForSeconds(1.0f);

        GetComponent<Light>().intensity = 0;
        GetComponent<Light>().range = 0;
        lightReset = null;
    }
}
