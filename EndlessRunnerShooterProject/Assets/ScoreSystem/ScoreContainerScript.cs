using UnityEngine;
using System.Collections;

public class ScoreContainerScript : MonoBehaviour {

    public static ScoreContainerScript instance;

    int score;

    bool winOrLose;

    void Start ()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
    void LateUpdate()
    {
        if(ApplicationManagerScript.instance.GetCurrentApplicationState() == "LOADOUTSCREEN")
        {
            Destroy(gameObject);
        }
    }

	public void SetScore(int toSet)
    {
        score = toSet;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetWinOrLose(bool toSet)
    {
        winOrLose = toSet;
    }
    public bool GetWinOrLose()
    {
        return winOrLose;
    }
}
