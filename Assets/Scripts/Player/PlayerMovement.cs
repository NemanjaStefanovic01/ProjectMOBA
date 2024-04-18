using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public string terrainTag = "Terrain";
    public float movementSpeed = 5f;

    public bool canMove = true;

    private Vector3 targetPosition;
    private bool isMoving = false;
    public LayerMask clickables;

    void Update()
    {
        HandleInput();

        if(canMove)
            MoveCharacter();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity,clickables))
            {
                //Ako pogodi teren
                if (hit.collider.CompareTag(terrainTag))
                {
                    targetPosition = hit.point + Vector3.up; // Vector3.up -> doda +1 na y
                    isMoving = true;
                }

                //Ako pogodi protivnika ide u combat scriptu
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Minion"))
                {
                    gameObject.GetComponent<PlayerCombat>().HitMinion(hit.collider.gameObject);
                }
            }
        }
    }
    private void MoveCharacter()
    {
        if (isMoving)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition); //.Distance vraca distancu izmedju 2 Vec

            if (distance > 0.1f)
            {
                transform.position += direction * movementSpeed * Time.deltaTime;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
