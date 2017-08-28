using UnityEngine;
using System.Collections;

public class CutsceneManagerScript : MonoBehaviour {

    GameObject levelToLoadObject;
    
    public GameObject level1CutSceneDisplayer;
    public GameObject level2CutSceneDisplayer;

	// Use this for initialization
	void Awake ()
    {
        levelToLoadObject = GameObject.Find("LevelToLoadObject(Clone)");

        if(levelToLoadObject.GetComponent<LevelToLoadObjectScript>().GetLevelToLoad() == "Level1")
        {
            Instantiate(level1CutSceneDisplayer);
        }
        else if(levelToLoadObject.GetComponent<LevelToLoadObjectScript>().GetLevelToLoad() == "Level2")
        {
            Instantiate(level2CutSceneDisplayer);
        }

        Destroy(levelToLoadObject);
	}
	
}
