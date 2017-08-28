using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {

    Rigidbody rb;

    string primaryWeapon;
    string secondaryWeapon;
    string defence;

    bool controlsEnabled;

	// Use this for initialization
	void Start ()
    {

        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;

        primaryWeapon = LoadoutObjectScript.instance.GetPrimaryGun();
        secondaryWeapon = LoadoutObjectScript.instance.GetSecondaryGun();
        defence = LoadoutObjectScript.instance.GetDefence();

        LoadoutObjectScript.instance.DestroyThisObject();

        SetUpWeapons();

        controlsEnabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.instance.GetGameState() != "Pause")
        {
            if (controlsEnabled)
            {
                Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);

                for (int iter = 0; iter < InputManagerScript.instance.GetKeysPressed().Count; iter++)
                {
                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[1].GetKeyCode())
                    {
                        velocity = velocity + new Vector3(0.0f, 400.0f, 0.0f);
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[2].GetKeyCode())
                    {
                        velocity = velocity + new Vector3(-400.0f, 0.0f, 0.0f);
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[3].GetKeyCode())
                    {
                        velocity = velocity + new Vector3(400.0f, 0.0f, 0.0f);
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[4].GetKeyCode())
                    {
                        velocity = velocity + new Vector3(0.0f, -400.0f, 0.0f);
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[0].GetKeyCode())
                    {
                        FirePrimaryWeapon();
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[5].GetKeyCode())
                    {
                        FireSecondaryWeapon();
                    }

                    if (InputManagerScript.instance.GetKeysPressed()[iter].GetKeyCode() == InputManagerScript.instance.allCommands[6].GetKeyCode())
                    {
                        ActivateDefence();
                    }
                }

                InputManagerScript.instance.ClearKeysPressed();

                rb.AddForce(velocity);
            }
        }
    }

    void FirePrimaryWeapon()
    {
        if (primaryWeapon == "machinegun")
        {
            GetComponent<PlayerMachineGunScript>().Fire();
        }
        else if (primaryWeapon == "wingguns")
        {
            GetComponent<PlayerWingGunsScript>().Fire();
        }
    }

    void FireSecondaryWeapon()
    {
        if (secondaryWeapon == "fistgun")
        {
            GetComponent<PlayerFistGunScript>().Fire();
        }
        else if(secondaryWeapon == "schiltron")
        {
            GetComponent<PlayerScilthromeGunScript>().Fire();
        }
    }

    void ActivateDefence()
    {
        if (defence == "energyshield")
        {
            GetComponent<PlayerEnergyShieldScript>().Fire();
        }
        else if (defence == "pointdefence")
        {
            gameObject.transform.FindChild("PointDefenceCollider").gameObject.GetComponent<PlayerPointDefenceScript>().Fire();
        }
    }

    void SetUpWeapons()
    {
        if(primaryWeapon == "machinegun")
        {
            gameObject.AddComponent<PlayerMachineGunScript>();
            gameObject.GetComponent<PlayerMachineGunScript>().SetBullet((GameObject)Resources.Load("PlayerMachineGunBullet"));
        }
        else if (primaryWeapon == "wingguns")
        {
            gameObject.AddComponent<PlayerWingGunsScript>();
            gameObject.GetComponent<PlayerWingGunsScript>().SetBullet((GameObject)Resources.Load("PlayerMachineGunBullet"));
        }

        if (secondaryWeapon == "fistgun")
        {
            gameObject.AddComponent<PlayerFistGunScript>();
            gameObject.GetComponent<PlayerFistGunScript>().fistGunBulletPrefab = ((GameObject)Resources.Load("PlayerFistBullet"));
        }
        else if(secondaryWeapon == "schiltron")
        {
            gameObject.AddComponent<PlayerScilthromeGunScript>();
            gameObject.GetComponent<PlayerScilthromeGunScript>().SetBullet((GameObject)Resources.Load("PlayerMachineGunBullet"));
        }

        if(defence == "energyshield")
        {
            gameObject.AddComponent<PlayerEnergyShieldScript>();
        }
        else if(defence == "pointdefence")
        {
            gameObject.transform.FindChild("PointDefenceCollider").gameObject.AddComponent<PlayerPointDefenceScript>();
            gameObject.transform.FindChild("PointDefenceCollider").gameObject.GetComponent<PlayerPointDefenceScript>()
                .SetBullet((GameObject)Resources.Load("PlayerPointDefenceBullet"));
        }
    }

    public void SetControls(bool toSet)
    {
        controlsEnabled = toSet;
    }

    public string GetPrimaryWeapon()
    {
        return primaryWeapon;
    }

    public string GetSecondaryWeapon()
    {
        return secondaryWeapon;
    }

    public string GetDefence()
    {
        return defence;
    }
}
