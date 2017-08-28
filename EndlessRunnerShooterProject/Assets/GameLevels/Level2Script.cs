using UnityEngine;
using System.Collections;

public class Level2Script : MonoBehaviour
{

    public string levelState;
    string previousLevelState;

    float waitTime;

    float waitingStarted;

    float timeAlreadyPassed;

    Coroutine waitingCoroutine;

    public static Level2Script instance;

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

    void Update()
    {
        if (GameManager.instance.GetGameState() != "Pause")
        {
            if (!pauseWait)
            {
                timeAlreadyPassed = 0;
            }
            else if (pauseWait)
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
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 1, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 8, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 12, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 17, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 20, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 29, false, null, 200.0f);
                    EnemySpawningScript.instance.CreateFighterAtPosition("KamakasiEnemy", 33, false, null, 200.0f);
                    waitTime = 5.0f;
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
                if (waitingCoroutine != null)
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