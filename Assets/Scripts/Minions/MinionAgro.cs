using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAgro : MonoBehaviour
{
    GameObject minion;
    public string enemyTeamTag;

    void Start()
    {
        minion = transform.parent.gameObject;
        enemyTeamTag = minion.GetComponent<MinionMovement>().enemyTeamTag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTeamTag && other.gameObject.layer == minion.gameObject.layer) // Check if triger colided with miniont of oposite team
        {
            minion.GetComponent<MinionMovement>().enemyMinionsInRange.Add(other.gameObject);
            Debug.Log("colidiovao sa: " + other.gameObject.name);
        }
    }
}
