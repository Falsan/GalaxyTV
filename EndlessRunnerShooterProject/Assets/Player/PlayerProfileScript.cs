using UnityEngine;
using System.Collections;
using System.IO;

public class PlayerProfileScript : MonoBehaviour {

    public static PlayerProfileScript instance;
    StreamReader profile;
    StreamWriter profileToWrite;

    string path;

    string profileState;

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

        path = Application.dataPath + "/Resources/Profile.txt";

        ReadProfile();
    }
	
    void ReadProfile()
    {
        profile = new StreamReader(path);

        profileState = profile.ReadLine();

        profile.Close();

        profile = null;
    }

    public void ChangeProfileState(string toWrite)
    {
        profileToWrite = new StreamWriter(path);

        profileToWrite.WriteLine(toWrite);

        profileToWrite.Close();

        profileToWrite = null;

        ReadProfile();
    }

    public string GetProfileState()
    {
        return profileState;
    }
}
