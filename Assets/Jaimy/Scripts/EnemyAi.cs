using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAi : MonoBehaviour
{
    public enum fireModes
    {
        Automatic = 1
    }
    public GameObject cannon;
    public GameObject bullet;
    public GameObject target;
    public float distance;
    public float detectionRange;
    public bool canFire;
    public fireModes fireMode;
    public float walkRange;
    public bool walking;
    public NavMeshAgent instanceAgent;
    public Vector3 newWalkPos;


    private void Awake()
    {
        instanceAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result) {
        for (int i = 0; i < 30; i++) {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        instanceAgent.destination = transform.position;
        walkRange = 10.0f;
        canFire = true;
        walking = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= detectionRange)
        {
           cannon.transform.LookAt(target.transform, Vector3.up);
           FireCannon();
        }
        Wander();
    }

    public void Wander()
    {
        if (instanceAgent.remainingDistance <= 0.5f)
        {
            if (RandomPoint(transform.position, walkRange, out newWalkPos))
            {
                instanceAgent.destination = newWalkPos;
            }
        }
    }

    public void FireCannon()
    {
        if (fireMode == fireModes.Automatic)
        {
            if (canFire == true)
            {
                Instantiate(bullet, cannon.transform.position, cannon.transform.rotation);
                StartCoroutine(FireDelayIE(0.2f));  
            }
        }
    }

    public IEnumerator FireDelayIE(float delay)
    {
         canFire = false;
         yield return new WaitForSeconds(delay);
         canFire = true;
    }

}
