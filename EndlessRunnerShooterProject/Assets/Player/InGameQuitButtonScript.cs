using UnityEngine;
using System.Collections;

namespace UI
{

    public class InGameQuitButtonScript : MonoBehaviour
    {

        void Trigger()
        {
            GameManager.instance.SetGameState("PlayerDeath");
        }
    }
}