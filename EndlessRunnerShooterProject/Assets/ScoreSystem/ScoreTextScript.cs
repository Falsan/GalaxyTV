using UnityEngine;
using System.Collections;

public class ScoreTextScript : MonoBehaviour {

    string textDisplayed;
    bool animate = false;
    string moveOrFade;

    Coroutine moveCoroutine;

    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        moveOrFade = "move";
        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        moveCoroutine = null;

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(animate)
        {
            if (moveOrFade == "move")
            {
                rb.AddForce(0.0f, 40.0f, 0.0f);
                if(moveCoroutine == null)
                {
                    moveCoroutine = StartCoroutine(Switcher());
                }
            }
            else if(moveOrFade == "fade")
            {
                GetComponent<TextMesh>().fontSize = GetComponent<TextMesh>().fontSize - 1;

                if (GetComponent<TextMesh>().fontSize <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    void UpdateText()
    {
        GetComponent<TextMesh>().text = textDisplayed;
    }

    public string GetTextDisplayed()
    {
        return textDisplayed;
    }

    public void SetTextDisplayed(string toSet)
    {
        textDisplayed = toSet;
        UpdateText();
    }

    public void SetToAnimate(bool toSet)
    {
        animate = toSet;
    }

    IEnumerator Switcher()
    {
        yield return new WaitForSeconds(2.0f);
        moveOrFade = "fade";
        moveCoroutine = null;
    }
}
