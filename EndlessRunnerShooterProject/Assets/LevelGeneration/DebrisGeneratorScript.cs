using UnityEngine;
using System.Collections;

public class DebrisGeneratorScript : MonoBehaviour {

    public GameObject planet1;
    public GameObject planet2;
    public GameObject planet3;
    public GameObject planet4;
    public GameObject planet5;
    public GameObject planet6;
    public GameObject nebula1;
    public GameObject nebula2;
    public GameObject nebula3;
    public GameObject asteroid;

    bool spawnSomething = true;

    Coroutine counter;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    if(spawnSomething == true)
        {
            int spawnPoint = Random.Range(0, 14);
            int thingToSpawn = Random.Range(1, 10);

            GameObject spawnedObject;

            if(thingToSpawn == 1)
            {
                spawnedObject = Instantiate(planet1);
            }
            else if(thingToSpawn == 2)
            {
                spawnedObject = Instantiate(nebula1);
            }
            else if(thingToSpawn == 3)
            {
                spawnedObject = Instantiate(nebula2);
            }
            else if (thingToSpawn == 4)
            {
                spawnedObject = Instantiate(nebula3);
            }
            else if (thingToSpawn == 5)
            {
                spawnedObject = Instantiate(planet2);
            }
            else if (thingToSpawn == 6)
            {
                spawnedObject = Instantiate(planet3);
            }
            else if (thingToSpawn == 7)
            {
                spawnedObject = Instantiate(planet4);
            }
            else if (thingToSpawn == 8)
            {
                spawnedObject = Instantiate(planet5);
            }
            else if (thingToSpawn == 9)
            {
                spawnedObject = Instantiate(planet6);
            }
            else if (thingToSpawn == 10)
            {
                spawnedObject = Instantiate(asteroid);
            }
            else
            {
                spawnedObject = null;
            }

            spawnedObject.transform.position = LevelCreator.instance.gameSpawner.GetComponent<EnemySpawningScript>().spawnPoints[spawnPoint].transform.position;
            spawnSomething = false;

            if(counter == null)
            {
                counter = StartCoroutine(SpawnCounter());
            }
        }
	}

    IEnumerator SpawnCounter()
    {
        yield return new WaitForSeconds(10.0f);
        spawnSomething = true;
        counter = null;
    }
}
