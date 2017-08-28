using UnityEngine;
using System.Collections;

public class AnnouncementScript : MonoBehaviour {

    string effect;

	void Start ()
    {
        transform.parent = GameObject.Find("InGameUI(Clone)").transform;
        transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
	}

    public string GetEffect()
    {
        return effect;
    }

    public void SetEffect(string toSet)
    {
        effect = toSet;
    }

    public void SpawnEffectScript()
    {
        if(effect == "shake")
        {
            gameObject.AddComponent<ShakeAnnouncementScript>();
        }
        else if(effect == "spin")
        {
            gameObject.AddComponent<SpinAnnouncementScript>();
        }
        else if(effect == "still")
        {
            gameObject.AddComponent<StillAnnouncementScript>();
        }
        else if(effect == "rumble")
        {
            gameObject.AddComponent<RumbleAnnouncementScript>();
        }
    }
}
