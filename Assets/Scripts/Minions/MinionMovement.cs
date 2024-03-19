using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionMovement : MonoBehaviour
{
    //Refs
    public NavMeshAgent agent;
    public Transform target;

    //Agro functionality
    public string enemyTeamTag;
    public List<GameObject> enemyMinionsInRange;

    private void Start()
    {
        target = GameObject.Find("MiddlePoint").transform;
    }
    void Update()
    {
        SelectTargetFromAgroList();

        //Update Agents target destination
        agent.destination = target.position;
    }

    private void SelectTargetFromAgroList()
    {
        if (enemyMinionsInRange.Count == 0)
            return;

        //Add Agro priority!

        target = enemyMinionsInRange[0].transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == enemyTeamTag && other.gameObject.layer == this.gameObject.layer) // Check if triger colided with miniont of oposite team
        {
            enemyMinionsInRange.Add(other.gameObject);
            Debug.Log("colidiovao sa: " + other.gameObject.name);
        }
    }
}
