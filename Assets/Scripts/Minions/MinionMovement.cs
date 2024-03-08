using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    private void Start()
    {
        target = GameObject.Find("MiddlePoint").transform;
    }
    void Update()
    {
        agent.destination = target.position;
    }
}
