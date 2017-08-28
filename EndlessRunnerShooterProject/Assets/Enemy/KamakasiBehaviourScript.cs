using UnityEngine;
using System.Collections;

public class KamakasiBehaviourScript : BaseEnemyScript {

    Rigidbody rb;
    GameObject mesh;
    // Use this for initialization
    public override void Start () {

        base.Start();

        rb = GetComponent<Rigidbody>();
        rb.drag = 20.0f;

        mesh = GetComponentInChildren<MeshRenderer>().gameObject;
    }

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
        if (GameManager.instance.GetGameState() != "Pause")
        {

            //transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
            rb.AddRelativeForce(Vector3.right * speed, ForceMode.Force);

            Vector3 vectorToTarget = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10.0f);

            mesh.transform.localRotation = new Quaternion(-180.0f, 180.0f, 0.0f, 0.0f);

        }

    }

    public override void OnTriggerEnter(Collider _collider)
    {
        base.OnTriggerEnter(_collider);
    }

}
