using UnityEngine;
using System.Collections;

public class PlayerStatusScript : MonoBehaviour {

    public int health;
    public int tempHealth;

    public GameObject hitEffect;
    public GameObject deathEffect;
    public GameObject boomEffect;
    public GameObject energyShieldEffect;
    GameObject energyShield;

    bool isDead;

    Mesh objectMesh;
    Material[] materials = new Material[0];

    Coroutine deathCoroutine;
    Coroutine healthRegenCoroutine;

    public static PlayerStatusScript instance;

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

        tempHealth = 0;
        health = 10;
        isDead = false;
        deathCoroutine = null;
        energyShield = null;
        healthRegenCoroutine = null;

        objectMesh = GetComponent<MeshFilter>().mesh;
        materials = GetComponent<MeshRenderer>().materials;


#if UNITY_EDITOR

        health = 5000000;
#endif
    }

    void Update()
    {

        if (health <= 0)
        {
            Die();
        }

        if(tempHealth > 0)
        {
            if(energyShield == null)
            {
                energyShield = Instantiate(energyShieldEffect);
                energyShield.transform.parent = gameObject.transform;
                energyShield.transform.localPosition = new Vector3(0.0f, 0.07f, 0.57f);
            }
        }
        else
        {
            if (energyShield != null)
            {
                Destroy(energyShield);
                energyShield = null;
            }
        }

        if(health < 10 && healthRegenCoroutine == null)
        {
            healthRegenCoroutine = StartCoroutine(HealthRegen());
        }
        
    }

    void Die()
    {
        if (deathCoroutine == null)
        {
            deathCoroutine = StartCoroutine(DeathEffect());
        }
    }

    IEnumerator DeathEffect()
    {
        GameObject temp = Instantiate(deathEffect);
        temp.transform.position = transform.position;
        GetComponent<PlayerControlScript>().SetControls(false);
        GetComponent<Rigidbody>().AddRelativeTorque(0.0f, 100.0f, 100.0f);
        yield return new WaitForSeconds(3.0f);
        GameObject boom = Instantiate(boomEffect);
        boom.transform.position = transform.position;
        boom.GetComponent<ParticleSystem>().loop = false;
        temp.GetComponent<ParticleSystem>().Stop();
        StartCoroutine(SplitMesh());
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2.0f);
        boom.GetComponent<ParticleSystem>().Stop();
        isDead = true;
    }

    public IEnumerator SplitMesh()
    {

        Vector3[] verts = objectMesh.vertices;
        Vector3[] normals = objectMesh.normals;
        Vector2[] uvs = objectMesh.uv;
        for (int submesh = 0; submesh < objectMesh.subMeshCount; submesh++)
        {

            int[] indices = objectMesh.GetTriangles(submesh);

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
                Vector3 explosionPos = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(0f, 0.5f), transform.position.z + Random.Range(-0.5f, 0.5f));
                fragment.AddComponent<Rigidbody>().AddExplosionForce(Random.Range(300, 500), explosionPos, 5);
                fragment.AddComponent<DeleteAfterTimeScript>();
                fragment.GetComponent<DeleteAfterTimeScript>().SetTimeThenWait(4.0f);
            }
        }

        GetComponent<Renderer>().enabled = false;

        yield return new WaitForSeconds(1.0f);

    }

    public void IncreaseTempHealth(int toIncreaseBy)
    {
        tempHealth = toIncreaseBy + tempHealth;
    }

    public void SetTempHealth(int toSet)
    {
        tempHealth = toSet;
    }

    public void ReduceHealth(int toReduceBy)
    {
        if (tempHealth > 0)
        {
            tempHealth = tempHealth - toReduceBy;
            Instantiate(hitEffect).transform.position = transform.position;
        }
        else
        {
            health = health - toReduceBy;
            Instantiate(hitEffect).transform.position = transform.position;
        }
    }

    public void IncreaseHealth(int toIncreaseBy)
    {
        if(health >= 10)
        {

        }
        else
        {
            health = health + toIncreaseBy;
        }
    }

    IEnumerator HealthRegen()
    {
        yield return new WaitForSeconds(10.0f);

        IncreaseHealth(1);

        healthRegenCoroutine = null;
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
