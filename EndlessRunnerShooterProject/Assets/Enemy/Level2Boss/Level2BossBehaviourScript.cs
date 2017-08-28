using UnityEngine;
using System.Collections;

public class Level2BossBehaviourScript : MonoBehaviour {

    bool isAlive;
    bool spawnMode;
    bool isAtCorner;

    bool behaviourInProgress;

    string thisBehaviour;
    string previousBehaviour;

    int totalHealth;

    public GameObject bossPositionGridPrefab;
    GameObject bossPositionGrid;

    public static Level2BossBehaviourScript instance;

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

        bossPositionGrid = Instantiate(bossPositionGridPrefab);
        bossPositionGrid.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

    }
	
	void LateUpdate ()
    {
	    if(spawnMode == false)
        {
            if(behaviourInProgress == false)
            {
                thisBehaviour = ChooseBehaviour();
            }
            else
            {
                if(thisBehaviour == "SpinShoot")
                {

                }
                else if(thisBehaviour == "CornerBarrage")
                {
                    CornerBarrageRoutine();
                }
                else if(thisBehaviour == "MidfieldBarrage")
                {

                }
                else if(thisBehaviour == "BombingRun")
                {

                }
            }
        }
	}

    void CornerBarrageRoutine()
    {
        
    }

    string ChooseBehaviour()
    {
        string behaviour = previousBehaviour;

        while (behaviour == previousBehaviour)
        {
            int random = Random.Range(1, 4);

            if(random == 1)
            {
                behaviour = "SpinShoot";
            }
            else if(random == 2)
            {
                behaviour = "CornerBarrage";
            }
            else if(random == 3)
            {
                behaviour = "MidfieldBarrage";
            }
            else if(random == 4)
            {
                behaviour = "BombingRun";
            }
        }

        behaviourInProgress = true;
        return behaviour;
    }
}
