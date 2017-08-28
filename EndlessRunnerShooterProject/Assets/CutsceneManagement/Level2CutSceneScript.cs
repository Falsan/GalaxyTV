using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Level2CutSceneScript : MonoBehaviour
{

    string cutSceneStage;

    List<Sprite> panels;
    public Sprite black;

    public GameObject image;
    public GameObject text;
    GameObject canvas;

    Coroutine nextImageTimer;

    void Awake()
    {
        panels = new List<Sprite>();
        Object[] temp = Resources.LoadAll("CutScenePanels/Level1");
        List<GameObject> otherTemp = new List<GameObject>();

        for (int iter = 0; temp.Length > iter; iter++)
        {
            otherTemp.Add(temp[iter] as GameObject);
            panels.Add(otherTemp[iter].GetComponent<SpriteRenderer>().sprite);
        }

        /*for (int iter = 0; otherTemp.Count > iter; iter++)
        {
            panels.Add(otherTemp[iter].GetComponent<SpriteRenderer>().sprite);
        }*/

        cutSceneStage = "Begin";

        nextImageTimer = null;

        canvas = GameObject.Find("Canvas");
        image = GameObject.Find("Cutscene Image");
        text = GameObject.Find("Cutscene Text");
    }

    void Update()
    {
        if (nextImageTimer == null)
        {
            if (cutSceneStage == "Begin")
            {
                SetTextColour(Color.white);
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel1", "In 1990 everything was sort of alright"));
                cutSceneStage = "Panel2";
            }
            else if (cutSceneStage == "Panel2")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel2", "Earth was doing okay for itself"));
                cutSceneStage = "Panel3";
            }
            else if (cutSceneStage == "Panel3")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel3", "Then aliens invaded"));
                cutSceneStage = "Panel4";
            }
            else if (cutSceneStage == "Panel4")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel4", "This was later considered a bad move on their part"));
                cutSceneStage = "Panel5";
            }
            else if (cutSceneStage == "Panel5")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel5", "First they kind of thrashed us"));
                cutSceneStage = "Panel6";
            }
            else if (cutSceneStage == "Panel6")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel6", "Pretty badly in fact"));
                cutSceneStage = "Panel7";
            }
            else if (cutSceneStage == "Panel7")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel7", "But we're humanity, and we crushed them soon after the shock wore off"));
                cutSceneStage = "Panel8";
            }
            else if (cutSceneStage == "Panel8")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel8", "They had a galactic empire"));
                cutSceneStage = "Panel9";
            }
            else if (cutSceneStage == "Panel9")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel9", "A week later it was ours, we're just that awesome"));
                cutSceneStage = "Panel10";
            }
            else if (cutSceneStage == "Panel10")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel10", "After we'd conquered the entire galaxy, well..."));
                cutSceneStage = "Panel11";
            }
            else if (cutSceneStage == "Panel11")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel11", "Things got a little boring, we started watching TV"));
                cutSceneStage = "Panel12";
            }
            else if (cutSceneStage == "Panel12")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel12", "We came up with game shows where we pitted an average human against hordes of aliens"));
                cutSceneStage = "Panel13";
            }
            else if (cutSceneStage == "Panel13")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel13", "Let's face it, you kind of needed the cash"));
                cutSceneStage = "Panel14";
            }
            else if (cutSceneStage == "Panel14")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel14", "Some blokes offered you a tenner if you participated"));
                cutSceneStage = "Panel15";
            }
            else if (cutSceneStage == "Panel15")
            {
                nextImageTimer = StartCoroutine(NextImage(5.0f, "Level1Panel15", "So here you are. But don't worry, you're human, there's nothing that can stop you. Right?"));
                cutSceneStage = "Finish";
            }
            else if (cutSceneStage == "Finish")
            {
                ApplicationManagerScript.instance.SetCurrentApplicationState("LEVEL2PLAY");
                Destroy(gameObject);
            }
        }
        for (int iter = 0; iter < InputManagerScript.instance.GetKeysPressed().Count; iter++)
        {
            if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[8].GetKeyCode())
            {
                ApplicationManagerScript.instance.SetCurrentApplicationState("LEVEL2PLAY");
                Destroy(gameObject);
            }
        }
    }

    void FadeInImage(string nextSprite)
    {
        for (int iter = 0; panels.Count > iter; iter++)
        {
            if (panels[iter].name == nextSprite)
            {
                image.GetComponent<RectTransform>().sizeDelta = new Vector2(canvas.GetComponent<RectTransform>().sizeDelta.x, canvas.GetComponent<RectTransform>().sizeDelta.y);
                image.GetComponent<Image>().sprite = panels[iter];
                break;
            }
        }

    }

    void FadeInText(string newText)
    {
        text.GetComponent<Text>().text = newText;
    }

    void FadeOutText()
    {
        text.GetComponent<Text>().text = "";
    }

    void FadeOutImage()
    {
        image.GetComponent<Image>().sprite = black;
    }

    void SetTextColour(Color newColour)
    {
        text.GetComponent<Text>().color = newColour;
    }

    IEnumerator NextImage(float waitTime, string nextImage, string newText)
    {
        FadeInImage(nextImage);
        FadeInText(newText);

        yield return new WaitForSeconds(waitTime);

        nextImageTimer = null;
    }
}
