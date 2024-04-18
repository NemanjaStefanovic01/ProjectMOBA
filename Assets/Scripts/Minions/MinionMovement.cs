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
    public MinionAgro agro;
    public List<GameObject> enemyMinionsInRange
    {
        get
        {
            if (agro == null)
                return null;
            return agro.aggroList;  
        }
    }

    private void Start()
    {

        agro = GetComponentInChildren<MinionAgro>();
        target = GameObject.Find("MiddlePoint").transform;
    }
    void Update()
    {
        SelectTargetFromAgroList();

        //Update Agents target destination
        if (target != null)
            agent.destination = target.position;
        else
            agent.destination = agent.transform.position;
    }

    private void SelectTargetFromAgroList()
    {
        if (enemyMinionsInRange == null || enemyMinionsInRange.Count == 0)
            return;

        //Add Agro priority!
        if (enemyMinionsInRange[0] != null)
            target = enemyMinionsInRange[0].transform;
        

        this.GetComponent<MinionCombat>().targetMinion = enemyMinionsInRange[0];
    }
}
