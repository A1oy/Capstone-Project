using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    UnityEngine.AI.NavMeshAgent agent;
    GameObject attackerRef;

    [SerializeField]
    int damage;

	[SerializeField]
    float attackDelay;

    [SerializeField]
    AudioSource hitSource;

    float cooldown;

    bool isAttacking =false;


      void Start()
      {
        attackerRef = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.updateRotation =false;
        agent.updateUpAxis =false;
      }

    void FixedUpdate()
    {
        if (attackerRef)
        {
            agent.destination = attackerRef!.transform.position;
        }
        if (isAttacking)
        {
            cooldown -= Time.deltaTime;
            if (cooldown<=0f)
            {
                cooldown =attackDelay;
                DoAttack();
            }
        }
    }

    void OnTouchEnter(Collider2D collider)
    {
        if (collider.gameObject ==attackerRef)
        {
            //cooldown = 0;
            cooldown = attackDelay;
            isAttacking =true;
        }
    }

    void OnTouchExit(Collider2D collider)
    {
        isAttacking=false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        OnTouchEnter(collider);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        OnTouchExit(collider);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        OnTouchEnter(collision.collider);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        OnTouchExit(collision.collider);
    }

    void DoAttack()
    {
        attackerRef.GetComponent<Health>().DoDamage(damage);
        hitSource.Play();
    }
}