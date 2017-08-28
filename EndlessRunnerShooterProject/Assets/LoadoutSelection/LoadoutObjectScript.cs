using UnityEngine;
using System.Collections;

public class LoadoutObjectScript : MonoBehaviour {

    public static LoadoutObjectScript instance;

    string primaryGun;
    string secondaryGun;
    string defence;

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

        primaryGun = GameObject.Find("PrimaryImage").GetComponent<UI.LoadoutImageScript>().GetSelectedGun();
        secondaryGun = GameObject.Find("SecondaryImage").GetComponent<UI.LoadoutImageScript>().GetSelectedGun();
        defence = GameObject.Find("DefenceImage").GetComponent<UI.LoadoutImageScript>().GetSelectedGun();
    }
	
	public string GetPrimaryGun ()
    {
        return primaryGun;
	}

    public string GetSecondaryGun()
    {
        return secondaryGun;
    }

    public string GetDefence()
    {
        return defence;
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
