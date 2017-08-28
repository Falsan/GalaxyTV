using UnityEngine;
using System.Collections;

namespace UI
{

    public class LoadoutDefenceRightButtonScript : MonoBehaviour
    {

        void DefenceRightButton()
        {
            GameObject.Find("DefenceImage").GetComponent<LoadoutImageScript>().MoveUpList();
        }
    }

}