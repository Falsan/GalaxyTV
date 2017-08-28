using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManagerScript : MonoBehaviour {

    public string currentApplicationState;
    string previousApplicationState;

    public GameObject loadingScreen;

    public static ApplicationManagerScript instance;

    public Scene managementScene;
    string currentLevelScene;

	void Start ()
    {
        managementScene = SceneManager.GetActiveScene();

        currentApplicationState = "APPLICATIONSTART";
        previousApplicationState = "null";

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	void LateUpdate ()
    {
        if (currentApplicationState != previousApplicationState)
        {
            //set up the loading screen
            SceneManager.UnloadScene(currentLevelScene);
            if (!GameObject.FindGameObjectWithTag("LoadingScreen"))
            {
                Instantiate(loadingScreen);
            }

            //find out what we need to load and start the load process
            if (currentApplicationState == "APPLICATIONSTART")
            {
                if (SceneManager.GetSceneByName("MainMenuScene").isLoaded != true)
                {

                    SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Additive);
                    Debug.Log("LoadMenuScene");
                    currentLevelScene = "MainMenuScene";
                    AudioManagerScript.instance.CreateNewBackgroundMusic("MenuMusic");
                    previousApplicationState = currentApplicationState;
                }
            }
            else if (currentApplicationState == "MAINMENU")
            {
                if (SceneManager.GetSceneByName("MainMenuScene").isLoaded != true)
                {

                    SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Additive);
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenuScene"));
                    Debug.Log("LoadMenuScene");
                    currentLevelScene = "MainMenuScene";
                    if (AudioManagerScript.instance.currentBackgroundMusic.GetComponent<AudioSource>().clip.name != "MenuMusic")
                    {
                        AudioManagerScript.instance.CreateNewBackgroundMusic("MenuMusic");
                    }
                    previousApplicationState = currentApplicationState;

                    if(LoadoutObjectScript.instance != null)
                    {
                        LoadoutObjectScript.instance.DestroyThisObject();
                    }
                }
            }
            else if (currentApplicationState == "LEVELLOADSCREEN")
            {
                if (SceneManager.GetSceneByName("LevelSelectionScene").isLoaded != true)
                {
                    SceneManager.LoadScene("LevelSelectionScene", LoadSceneMode.Additive);
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("LevelSelectionScene"));
                    Debug.Log("LoadLevelSelect");
                    currentLevelScene = "LevelSelectionScene";
                    if (AudioManagerScript.instance.currentBackgroundMusic.GetComponent<AudioSource>().clip.name != "MenuMusic")
                    {
                        AudioManagerScript.instance.CreateNewBackgroundMusic("MenuMusic");
                    }
                    previousApplicationState = currentApplicationState;
                }
            }
            else if (currentApplicationState == "LEVEL1PLAY")
            {
                if (SceneManager.GetSceneByName("Level1").isLoaded != true)
                {
                    SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
                    Debug.Log("LoadLevel1");
                    currentLevelScene = "Level1";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
            else if (currentApplicationState == "LEVEL2PLAY")
            {
                if (SceneManager.GetSceneByName("Level2").isLoaded != true)
                {
                    SceneManager.LoadScene("Level2", LoadSceneMode.Additive);
                    Debug.Log("LoadLevel2");
                    currentLevelScene = "Level2";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
            else if (currentApplicationState == "WINSCREEN")
            {
                if (SceneManager.GetSceneByName("WinScreen").isLoaded != true)
                {
                    SceneManager.LoadScene("WinScreen", LoadSceneMode.Additive);
                    Debug.Log("LoadWinScreen");
                    currentLevelScene = "WinScreen";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
            else if (currentApplicationState == "LOADOUTSCREEN")
            {
                if (SceneManager.GetSceneByName("LoadoutScene").isLoaded != true)
                {
                    SceneManager.LoadScene("LoadoutScene", LoadSceneMode.Additive);
                    Debug.Log("LoadoutScene");
                    currentLevelScene = "LoadoutScene";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
            else if (currentApplicationState == "CUTSCENESCENE")
            {
                if (SceneManager.GetSceneByName("Cutscene Scene").isLoaded != true)
                {
                    SceneManager.LoadScene("Cutscene Scene", LoadSceneMode.Additive);
                    Debug.Log("Cutscene Scene");
                    currentLevelScene = "Cutscene Scene";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
            else if (currentApplicationState == "OPTIONSSCENE")
            {
                if (SceneManager.GetSceneByName("OptionsScene").isLoaded != true)
                {
                    SceneManager.LoadScene("OptionsScene", LoadSceneMode.Additive);
                    Debug.Log("OptionsScene");
                    currentLevelScene = "OptionsScene";
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
                }
                previousApplicationState = currentApplicationState;

            }
        }
        else
        {
            if(GameObject.FindGameObjectWithTag("LoadingScreen"))
            {
                Destroy(GameObject.FindGameObjectWithTag("LoadingScreen"));
            }
            previousApplicationState = currentApplicationState;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelScene));
        }

        
    }

    public string GetCurrentApplicationState()
    {
        return currentApplicationState;
    }

    public void SetCurrentApplicationState(string toSet)
    {
        currentApplicationState = toSet;
    }
}
