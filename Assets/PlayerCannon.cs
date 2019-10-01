using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    Plane hitField;
    public GameObject barrle;
    public GameObject Bullet;
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


    }
}
