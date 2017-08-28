using UnityEngine;
using System.Collections;

public class ShowOptionsScript : MonoBehaviour {

    public GameObject audioOptions;
    public GameObject displayOptions;
    public GameObject gameOptions;
    public GameObject controlsOptions;

    GameObject currentOptions;

    public static ShowOptionsScript instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {

            Destroy(gameObject);
        }
    }

    void ResetOptionsPosition()
    {
        currentOptions.transform.parent = GameObject.Find("Canvas").transform;

        currentOptions.transform.localPosition = Vector3.zero;
    }

    public void ShowAudioOptions()
    {
        Destroy(currentOptions);
        currentOptions = Instantiate(audioOptions);

        ResetOptionsPosition();
    }
    public void ShowDisplayOptions()
    {
        Destroy(currentOptions);
        currentOptions = Instantiate(displayOptions);

        ResetOptionsPosition();
    }
    public void ShowControlOptions()
    {
        Destroy(currentOptions);
        currentOptions = Instantiate(controlsOptions);

        ResetOptionsPosition();
    }

}
