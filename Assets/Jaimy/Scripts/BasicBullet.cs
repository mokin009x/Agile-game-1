using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject bulletTip;
    public Vector3 forward;
    public int speed;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        forward = bulletTip.transform.position - transform.position;
        rb.AddForce(forward.normalized * speed);
    }

    private void OnCollisionEnter(Collision coll)
    {
        // top wall
        if (coll.collider.CompareTag("Finish"))
        {
            rb.velocity = Vector3.zero;

            // change movement direction
            //forward = transform.position - coll.contacts[0].point;

            if (forward.x < 0)
            {
                forward.z = forward.z * -1;
            }

            if (forward.x > 0)
            {
                forward.z = forward.z * -1;
            }

            rb.AddForce(forward.normalized * speed);
        }

        // side wall
        if (coll.collider.CompareTag("Respawn"))
        {
            rb.velocity = Vector3.zero;

            if (forward.z < 0)
            {
                forward.x = forward.x * -1;
            }

            if (forward.z > 0)
            {
                forward.x = forward.x * -1;
            }

            rb.AddForce(forward.normalized * speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
