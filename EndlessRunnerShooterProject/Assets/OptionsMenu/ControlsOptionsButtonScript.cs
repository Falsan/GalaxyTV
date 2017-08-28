using UnityEngine;
using System.Collections;

namespace UI
{

    public class ControlsOptionsButtonScript : MonoBehaviour
    {

        void Trigger()
        {
            ShowOptionsScript.instance.ShowControlOptions();
        }
    }
}