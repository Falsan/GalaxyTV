using UnityEngine;
using System.Collections;

public class ActivatePauseMenuScript : MonoBehaviour
{

    GameObject pauseMenu;

	// Use this for initialization
	void Start ()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
	    if(GameManager.instance.GetGameState() == "Pause")
        {
            if (pauseMenu.activeInHierarchy != true)
            {
                pauseMenu.SetActive(true);
            }
        }
        else
        {
            if (pauseMenu.activeInHierarchy == true)
            {
                pauseMenu.SetActive(false);
            }
        }
	}
}
