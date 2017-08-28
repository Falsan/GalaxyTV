using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{

    public class FinalScoreScript : MonoBehaviour
    {
        bool getScore = false;

        void Update()
        {
            if (getScore == false)
            {
                GetComponent<Text>().text = ScoreContainerScript.instance.GetScore().ToString();
                getScore = true;
            }
        }
    }

}