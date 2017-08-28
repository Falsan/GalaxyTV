using UnityEngine;
using System.Collections;

namespace UI
{

    public class LoadoutSecondaryRightButtonScript : MonoBehaviour
    {

        void SecondaryRightButton()
        {
            GameObject.Find("SecondaryImage").GetComponent<LoadoutImageScript>().MoveUpList();
        }
    }

}