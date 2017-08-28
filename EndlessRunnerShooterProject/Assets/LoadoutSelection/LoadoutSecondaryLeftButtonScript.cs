using UnityEngine;
using System.Collections;

namespace UI
{

    public class LoadoutSecondaryLeftButtonScript : MonoBehaviour
    {

        void SecondaryLeftButton()
        {
            GameObject.Find("SecondaryImage").GetComponent<LoadoutImageScript>().MoveDownList();
        }
    }

}
