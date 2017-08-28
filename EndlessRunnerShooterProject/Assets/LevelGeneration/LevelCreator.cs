using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {

    public static LevelCreator instance;

    public GameObject mainCamera;
    public GameObject spawner;
    public GameObject gameSpawner;
    public GameObject sides;
    public GameObject scoreManager;
    public GameObject gameUI;

    public GameObject background1;
    public GameObject level1Logic;

    public GameObject background2;
    public GameObject level2Logic;

    public GameObject debrisGenerator;

    string level = null;

    bool isLevelLoaded;

    // Use this for initialization
    void Start () {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        { 
           
            Destroy(gameObject);
        }

        level = "null";
        isLevelLoaded = false;
    }
	
	// Update is called once per frame
	void Update () {
	
        //THESE ARE DEBUG COMMANDS TO GENERATE THE LEVELS
        if(level == "Level1" && !isLevelLoaded)
        {
            isLevelLoaded = true;
            GenerateLevelOne();
        }
        else if (level == "Level2" && !isLevelLoaded)
        {
            isLevelLoaded = true;
            GenerateLevelTwo();
        }
    }

    void CreateCamera()
    {

        GameObject temp = Instantiate(mainCamera);

        temp.transform.position = new Vector3(0.0f, 1.0f, -23.06f);
    }

    void CreateScoreManager()
    {
        Instantiate(scoreManager);
    }

    void CreateDebrisGenerator()
    {
        Instantiate(debrisGenerator);
    }

    void CreateGameUI()
    {
        Instantiate(gameUI);
    }

    void CreateSpawner()
    {
        gameSpawner = Instantiate(spawner);
        StartCoroutine(SetspawnerLevel());
    }

    void CreateLevelLogic()
    {
        if(level == "Level1")
        {
            Instantiate(level1Logic);
        }
        else if(level == "Level2")
        {
            Instantiate(level2Logic);
        }
    }

    void CreateScreenSides()
    {
        Instantiate(sides);
    }

    void CreateBackGround()
    {
        GameObject background1Obj = Instantiate(background1);
        GameObject background2Obj = Instantiate(background2);
        background1Obj.transform.position = new Vector3(0, 96, 9);
        background2Obj.transform.position = new Vector3(0, -103, 8.9f);
    }

    void SetupBackgroundMusic()
    {
        if(level == "Level1")
        {
            AudioManagerScript.instance.CreateNewBackgroundMusic("Level1Music");
        }
        else if(level == "Level2")
        {
            AudioManagerScript.instance.CreateNewBackgroundMusic("Level2Music");
        }
    }

    void GenerateLevelOne()
    {
        CreateScoreManager();
        CreateGameUI();
        CreateLevelLogic();


        CreateSpawner();

        CreateBackGround();
        CreateScreenSides();

        SetupBackgroundMusic();

        CreateCamera();

        CreateDebrisGenerator();

        GameManager.instance.SetGameState("Play");
    }

    void GenerateLevelTwo()
    {
        CreateScoreManager();
        CreateGameUI();
        CreateLevelLogic();


        CreateSpawner();

        CreateBackGround();
        CreateScreenSides();

        SetupBackgroundMusic();

        CreateCamera();

        GameManager.instance.SetGameState("Play");
    }

    public string GetLevel()
    {
        return level;
    }

    public void SetLevel(string toSet)
    {
        level = toSet;
    }

    IEnumerator SetspawnerLevel()
    {
        yield return new WaitForSeconds(4);
        EnemySpawningScript.instance.SetLevel(level);
    }
}
