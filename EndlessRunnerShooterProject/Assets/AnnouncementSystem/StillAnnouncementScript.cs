using UnityEngine;
using System.Collections;

public class StillAnnouncementScript : MonoBehaviour {

    string stage;
    bool change;

    Coroutine changeCoroutine;

    void Start()
    {
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        stage = "grow";
        change = false;
        changeCoroutine = null;
    }


    void Update()
    {
        if (stage == "grow")
        {
            transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);

            if (transform.localScale.x >= 1)
            {
                stage = "still";
            }
        }
        else if (stage == "still")
        {
            if (changeCoroutine == null)
            {
                changeCoroutine = StartCoroutine(Still());
            }

            if (change == true)
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

    IEnumerator Still()
    {
        yield return new WaitForSeconds(2.0f);
        change = true;
    }
}
