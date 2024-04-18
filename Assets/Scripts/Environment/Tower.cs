using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<GameObject> aggroList;
    public string enemyTeamTag;

    public float attackCooldown = 1f;
    private float timeSinceLastAttack = 0f;

    private GameObject minion;
    private GameObject targetMinion;

    void Update()
    {
        if (aggroList.Count >= 1) 
            targetMinion = aggroList[0];

        if (targetMinion != null)
        {
            if (timeSinceLastAttack >= attackCooldown)
            {
                targetMinion.GetComponent<MinionCombat>().TakeDamage(2);
                timeSinceLastAttack = 0f; // Reset attack cooldown
            }
        }

        timeSinceLastAttack += Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        //Ako minion udje u range
        if (other.tag == enemyTeamTag && other.gameObject.layer == LayerMask.NameToLayer("Minion")) // Check if triger colided with miniont of oposite team
        {
            aggroList.Add(other.gameObject);
            Debug.Log("colidiovao sa: " + other.gameObject.name);
        }

        //Ako Player udje u range
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == enemyTeamTag && other.gameObject.layer == minion.gameObject.layer)
        {
            for (int i = 0; i < aggroList.Count; i++)
            {
                if (i == aggroList.Count - 1)
                {
                    aggroList.RemoveAt(i);
                }
                else
                {
                    aggroList[i] = aggroList[i + 1];
                }
            }
        }
    }
}
