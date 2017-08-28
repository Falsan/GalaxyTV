using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShakeAnnouncementScript : MonoBehaviour {

    string stage;
    bool positive;
    int shakeCounter;

    Coroutine changeCoroutine;

	void Start ()
    {
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        stage = "grow";
        positive = false;
        shakeCounter = 0;
        changeCoroutine = null;
	}
	

	void Update ()
    {
        if (stage == "grow")
        {
            transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);

            if (transform.localScale.x >= 1)
            {
                stage = "shake";
            }
        }
        else if (stage == "shake")
        {
            Vector3 rotation;

            if (changeCoroutine == null)
            {
                changeCoroutine = StartCoroutine(Shake());
            }

            if (positive)
            {
                rotation = new Vector3(0.0f, 0.0f, 1.0f);
                transform.Rotate(rotation);
            }
            else if (!positive)
            {
                rotation = new Vector3(0.0f, 0.0f, -1.0f);
                transform.Rotate(rotation);
            }

            if (shakeCounter == 4)
            {
                stage = "shrink";
            }
        }
        else if (stage == "shrink")
        {
            transform.localScale = transform.localScale - new Vector3(0.1f, 0.1f, 0.1f);

            if (transform.localScale.x <= 0)
            {
                stage = "destroy";
            }
        }
        else if (stage == "destroy")
        {
            Destroy(gameObject);
        }

    }

    IEnumerator Shake()
    {
        float wait = 1.0f;

        if(shakeCounter == 0)
        {
            wait = 0.5f;
        }
        else if(shakeCounter == 3)
        {
            wait = 0.5f;
        }


        yield return new WaitForSeconds(wait);

        if(positive)
        {
            positive = false;
        }
        else if(!positive)
        {
            positive = true;
        }

        shakeCounter++;
        changeCoroutine = null;
    }
}
