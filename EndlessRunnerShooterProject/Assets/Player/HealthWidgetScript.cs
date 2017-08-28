using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthWidgetScript : MonoBehaviour {

    Color red;
    Color green;
    Color pink;
    List<GameObject> healthSegments;

	void Start ()
    {
        healthSegments = new List<GameObject>();
        red = new Color(255.0f, 0.0f, 0.0f);
        green = new Color(0.0f, 255.0f, 0.0f);
        pink = new Color(255.0f, 0.0f, 255.0f);

        for (int iter = 0; iter < gameObject.transform.childCount; iter++)
        {
            healthSegments.Add(gameObject.transform.GetChild(iter).gameObject);
        }

    }
	
	void Update ()
    {
        if(PlayerStatusScript.instance.health < 10 || PlayerStatusScript.instance.tempHealth > 0)
        {
            for(int iter = 0; healthSegments.Count > iter; iter++)
            {
                if (healthSegments.Count <= PlayerStatusScript.instance.tempHealth + iter)
                {
                    healthSegments[iter].GetComponent<Image>().color = pink;
                }
                else
                {
                    if (healthSegments.Count > PlayerStatusScript.instance.health + iter)
                    {
                        healthSegments[iter].GetComponent<Image>().color = red;
                    }
                    else
                    {
                        healthSegments[iter].GetComponent<Image>().color = green;
                    }
                }
            }
        }
        else
        {
            for (int iter = 0; healthSegments.Count > iter; iter++)
            {

                healthSegments[iter].GetComponent<Image>().color = green;

            }
        }	    
	}
}
