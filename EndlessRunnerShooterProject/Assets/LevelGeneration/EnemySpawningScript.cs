using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawningScript : MonoBehaviour {

    public static EnemySpawningScript instance;

    public GameObject Level1Boss;
    public GameObject Level2Boss;
    public GameObject KamkasiFighter;
    public GameObject LeftToRightFighter;
    public GameObject RightToLeftFighter;
    public GameObject StationaryGun;
    public GameObject SquarePathEnemy;
    public GameObject InvertedSquarePathEnemy;
    public GameObject HalfCircleEnemy;
    public GameObject LoopTheLoopEnemy;

    public GameObject basicBullet;
    public GameObject homingBullet;

    public List<GameObject> spawnPoints;

    GameObject currentLevelLogic;
    public GameObject Level1;

    public string spawnerState; //spawner states: INACTIVE, START, STARTED
    public string level;

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

        spawnPoints = new List<GameObject>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("SpawnPoint");

        for (int iter = 0; objects.Length > iter; iter++)
        {
            spawnPoints.Add(EnemySpawningScript.instance.gameObject.transform.GetChild(iter).gameObject);
        }

        level = LevelCreator.instance.GetLevel();
        currentLevelLogic = null;
        spawnerState = "START";
    }
	
	// Update is called once per frame
	void Update () {
	
        if(spawnerState == "START")
        {
            StartSpawns();
        }
	}

    void StartSpawns()
    {
        spawnerState = "STARTED";

        if (currentLevelLogic == null)
        {
            if (level == "Level1")
            {
                currentLevelLogic = Instantiate(Level1);
            }
        }
    }

    public void CreateFighterAtPosition(string type, int spawnPoint, bool canShoot, 
        string bulletType, float speed = 200.0f, float shootingDelay = 2.0f, float lengthToTurn = 0.0f,
        int scoreWorth = 100)
    {
        AudioManagerScript.instance.CreateNewSound("SpawnSound");
        ReturnSpawnPointForInt(spawnPoint).GetComponent<Light>().range = 5.0f;
        ReturnSpawnPointForInt(spawnPoint).GetComponent<Light>().intensity = 4.0f;
        GameObject newFighter = ReturnTypeForString(type);
        newFighter = Instantiate(newFighter);
        newFighter.transform.position = ReturnSpawnPointForInt(spawnPoint).transform.position;
        newFighter.GetComponent<BaseEnemyScript>().bullet = ReturnBulletTypeForString(bulletType);
        newFighter.GetComponent<BaseEnemyScript>().SetTimeToTurn(lengthToTurn);
        newFighter.GetComponent<BaseEnemyScript>().SetCanShoot(canShoot);
        newFighter.GetComponent<BaseEnemyScript>().SetShootingDelay(shootingDelay);
        newFighter.GetComponent<BaseEnemyScript>().SetSpeed(speed);
        newFighter.GetComponent<BaseEnemyScript>().SetScoreWorth(scoreWorth);
    }

    GameObject ReturnTypeForString(string type)
    {
        if(type == "LoopEnemy")
        {
            return LoopTheLoopEnemy;
        }
        else if(type == "SquareEnemy")
        {
            return SquarePathEnemy;
        }
        else if (type == "InvertedSquareEnemy")
        {
            return InvertedSquarePathEnemy;
        }
        else if (type == "StationaryGunEnemy")
        {
            return StationaryGun;
        }
        else if (type == "HalfCircleEnemy")
        {
            return HalfCircleEnemy;
        }
        else if (type == "KamakasiEnemy")
        {
            return KamkasiFighter;
        }
        else if (type == "Level1Boss")
        {
            return Level1Boss;
        }
        else if(type == "Level2Boss")
        {
            return Level2Boss;
        }
        else if (type == "LeftToRightEnemy")
        {
            return LeftToRightFighter;
        }
        else if (type == "RightToLeftEnemy")
        {
            return RightToLeftFighter;
        }
        else
        {
            Debug.Log("Error in Spawn selection");
            return null;
        }
    }

    GameObject ReturnSpawnPointForInt(int integer)
    {
        return spawnPoints[integer];
    }

    public GameObject ReturnBulletTypeForString(string type)
    {
        if(type == "Bullet")
        {
            return basicBullet;
        }
        else if(type == "HomingBullet")
        {
            return homingBullet;
        }
        else if(type == null)
        {
            return null;
        }
        else
        {
            Debug.Log("Error in Bullet selection");
            return null;
        }
    }

    public void CreateBossAtPosition(string type, int spawnPoint)
    {
        GameObject newFighter = ReturnTypeForString(type);
        Instantiate(newFighter).transform.position = ReturnSpawnPointForInt(spawnPoint).transform.position;
    }

    public IEnumerator CreateSquadronAtPosition(string type, int spawnPoint, bool canShoot,
        string bulletType, int numberOfFighters, float speed = 400.0f, float shootingDelay = 2.0f, float lengthToTurn = 0.0f
        , int scoreWorth = 100)
    {
        if (GameManager.instance.GetGameState() == "Pause")
        {

        }
        else
        {
            for (int iter = 0; iter < numberOfFighters; iter++)
            {
                if (GameManager.instance.GetGameState() == "Pause")
                {
                    yield return new WaitForSeconds(0.5f);
                }
                else
                {
                    yield return new WaitForSeconds(0.5f);
                    if (GameManager.instance.GetGameState() == "Pause")
                    {
                        yield return new WaitForSeconds(0.5f);
                    }
                    else
                    {
                        CreateFighterAtPosition(type, spawnPoint, canShoot, bulletType, speed, shootingDelay, scoreWorth);
                    }
                }
            }
        }

    }

    public void SetLevel(string levelToSet)
    {
        level = levelToSet;
    }
}
