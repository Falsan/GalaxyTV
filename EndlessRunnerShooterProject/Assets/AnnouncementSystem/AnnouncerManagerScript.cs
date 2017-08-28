using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnnouncerManagerScript : MonoBehaviour {

    public static AnnouncerManagerScript instance;

    public GameObject messagePrefab;

    Sprite bossFight;

    List<Sprite> sprites;

    // Use this for initialization
    void Start ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {

            Destroy(gameObject);
        }
        sprites = new List<Sprite>();

        Object[] temp = Resources.LoadAll("Announcements");
        List<GameObject> otherTemp = new List<GameObject>();

        for (int iter = 0; temp.Length > iter; iter++)
        {
            otherTemp.Add(temp[iter] as GameObject);
            sprites.Add(otherTemp[iter].GetComponent<SpriteRenderer>().sprite);
        }

    }
	
	public void AnnounceMessage(string image, string effect = "shake", string audioAnnouncement = null)
    {
        GameObject temp = Instantiate(messagePrefab);

        for (int iter = 0; iter < sprites.Count; iter++)
        {
            if(sprites[iter].name == image)
            {
                temp.GetComponent<Image>().sprite = sprites[iter];
            }
        }
        
        temp.GetComponent<AnnouncementScript>().SetEffect(effect);
        temp.GetComponent<AnnouncementScript>().SpawnEffectScript();

        if(audioAnnouncement != null)
        {
            AudioManagerScript.instance.CreateNewSound(audioAnnouncement);
        }


    }
}
