using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : EnemyAI
{
    public RaycastHit hit;
    public float FOVAngle = 110f;
    public bool playerSpotted;
    public Vector3 lastSighting;

    private NavMeshAgent nav;
    private SphereCollider col;
    private GameObject player;
    private EnemyAI ai;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GetComponent<EnemyAI>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - transform.position;
            //  ai.attack();
            GetComponent<NavMeshAgent>().destination = player.transform.position;

        }
    }
    void FixedUpdate()
    {

    }


}