using UnityEngine;
using System.Collections;

namespace UI
{

    public class ResumeButtonScript : MonoBehaviour
    {

        void Trigger()
        {
            GameManager.instance.SetGameState("Playing");
        }
    }
}