using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1BossManagerScript : MonoBehaviour {

    public GameObject weakPoint1;
    public GameObject weakPoint2;
    public GameObject machineGunTurret1;
    public GameObject concussionGunTurret1;
    public GameObject concussionGunTurret2;
    public GameObject hangar1;
    public GameObject hangar2;
    public GameObject mainCannon;

    public GameObject deathEffect;

    GameObject bossHealthBar;
    GameObject deathEffects;

    Rigidbody rb;

    Coroutine wait;

    bool isAlive;
    bool spawnMode;

    int totalHealth;

    public static Level1BossManagerScript instance;

    Coroutine winCoroutine;

    Mesh objectMesh;
    Material[] materials = new Material[0];

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

        weakPoint1 = GameObject.Find("Level1BossTurretWeakPoint");
        weakPoint2 = GameObject.Find("Level1BossTurretWeakPoint2");
        machineGunTurret1 = GameObject.Find("Level1BossMachineGunTurret1");
        concussionGunTurret1 = GameObject.Find("Level1BossConcussionTurret");
        concussionGunTurret2 = GameObject.Find("Level1BossConcussionTurret2");
        hangar1 = GameObject.Find("Level1BossFighterSpawner");
        hangar2 = GameObject.Find("Level1BossFighterSpawner2");
        mainCannon = GameObject.Find("Level1BossMainCannon");

        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;
        isAlive = true;
        spawnMode = true;

        wait = null;
        objectMesh = GetComponent<MeshFilter>().mesh;
        materials = GetComponent<MeshRenderer>().materials;

        totalHealth = weakPoint1.GetComponent<Level1BossTurretWeakPointScript>().health + weakPoint2.GetComponent<Level1BossTurretWeakPointScript>().health +
            concussionGunTurret1.GetComponent<Level1BossConcussionTurretScript>().health + concussionGunTurret2.GetComponent<Level1BossConcussionTurretScript>().health +
            hangar1.GetComponent<Level1BossFighterSpawnerScript>().health + hangar2.GetComponent<Level1BossFighterSpawnerScript>().health +
            machineGunTurret1.GetComponent<Level1BossMachineGunTurretScript>().health;

        bossHealthBar = GameObject.Find("InGameUI(Clone)").transform.FindChild("BossHealthBar").gameObject;
        bossHealthBar.SetActive(true);

        deathEffects = GameObject.Find("BoomParticlesHolder");
        winCoroutine = null;
    }
	
	void LateUpdate ()
    {
        totalHealth = weakPoint1.GetComponent<Level1BossTurretWeakPointScript>().health + weakPoint2.GetComponent<Level1BossTurretWeakPointScript>().health +
    concussionGunTurret1.GetComponent<Level1BossConcussionTurretScript>().health + concussionGunTurret2.GetComponent<Level1BossConcussionTurretScript>().health +
    hangar1.GetComponent<Level1BossFighterSpawnerScript>().health + hangar2.GetComponent<Level1BossFighterSpawnerScript>().health +
    machineGunTurret1.GetComponent<Level1BossMachineGunTurretScript>().health;
        if (spawnMode)
        {
            if(wait == null)
            {
                wait = StartCoroutine(Wait());
            }

            machineGunTurret1.GetComponent<BaseEnemyScript>().SetCanShoot(false);
            concussionGunTurret1.GetComponent<BaseEnemyScript>().SetCanShoot(false);
            concussionGunTurret2.GetComponent<BaseEnemyScript>().SetCanShoot(false);

            Vector3 velocity = new Vector3(0.0f, -200.0f, 0.0f);

            rb.AddForce(velocity);
        }
        else
        {
            if (!GameObject.FindGameObjectWithTag("Background").GetComponent<ScrollingBackgroundScript>().GetIsStopped())
            {
                GameObject.FindGameObjectWithTag("Background").GetComponent<ScrollingBackgroundScript>().SetIsStopped(true);
            }

            machineGunTurret1.GetComponent<BaseEnemyScript>().SetCanShoot(true);
            concussionGunTurret1.GetComponent<BaseEnemyScript>().SetCanShoot(true);
            concussionGunTurret2.GetComponent<BaseEnemyScript>().SetCanShoot(true);
            hangar1.GetComponent<Level1BossFighterSpawnerScript>().canSpawn = true;
            hangar2.GetComponent<Level1BossFighterSpawnerScript>().canSpawn = true;

            if (weakPoint1.GetComponent<Level1BossTurretWeakPointScript>().GetAlive() == false &&
                weakPoint2.GetComponent<Level1BossTurretWeakPointScript>().GetAlive() == false &&
                machineGunTurret1.GetComponent<Level1BossMachineGunTurretScript>().GetAlive() == false &&
                concussionGunTurret1.GetComponent<Level1BossConcussionTurretScript>().GetAlive() == false &&
                concussionGunTurret2.GetComponent<Level1BossConcussionTurretScript>().GetAlive() == false &&
                hangar1.GetComponent<Level1BossFighterSpawnerScript>().GetAlive() == false &&
                hangar2.GetComponent<Level1BossFighterSpawnerScript>().GetAlive() == false)
            {
                isAlive = false;
            }
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.X))
            {
                isAlive = false;
            }
#endif
            if (isAlive == false)
            {
                Die();
            }
        }
	}

    void Die()
    {
        if(winCoroutine == null)
        {
            winCoroutine = StartCoroutine(WinDelay());
        }

    }

    public void ReduceTotalHealthBy(int reduceBy)
    {
        totalHealth = totalHealth - reduceBy;
    }

    public int GetTotalHealth()
    {
        return totalHealth;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.6f);
        spawnMode = false;
        rb.AddForce(0.0f, 0.0f, 0.0f);
        rb.drag = 500000.0f;
    }
    IEnumerator WinDelay()
    {
        deathEffects.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        deathEffects.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        rb.AddTorque(0.0f, 0.0f, 10.0f);
        yield return new WaitForSeconds(2);
        deathEffects.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
        deathEffects.transform.GetChild(3).GetComponent<ParticleSystem>().Play();
        StartCoroutine(SplitMesh());

        weakPoint1.GetComponent<Level1BossTurretWeakPointScript>().deathEffect.GetComponent<ParticleSystem>().Stop();
        weakPoint2.GetComponent<Level1BossTurretWeakPointScript>().deathEffect.GetComponent<ParticleSystem>().Stop();
        machineGunTurret1.GetComponent<Level1BossMachineGunTurretScript>().deathEffect.GetComponent<ParticleSystem>().Stop();
        concussionGunTurret1.GetComponent<Level1BossConcussionTurretScript>().deathEffect.GetComponent<ParticleSystem>().Stop();
        concussionGunTurret2.GetComponent<Level1BossConcussionTurretScript>().deathEffect.GetComponent<ParticleSystem>().Stop();
        hangar1.GetComponent<Level1BossFighterSpawnerScript>().deathEffect.GetComponent<ParticleSystem>().Stop();
        hangar2.GetComponent<Level1BossFighterSpawnerScript>().deathEffect.GetComponent<ParticleSystem>().Stop();

        yield return new WaitForSeconds(3);
        GameManager.instance.SetGameState("Win");
        Destroy(gameObject);
    }
    public IEnumerator SplitMesh()
    {
        List<Mesh> allMeshes = new List<Mesh>();
        List<GameObject> allObjects = new List<GameObject>();

        allMeshes.Add(objectMesh);
        allMeshes.Add(weakPoint1.GetComponent<MeshFilter>().mesh);
        allMeshes.Add(weakPoint2.GetComponent<MeshFilter>().mesh);
        allMeshes.Add(machineGunTurret1.transform.FindChild("Mesh").gameObject.GetComponent<MeshFilter>().mesh);
        allMeshes.Add(concussionGunTurret2.transform.FindChild("Mesh").gameObject.GetComponent<MeshFilter>().mesh);
        allMeshes.Add(hangar1.GetComponent<MeshFilter>().mesh);
        allMeshes.Add(concussionGunTurret1.transform.FindChild("Mesh").gameObject.GetComponent<MeshFilter>().mesh);
        allMeshes.Add(hangar2.GetComponent<MeshFilter>().mesh);
        allMeshes.Add(mainCannon.GetComponent<MeshFilter>().mesh);

        allObjects.Add(gameObject);
        allObjects.Add(weakPoint1);
        allObjects.Add(weakPoint2);
        allObjects.Add(machineGunTurret1.transform.FindChild("Mesh").gameObject);
        allObjects.Add(concussionGunTurret2.transform.FindChild("Mesh").gameObject);
        allObjects.Add(hangar1);
        allObjects.Add(concussionGunTurret1.transform.FindChild("Mesh").gameObject);
        allObjects.Add(hangar2);
        allObjects.Add(mainCannon);


        for (int iter = 0; allMeshes.Count > iter; iter++)
        {
            Vector3[] verts = allMeshes[iter].vertices;
            Vector3[] normals = allMeshes[iter].normals;
            Vector2[] uvs = allMeshes[iter].uv;
            for (int submesh = 0; submesh < objectMesh.subMeshCount; submesh++)
            {

                int[] indices = allMeshes[iter].GetTriangles(submesh);

                for (int i = 0; i < indices.Length; i += 3)
                {
                    Vector3[] newVerts = new Vector3[3];
                    Vector3[] newNormals = new Vector3[3];
                    Vector2[] newUvs = new Vector2[3];
                    for (int n = 0; n < 3; n++)
                    {
                        int index = indices[i + n];
                        newVerts[n] = verts[index];
                        newUvs[n] = uvs[index];
                        newNormals[n] = normals[index];
                    }

                    Mesh mesh = new Mesh();
                    mesh.vertices = newVerts;
                    mesh.normals = newNormals;
                    mesh.uv = newUvs;

                    mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };

                    GameObject fragment = new GameObject("Triangle " + (i / 3));
                    fragment.layer = LayerMask.NameToLayer("Default");
                    fragment.transform.position = transform.position;
                    fragment.transform.rotation = transform.rotation;
                    fragment.AddComponent<MeshRenderer>().material = materials[submesh];
                    fragment.AddComponent<MeshFilter>().mesh = mesh;
                    Vector3 explosionPos = new Vector3(allObjects[iter].transform.position.x + Random.Range(-0.5f, 0.5f), 
                        allObjects[iter].transform.position.y + Random.Range(0f, 0.5f), 
                        allObjects[iter].transform.position.z + Random.Range(-0.5f, 0.5f));
                    fragment.AddComponent<Rigidbody>().AddExplosionForce(Random.Range(300, 500), explosionPos, 5);
                    fragment.AddComponent<DeleteAfterTimeScript>();
                    fragment.GetComponent<DeleteAfterTimeScript>().SetTimeThenWait(4.0f);
                }
            }
            allObjects[iter].GetComponent<Renderer>().enabled = false;
        }

        yield return new WaitForSeconds(1.0f);

    }
}
