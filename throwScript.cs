using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwScript : MonoBehaviour
{

    //Rigidbody rigidbody;
    public Rigidbody rb;
    public float speed = 6f;
    public Vector3 vBall = new Vector3(0, 1, 1);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vBall * Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        speed = 0f;
        rb.isKinematic = true;
    }

    //void OnCollisionStay(Collision other)
    //
    //   rigidbody.velocity = new Vector3(rigidbody.velocity.x,downForce,rigidbody.velocity.z);
    //
}
