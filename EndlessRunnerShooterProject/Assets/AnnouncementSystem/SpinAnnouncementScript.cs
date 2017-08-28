using UnityEngine;
using System.Collections;

public class SpinAnnouncementScript : MonoBehaviour {

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
                stage = "spin";
            }
        }
        else if (stage == "spin")
        {
            if (changeCoroutine == null)
            {
                changeCoroutine = StartCoroutine(Spin());
            }

            Vector3 rotation;
            
            rotation = new Vector3(0.0f, 0.0f, 2.0f);
            transform.Rotate(rotation);

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

    IEnumerator Spin()
    {
        yield return new WaitForSeconds(2.95f);
        change = true;
    }

}
