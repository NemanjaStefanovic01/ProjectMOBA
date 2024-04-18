using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAgro : MonoBehaviour
{
    GameObject minion;
    public string enemyTeamTag;

    public List<GameObject> aggroList = new List<GameObject>();

    void Start()
    {
        minion = transform.parent.gameObject;
        enemyTeamTag = minion.GetComponent<MinionMovement>().enemyTeamTag;
    }

    private void Update()
    {
        for (int i = 0; i < aggroList.Count; i++)
        {
            if (aggroList[i] == null)
            {
                aggroList.RemoveAt(i);
                i--;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTeamTag && other.gameObject.layer == minion.gameObject.layer) // Check if triger colided with miniont of oposite team
        {
            aggroList.Add(other.gameObject);
            Debug.Log("colidiovao sa: " + other.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == enemyTeamTag && other.gameObject.layer == minion.gameObject.layer) 
        {
            aggroList.Remove(other.gameObject);
        }
    }
}
