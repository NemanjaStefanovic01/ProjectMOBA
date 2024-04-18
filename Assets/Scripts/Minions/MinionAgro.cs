using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAgro : MonoBehaviour
{
    GameObject minion;
    public string enemyTeamTag;

    List<GameObject> aggroList;

    void Start()
    {
        minion = transform.parent.gameObject;
        enemyTeamTag = minion.GetComponent<MinionMovement>().enemyTeamTag;
    }

    private void OnTriggerEnter(Collider other)
    {
        aggroList = minion.GetComponent<MinionMovement>().enemyMinionsInRange;

        if (other.tag == enemyTeamTag && other.gameObject.layer == minion.gameObject.layer) // Check if triger colided with miniont of oposite team
        {
            aggroList.Add(other.gameObject);
            Debug.Log("colidiovao sa: " + other.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        aggroList = minion.GetComponent<MinionMovement>().enemyMinionsInRange;

        if (other.tag == enemyTeamTag && other.gameObject.layer == minion.gameObject.layer) 
        {
            for (int i = 0; i < aggroList.Count; i++)
            {
                if(i == aggroList.Count - 1)
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
