using UnityEngine;
using System.Collections;

namespace UI
{
    public class LoadoutPrimaryRightButtonScript : MonoBehaviour
    {

        void PrimaryRightButton()
        {
            GameObject.Find("PrimaryImage").GetComponent<LoadoutImageScript>().MoveUpList();
        }
    }
}
