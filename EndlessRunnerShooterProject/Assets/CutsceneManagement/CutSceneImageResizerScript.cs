using UnityEngine;
using System.Collections;

public class CutSceneImageResizerScript : MonoBehaviour {

    GameObject canvas;

    float width;
    float height;

	void Awake ()
    {
        canvas = transform.parent.gameObject;

        width = canvas.GetComponent<RectTransform>().rect.width;
        height = canvas.GetComponent<RectTransform>().rect.height;

        GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
	}
	
}
