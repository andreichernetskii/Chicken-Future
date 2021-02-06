using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMesh;

    float time;
    public float updatePerSecond = 1;
    
    void Start()
    {
        //Düşman verileri xml'den çekilecek
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        navMesh.updateRotation = true;
        navMesh.speed = 1f;
        navMesh.Move(Vector3.forward);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > updatePerSecond)
        {
            navMesh.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
            time = 0;
        }
    }
}
