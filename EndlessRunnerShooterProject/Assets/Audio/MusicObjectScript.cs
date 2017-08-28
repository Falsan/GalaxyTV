using UnityEngine;
using System.Collections;

public class MusicObjectScript : MonoBehaviour {

    AudioSource music;

	// Use this for initialization
	void Start () {

        music = GetComponent<AudioSource>();

        transform.parent = AudioManagerScript.instance.transform;

        music.loop = true;

        
	}
	
	// Update is called once per frame
	void Update () {
	
        if(music.isPlaying == false)
        {
            music.Play();
        }
	}
}
