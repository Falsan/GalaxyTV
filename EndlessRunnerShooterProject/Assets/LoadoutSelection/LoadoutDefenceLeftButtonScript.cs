using UnityEngine;
using System.Collections;

namespace UI
{

    public class LoadoutDefenceLeftButtonScript : MonoBehaviour
    {

        void DefenceLeftButton()
        {
            GameObject.Find("DefenceImage").GetComponent<LoadoutImageScript>().MoveDownList();
        }
    }

}