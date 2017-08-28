using UnityEngine;
using System.Collections;

public class Level1Script : MonoBehaviour {

    public string levelState;
    string previousLevelState;

    float waitTime;

    float waitingStarted;

    float timeAlreadyPassed;

    Coroutine waitingCoroutine;

    public static Level1Script instance;

    bool stopSpawns;

    bool pauseWait;

    bool stopOperationsDone;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        levelState = "null";

        waitTime = 0.0f;
        stopSpawns = false;
        pauseWait = false;
        stopOperationsDone = false;
    }

    public void SetLevelState(string toSet)
    {
        levelState = toSet;
    }

	void Update ()
    {
        if (GameManager.instance.GetGameState() != "Pause")
        {
            if(!pauseWait)
            {
                timeAlreadyPassed = 0;
            }
            else if(pauseWait)
            {
                waitingCoroutine = StartCoroutine(Wait());
            }

            if (waitingCoroutine == null && !stopSpawns)
            {
                if (levelState == "BeginLevel")
                {
                    waitTime = 4.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave1";
                }
                else if (levelState == "Wave1")
                {
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 5, false, null, 200.0f);
                    waitTime = 2.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave2";
                }
                else if (levelState == "Wave2")
                {
                    StartCoroutine(EnemySpawningScript.instance.CreateSquadronAtPosition("RightToLeftEnemy", 29, true, "Bullet", 8, 500.0f, 1));

                    waitTime = 6.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave3";
                }
                else if (levelState == "Wave3")
                {
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("RightToLeftEnemy", 28, true, "Bullet", 5, 300.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("InvertedSquareEnemy", 12, true, "Bullet", 6, 300.0f));

                    waitTime = 12.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave4";
                }
                else if (levelState == "Wave4")
                {
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("SquareEnemy", 4, true, "Bullet", 2, 300.0f));


                    waitTime = 8.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave5";
                }
                else if (levelState == "Wave5")
                {
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 1, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 8, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 12, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 17, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 20, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 29, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 33, false, null, 200.0f);

                    waitTime = 6.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave6";
                }
                else if (levelState == "Wave6")
                {
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("SquareEnemy", 1, true, "Bullet", 5, 400.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("InvertedSquareEnemy", 14, true, "Bullet", 5, 400.0f));
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 2, false, null, 200.0f);


                    waitTime = 12.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave7";
                }
                else if (levelState == "Wave7")
                {
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LeftToRightEnemy", 17, true, "Bullet", 3, 400.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LeftToRightEnemy", 20, true, "Bullet", 3, 400.0f));
                    EnemySpawningScript.instance.CreateFighterAtPosition("StationaryGunEnemy", 12, true, "HomingBullet", 400.0f);


                    waitTime = 8.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave8";
                }
                else if (levelState == "Wave8")
                {
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LeftToRightEnemy", 22, true, "Bullet", 5, 200.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LeftToRightEnemy", 24, false, null, 5, 200.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LeftToRightEnemy", 26, true, "Bullet", 5, 200.0f));

                    waitTime = 10.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave9";
                }
                else if (levelState == "Wave9")
                {
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("RightToLeftEnemy", 28, true, "Bullet", 5, 200.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("RightToLeftEnemy", 30, false, null, 5, 200.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("RightToLeftEnemy", 32, true, "Bullet", 5, 200.0f));

                    waitTime = 10.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave10";
                }
                else if (levelState == "Wave10")
                {
                    EnemySpawningScript.instance.CreateFighterAtPosition("StationaryGunEnemy", 12, true, "HomingBullet");
                    EnemySpawningScript.instance.CreateFighterAtPosition("StationaryGunEnemy", 2, true, "HomingBullet");
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("SquareEnemy", 14, true, "Bullet", 2, 400.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LeftToRightEnemy", 22, false, null, 4, 500.0f));

                    waitTime = 7.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave11";
                }
                else if (levelState == "Wave11")
                {
                    EnemySpawningScript.instance.CreateFighterAtPosition("StationaryGunEnemy", 12, true, "HomingBullet");
                    EnemySpawningScript.instance.CreateFighterAtPosition("StationaryGunEnemy", 2, true, "HomingBullet");
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("SquareEnemy", 8, true, "Bullet", 5, 400.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LeftToRightEnemy", 20, false, null, 5, 400.0f));

                    waitTime = 7.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave12";
                }
                else if (levelState == "Wave11")
                {

                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LoopEnemy", 7, false, null, 5, 600.0f));

                    waitTime = 4.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave12";
                }
                else if (levelState == "Wave12")
                {

                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LoopEnemy", 6, false, null, 5, 600.0f));

                    waitTime = 4.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave13";
                }
                else if (levelState == "Wave13")
                {

                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LoopEnemy", 6, true, "Bullet", 5, 200.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("LeftToRightEnemy", 21, false, null, 2, 600.0f));

                    waitTime = 10.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave14";
                }
                else if (levelState == "Wave14")
                {

                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("RightToLeftEnemy", 30, true, "HomingBullet", 5, 200.0f));


                    waitTime = 2.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave15";
                }
                else if (levelState == "Wave15")
                {

                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("SquareEnemy", 3, true, "Bullet", 4, 400.0f));
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 12, false, null, 200.0f);

                    EnemySpawningScript.instance.CreateFighterAtPosition("StationaryGunEnemy", 2, true, "HomingBullet");

                    waitTime = 8.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "Wave16";
                }
                else if (levelState == "Wave16")
                {

                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("SquareEnemy", 0, false, null, 5, 500.0f));
                    StartCoroutine(EnemySpawningScript.instance.
                        CreateSquadronAtPosition("InvertedSquareEnemy", 14, true, "Bullet", 5, 500.0f));


                    waitTime = 8.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "BossWave";
                }
                else if (levelState == "BossWave")
                {
                    AnnouncerManagerScript.instance.AnnounceMessage("BossFightText");
                    EnemySpawningScript.instance.CreateBossAtPosition("Level1Boss", 39);

                    stopSpawns = true;
                    waitTime = 8.0f;
                    waitingCoroutine = StartCoroutine(Wait());
                    levelState = "BossWave";
                }

            }
            else
            {

            }

            pauseWait = false;
            stopOperationsDone = false;
        }
        else
        {
            if (stopOperationsDone == false)
            {
                float timeStopped = Time.time;

                StopCoroutine(Wait());
                if(waitingCoroutine != null)
                {
                     StopCoroutine(waitingCoroutine);
                }
                waitingCoroutine = null;
                timeAlreadyPassed = timeStopped - waitingStarted;
                pauseWait = true;
                stopOperationsDone = true;
                Debug.Log("Wait time equals:");
                Debug.Log(waitTime);
                Debug.Log("TimeAlreadyPassed equals:");
                Debug.Log(timeAlreadyPassed);
            }
        }
	}

    IEnumerator Wait()
    {
        waitingStarted = Time.time;
        waitTime = waitTime - timeAlreadyPassed;
        yield return new WaitForSeconds(waitTime);

        waitingCoroutine = null;
    }

}
