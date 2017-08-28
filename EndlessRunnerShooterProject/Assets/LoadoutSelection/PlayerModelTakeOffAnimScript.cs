using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerModelTakeOffAnimScript : MonoBehaviour {

    Rigidbody rb;

    public static PlayerModelTakeOffAnimScript instance;

    List<GameObject> upThrusterParticleSystems;

    List<GameObject> engineParticleSystems;

    GameObject sideParticleSystem;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        upThrusterParticleSystems = new List<GameObject>();
        engineParticleSystems = new List<GameObject>();

        upThrusterParticleSystems.Add(gameObject.transform.GetChild(5).gameObject);
        upThrusterParticleSystems.Add(gameObject.transform.GetChild(6).gameObject);
        upThrusterParticleSystems.Add(gameObject.transform.GetChild(7).gameObject);
        upThrusterParticleSystems.Add(gameObject.transform.GetChild(8).gameObject);

        sideParticleSystem = gameObject.transform.GetChild(4).gameObject;

        engineParticleSystems.Add(gameObject.transform.GetChild(0).gameObject);
        engineParticleSystems.Add(gameObject.transform.GetChild(1).gameObject);
        engineParticleSystems.Add(gameObject.transform.GetChild(2).gameObject);
        engineParticleSystems.Add(gameObject.transform.GetChild(3).gameObject);

        for (int iter = 0; upThrusterParticleSystems.Count > iter; iter++)
        {
            if (upThrusterParticleSystems[iter].GetComponent<ParticleSystem>().isPlaying)
            {
                upThrusterParticleSystems[iter].GetComponent<ParticleSystem>().Stop();
            }
        }
        for (int iter = 0; engineParticleSystems.Count > iter; iter++)
        {
            if (engineParticleSystems[iter].GetComponent<ParticleSystem>().isPlaying)
            {
                engineParticleSystems[iter].GetComponent<ParticleSystem>().Stop();
            }
        }

        if (sideParticleSystem.GetComponent<ParticleSystem>().isPlaying)
        {
            sideParticleSystem.GetComponent<ParticleSystem>().Stop();
        }
    }

	public void TakeOffAnimation()
    {
        rb = GetComponent<Rigidbody>();

        rb.drag = 1.0f;
        StartCoroutine(TakeOffStaged());
        
    }

    IEnumerator TakeOffStaged()
    {
        for(int iter = 0; upThrusterParticleSystems.Count > iter; iter++)
        {
            if (!upThrusterParticleSystems[iter].GetComponent<ParticleSystem>().isPlaying)
            {
                upThrusterParticleSystems[iter].GetComponent<ParticleSystem>().Play();
            }
        }
        Vector3 force = new Vector3(0.0f, 0.0f, 200.0f);
        rb.AddRelativeForce(force, ForceMode.Force);
        yield return new WaitForSeconds(2.0f);

        for (int iter = 0; upThrusterParticleSystems.Count > iter; iter++)
        {
            upThrusterParticleSystems[iter].GetComponent<ParticleSystem>().Stop();
        }
        
        sideParticleSystem.GetComponent<ParticleSystem>().Play();

        force = new Vector3(0.0f, 0.0f, 40.0f);
        rb.AddRelativeTorque(force, ForceMode.Force);
        yield return new WaitForSeconds(1.0f);

        sideParticleSystem.GetComponent<ParticleSystem>().Stop();

        for (int iter = 0; engineParticleSystems.Count > iter; iter++)
        {
            engineParticleSystems[iter].GetComponent<ParticleSystem>().Play();
        }

        rb.freezeRotation = true;
        rb.freezeRotation = false;

        force = new Vector3(-30.0f, 0.0f, 0.0f);
        rb.AddRelativeTorque(force, ForceMode.Force);
        force = new Vector3(0.0f, -10.0f, 0.0f);
        rb.AddRelativeForce(force, ForceMode.Impulse);

        yield return new WaitForSeconds(0.5f);

        force = new Vector3(0.0f, -30.0f, 0.0f);
        rb.AddRelativeForce(force, ForceMode.Impulse);

        yield return new WaitForSeconds(0.5f);

        force = new Vector3(0.0f, -30.0f, 0.0f);
        rb.AddRelativeForce(force, ForceMode.Impulse);

        yield return new WaitForSeconds(0.5f);

        force = new Vector3(0.0f, -30.0f, 0.0f);
        rb.AddRelativeForce(force, ForceMode.Impulse);

        yield return new WaitForSeconds(0.5f);

        force = new Vector3(0.0f, -30.0f, 0.0f);
        rb.AddRelativeForce(force, ForceMode.Impulse);

    }

}
