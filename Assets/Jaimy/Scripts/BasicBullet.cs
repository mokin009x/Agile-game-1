﻿using System;
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
    public int bounceAmount;

    public LayerMask wallMask;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision coll)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (bounceAmount > 0)
        {
            if (coll.gameObject.layer != LayerMask.NameToLayer("Walls"))
            {
                Destroy(this.gameObject);
            }

            if (Physics.Raycast(ray, out hit, Vector3.Distance(ray.origin, ray.direction), wallMask))
            {
                rb.velocity = Vector3.zero;
                Vector3 reflectDirection = Vector3.Reflect(ray.direction, hit.normal);
                float rot = 90 - Mathf.Atan2(reflectDirection.z, reflectDirection.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, rot, 0);
                rb.AddForce(transform.forward * speed);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, Mathf.Infinity);
                bounceAmount--;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
