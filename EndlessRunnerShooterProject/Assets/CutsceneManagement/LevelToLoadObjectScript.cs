using UnityEngine;
using System.Collections;

public class LevelToLoadObjectScript : MonoBehaviour {

    string levelToLoad;

	public void SetLevelToLoad(string toSet)
    {
        levelToLoad = toSet;
    }

    public string GetLevelToLoad()
    {
        return levelToLoad;
    }
}
