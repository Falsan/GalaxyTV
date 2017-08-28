using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerScript : MonoBehaviour {

    public static ScoreManagerScript instance;

    int totalScore;

    public GameObject scoreText;
    public GameObject scoreContainer;

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

    void Update()
    {
        if(GameManager.instance.GetGameState() == "Win" || GameManager.instance.GetGameState() == "PlayerDeath")
        {
            GameObject temp;
            temp = Instantiate(scoreContainer);
            temp.GetComponent<ScoreContainerScript>().SetScore(totalScore);

            if(GameManager.instance.GetGameState() == "Win")
            {
                temp.GetComponent<ScoreContainerScript>().SetWinOrLose(true);
            }
            else
            {
                temp.GetComponent<ScoreContainerScript>().SetWinOrLose(false);
            }

            SceneManager.MoveGameObjectToScene(temp, ApplicationManagerScript.instance.managementScene);
        }
    }

    public void IncreaseScoreBy(int increaseBy, Transform scorePoint)
    {
        totalScore = increaseBy + totalScore;

        GameObject temp = Instantiate(scoreText);

        temp.GetComponent<ScoreTextScript>().SetTextDisplayed(increaseBy.ToString());

        temp.transform.position = scorePoint.transform.position;

        temp.GetComponent<ScoreTextScript>().SetToAnimate(true);

        GameObject.Find("ScoreReadout").GetComponent<Text>().text = totalScore.ToString();
    }
}
