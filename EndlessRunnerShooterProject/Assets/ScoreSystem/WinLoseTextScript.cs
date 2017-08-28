using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{
    public class WinLoseTextScript : MonoBehaviour
    {
        bool winUpdate = false;

        void Update()
        {
            if (winUpdate == false)
            {
                if (ScoreContainerScript.instance.GetWinOrLose())
                {
                    GetComponent<Text>().text = "You Win";
                }
                else
                {
                    GetComponent<Text>().text = "You Lose";
                }

                winUpdate = true;
            }
        }
    }
}