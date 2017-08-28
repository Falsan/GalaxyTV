using UnityEngine;
using System.Collections;

public class RumbleAnnouncementScript : MonoBehaviour {

    string stage;
    bool change;
    int rumbleStage;
    Coroutine changeCoroutine;

    void Start()
    {
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        stage = "grow";
        change = false;
        changeCoroutine = null;
        rumbleStage = 0;
    }


    void Update()
    {
        if (stage == "grow")
        {
            transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);

            if (transform.localScale.x >= 1)
            {
                stage = "rumble";
            }
        }
        else if (stage == "rumble")
        {
            if (changeCoroutine == null)
            {
                changeCoroutine = StartCoroutine(Rumble());
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

    IEnumerator Rumble()
    {
        transform.Translate(0.0f, 1.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, -2.0f, 0.0f);
        yield return new WaitForSeconds(0.08f);
        transform.Translate(0.0f, 2.0f, 0.00f);

        change = true;
    }
}
