using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UI
{

    public class Level2ButtonScript : MonoBehaviour
    {
        public GameObject levelToLoadObject;

        void Trigger()
        {
            AudioManagerScript.instance.CreateNewSound("MenuPressSound");
            GameObject temp = Instantiate(levelToLoadObject);
            temp.GetComponent<LevelToLoadObjectScript>().SetLevelToLoad("Level2");
            SceneManager.MoveGameObjectToScene(temp, ApplicationManagerScript.instance.managementScene);
            ApplicationManagerScript.instance.SetCurrentApplicationState("CUTSCENESCENE");
        }
    }
}