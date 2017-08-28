using UnityEngine;
using System.Collections;

public class SoundObjectScript : MonoBehaviour {

    AudioSource sound;
    float endTime;

    // Use this for initialization
    void Start()
    {

        sound = GetComponent<AudioSource>();

        transform.parent = AudioManagerScript.instance.transform;

        sound.playOnAwake = true;
        sound.loop = false;

        endTime = sound.clip.length;
        StartCoroutine(DestroyCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        if(sound.isPlaying == false)
        {
            sound.Play();
        }


    }

    IEnumerator DestroyCountdown()
    {
        yield return new WaitForSeconds(endTime);
        Destroy(gameObject);
    }
}
