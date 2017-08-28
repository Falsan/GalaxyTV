using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManagerScript : MonoBehaviour {

    public static AudioManagerScript instance;

    public GameObject soundObjectPrefab;
    public GameObject musicObjectPrefab;

    Coroutine musicSwapCoroutine;

    public GameObject currentBackgroundMusic;

    List<AudioClip> backgroundMusics;
    List<AudioClip> sounds;

    AudioClip menuBackgroundMusic;
    AudioClip level1BackgroundMusic;

    AudioClip bossBaseHit;
    AudioClip bulletSound;
    AudioClip menuPressSound;
    AudioClip shipHit;
    AudioClip shotSound;
    AudioClip spawnSound;
    AudioClip thudGunShot;

    AudioClip machineGunInfo;
    AudioClip wingGunsInfo;
    AudioClip thudGunInfo;
    AudioClip schiltronGunInfo;
    AudioClip energyShieldInfo;
    AudioClip pointDefenceInfo;

    bool needToChange;
    string cachedSoundName;

	// Use this for initialization
	void Start ()
    {
        backgroundMusics = new List<AudioClip>();
        sounds = new List<AudioClip>();
        currentBackgroundMusic = null;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {

            Destroy(gameObject);
        }
        musicSwapCoroutine = null;
        needToChange = false;

        menuBackgroundMusic = (AudioClip)Resources.Load("MenuMusic");
        level1BackgroundMusic = (AudioClip)Resources.Load("Level1Music");
        bossBaseHit = (AudioClip)Resources.Load("BossBaseHit");
        bulletSound = (AudioClip)Resources.Load("BulletSound");
        menuPressSound = (AudioClip)Resources.Load("MenuPressSound");
        shipHit = (AudioClip)Resources.Load("ShipHit");
        shotSound = (AudioClip)Resources.Load("ShotSound");
        spawnSound = (AudioClip)Resources.Load("SpawnSound");
        thudGunShot = (AudioClip)Resources.Load("ThudGunShot");

        machineGunInfo = (AudioClip)Resources.Load("MachineGunInfo");
        wingGunsInfo = (AudioClip)Resources.Load("WingGunsInfo");
        schiltronGunInfo = (AudioClip)Resources.Load("SchiltronGunInfo");
        thudGunInfo = (AudioClip)Resources.Load("ThudGunInfo");
        energyShieldInfo = (AudioClip)Resources.Load("EnergyShieldInfo");
        pointDefenceInfo = (AudioClip)Resources.Load("PointDefenceInfo");

        backgroundMusics.Add(level1BackgroundMusic);
        backgroundMusics.Add(menuBackgroundMusic);

        sounds.Add(bossBaseHit);
        sounds.Add(bulletSound);
        sounds.Add(menuPressSound);
        sounds.Add(shipHit);
        sounds.Add(shotSound);
        sounds.Add(spawnSound);
        sounds.Add(thudGunShot);
        sounds.Add(wingGunsInfo);
        sounds.Add(machineGunInfo);
        sounds.Add(schiltronGunInfo);
        sounds.Add(thudGunInfo);
        sounds.Add(energyShieldInfo);
        sounds.Add(pointDefenceInfo);
    }

    void LateUpdate()
    {
        if(needToChange == true && musicSwapCoroutine == null)
        {
            musicSwapCoroutine = StartCoroutine(FadeOutThenIn(cachedSoundName));
            needToChange = false;
            cachedSoundName = null;
        }
        else
        {

        }
    }

    public void CreateNewSound(string soundName)
    {
        AudioClip clip = null;

        for (int iter = 0; sounds.Count > iter; iter++)
        {
            if (soundName == sounds[iter].name)
            {
                clip = sounds[iter];
            }
        }

        GameObject temp = Instantiate(soundObjectPrefab);
        temp.GetComponent<AudioSource>().volume = Options.GlobalOptionsSettingsScript.instance.GetFXVolume();
        temp.GetComponent<AudioSource>().clip = clip;
    }

    public void CreateNewBackgroundMusic(string musicName)
    {
        if(currentBackgroundMusic == null)
        {
            //the object hasn't been created, so create it
            currentBackgroundMusic = Instantiate(musicObjectPrefab);

            currentBackgroundMusic.GetComponent<AudioSource>().volume = 0;

            if (musicSwapCoroutine == null)
            {
                musicSwapCoroutine = StartCoroutine(FadeOutThenIn(musicName));
            }
            else
            {
                cachedSoundName = musicName;
                needToChange = true;
            }
        }
        else
        {
            if (musicSwapCoroutine == null)
            {
                musicSwapCoroutine = StartCoroutine(FadeOutThenIn(musicName));
            }
            else
            {
                cachedSoundName = musicName;
                needToChange = true;
            }

        }

    }

    public void ResetMusicVolume()
    {
        currentBackgroundMusic.GetComponent<AudioSource>().volume = Options.GlobalOptionsSettingsScript.instance.GetMusicVolume();
    }

    IEnumerator FadeOutThenIn(string musicName)
    {
        //first fade out the current music
        while (currentBackgroundMusic.GetComponent<AudioSource>().volume > 0)
        {
            currentBackgroundMusic.GetComponent<AudioSource>().volume = currentBackgroundMusic.GetComponent<AudioSource>().volume - 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        //select the new track

        for (int iter = 0; backgroundMusics.Count > iter; iter++)
        {
            if (musicName == backgroundMusics[iter].name)
            {
                currentBackgroundMusic.GetComponent<AudioSource>().clip = backgroundMusics[iter];
            }
        }


        //fade in the new music
        while (currentBackgroundMusic.GetComponent<AudioSource>().volume < Options.GlobalOptionsSettingsScript.instance.GetMusicVolume()) 
        {
            currentBackgroundMusic.GetComponent<AudioSource>().volume = currentBackgroundMusic.GetComponent<AudioSource>().volume + 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

        musicSwapCoroutine = null;
        yield return new WaitForSeconds(0.1f);
    }
}
