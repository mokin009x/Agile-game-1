using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float maxMoveSpeed;
    public float acceleration;
    public float deceleration;
    float moveSpeed;
    public float rotationSpeed;
    Vector3 totalSpeed = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool moving = false;

        if (Input.GetKey(KeyCode.W) && totalSpeed.z < maxMoveSpeed )
        {
            totalSpeed.z += acceleration;
            moving = true;
        } else if (Input.GetKey(KeyCode.S) && totalSpeed.z > -maxMoveSpeed)
        {
            totalSpeed.z -= acceleration;
            moving = true;
        }
        
        if (!moving)
        {
            totalSpeed.z = Mathf.MoveTowards(totalSpeed.z, 0, deceleration);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,rotationSpeed * Time.deltaTime, 0);
        } 

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,-rotationSpeed * Time.deltaTime ,0);
        } 

        transform.Translate(totalSpeed * Time.deltaTime);
    }
}
