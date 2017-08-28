using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BossHealthWidgetScript : MonoBehaviour
{
    Color red;
    Color green;
    List<GameObject> healthSegments;

    int startHealth;

    void Start()
    {
        healthSegments = new List<GameObject>();
        red = new Color(255.0f, 0.0f, 0.0f);
        green = new Color(0.0f, 255.0f, 0.0f);

        for (int iter = 0; iter < gameObject.transform.childCount; iter++)
        {
            healthSegments.Add(gameObject.transform.GetChild(iter).gameObject);
            healthSegments[iter].GetComponent<Image>().color = green;
        }

        startHealth = Level1BossManagerScript.instance.GetTotalHealth();
    }

    void Update()
    {

            for (int iter = 0; healthSegments.Count > iter; iter++)
            {

                if (healthSegments.Count > Level1BossManagerScript.instance.GetTotalHealth() + iter)
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
