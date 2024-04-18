    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCombat : MonoBehaviour
{
    public GameObject targetMinion;

    float damage;
    public float health;

    public float distanceThreshold = 2f;
    public float attackCooldown = 1f;
    private float timeSinceLastAttack = 0f;


    void Start()
    {
        damage = Random.Range(0.5f, 2f);
    }

    
    void Update()
    {
        if (targetMinion != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetMinion.transform.position);

            if (distanceToTarget <= distanceThreshold && timeSinceLastAttack >= attackCooldown)
            {
                targetMinion.GetComponent<MinionCombat>().TakeDamage(damage);
                timeSinceLastAttack = 0f; // Reset attack cooldown
            }
        }

        timeSinceLastAttack += Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Primam stetu, health: " + health);

        if(health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
