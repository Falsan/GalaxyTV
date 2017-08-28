using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

namespace UI
{

    public class LoadoutToLevelSelectScreenScript : MonoBehaviour
    {
        public GameObject loadoutObject;
        GameObject canvas;
        List<GameObject> buttons;

        void LoadoutToLevelSelect()
        {
            canvas = GameObject.Find("Canvas");
            buttons = new List<GameObject>();

            for(int iter = 0; iter < canvas.transform.childCount; iter++)
            {
                buttons.Add(canvas.transform.GetChild(iter).gameObject);
            }

            DisableButtons();

            StartCoroutine(AnimationDelay());
        }

        void DisableButtons()
        {
            for(int iter = 0; iter < buttons.Count; iter++)
            {
                if (buttons[iter].GetComponent<Button>())
                {
                    buttons[iter].GetComponent<Button>().interactable = false;
                }
            }
        }

        IEnumerator AnimationDelay()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            GameObject temp = Instantiate(loadoutObject);
            SceneManager.MoveGameObjectToScene(temp, ApplicationManagerScript.instance.managementScene);
            PlayerModelTakeOffAnimScript.instance.TakeOffAnimation();
            yield return new WaitForSeconds(6);
            ApplicationManagerScript.instance.SetCurrentApplicationState("LEVELLOADSCREEN");
        }
    }
}