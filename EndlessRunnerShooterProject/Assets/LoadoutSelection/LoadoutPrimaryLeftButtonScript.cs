using UnityEngine;
using System.Collections;

namespace UI
{
    public class LoadoutPrimaryLeftButtonScript : MonoBehaviour {

        void PrimaryLeftButton()
        {
            GameObject.Find("PrimaryImage").GetComponent<LoadoutImageScript>().MoveDownList();
        }
    }
}