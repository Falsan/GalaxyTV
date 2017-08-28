using UnityEngine;
using System.Collections;

namespace UI
{
    public class ReturnToLevelSelectButtonScript : MonoBehaviour
    {

        void ReturnToLevelSelect()
        {
            ApplicationManagerScript.instance.SetCurrentApplicationState("LOADOUTSCREEN");
        }
    }
}