using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    Plane hitField;
    public GameObject barrle;
    public GameObject bullet;
    public float reloadTime;
    float timer;


    void Start()
    {
        hitField = new Plane(Vector3.up, transform.position);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0;
        if (hitField.Raycast(ray, out enter))
        {
           transform.LookAt (ray.GetPoint(enter));
        }

        if (Input.GetMouseButtonDown (0) && Time.time > reloadTime + timer)
        {
            timer = Time.time + reloadTime;

            Debug.Log("shoot");

        }

    }
}
