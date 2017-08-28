using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    string GameState;

    float timePressedPause;
    float timeTaken;

	void Start () {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GameState = "null";
    }
	
	void LateUpdate ()
    {
        if (PlayerStatusScript.instance != null)
        {
            if (PlayerStatusScript.instance.GetIsDead())
            {
                GameState = "PlayerDeath";
            }
        }
	    if(ApplicationManagerScript.instance.currentApplicationState == "LEVEL1PLAY" && GameState == "null")
        {
            LevelCreator.instance.SetLevel("Level1");
            GameState = "Loading";
        }
        else if(ApplicationManagerScript.instance.currentApplicationState == "LEVEL2PLAY" && GameState == "null")
        {
            LevelCreator.instance.SetLevel("Level2");
            GameState = "Loading";
        }
        if(GameState == "Play" && ApplicationManagerScript.instance.currentApplicationState == "LEVEL1PLAY"
            && Level1Script.instance.levelState == "null")
        {
            Level1Script.instance.SetLevelState("BeginLevel");
            GameState = "Playing";
        }
        else if(GameState == "Play" && ApplicationManagerScript.instance.currentApplicationState == "LEVEL2PLAY" 
            && Level2Script.instance.levelState == "null")
        {
            Level2Script.instance.SetLevelState("BeginLevel");
            GameState = "Playing";
        }

        if(GameState == "Playing")
        {
            for (int iter = 0; iter < InputManagerScript.instance.GetKeysPressed().Count; iter++)
            {
                if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[7].GetKeyCode())
                {
                    GameState = "Pause";
                    timePressedPause = Time.time;
                }
            }

        }
        else if(GameState == "Pause")
        {

        }
        if(GameState == "Win")
        {
            Debug.Log("Win");
            ApplicationManagerScript.instance.currentApplicationState = "WINSCREEN";
        }
        else if(GameState == "PlayerDeath")
        {
            ApplicationManagerScript.instance.currentApplicationState = "WINSCREEN";
        }
	}

    public string GetGameState()
    {
        return GameState;
    }
    public void SetGameState(string toSet)
    {
        GameState = toSet;
    }

    public float GetTimeTaken()
    {
        return timeTaken;
    }
}
