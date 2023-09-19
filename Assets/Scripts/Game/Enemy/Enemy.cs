using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable enable

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    enum  EnemyState :ushort
    {
        BaseChasing =0,
        AttackerChasing =1
    };
    private IEnumerator? damageRoutine=null;
    private IEnumerator? deInterestRoutine=null;

    private Rigidbody2D? rigidBody;
    private Health? health;

    private EnemyState enemyState;
    private GameObject? baseRef;
    private GameObject? attackerRef;

    public float movementSpeed;
    public float acceleration;
    public int damage;
    public int loseInterestDelay;
    public int exp;

    void Start()
    {
        enemyState =EnemyState.BaseChasing;
        health =gameObject.GetComponent<Health>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        baseRef =GameObject.FindWithTag("Base");
    }

    public void DoAttack(GameObject attacker, int damage)
    {
        health!.DoDamage(damage);
        if (enemyState ==EnemyState.BaseChasing)
        {
            attackerRef =attacker;
            enemyState = EnemyState.AttackerChasing;
            deInterestRoutine =DeInterestRoutine();
            StartCoroutine(deInterestRoutine);
        }
        else if (enemyState == EnemyState.AttackerChasing
            && deInterestRoutine !=null)
        {
            StopCoroutine(deInterestRoutine);
            deInterestRoutine =DeInterestRoutine();
            StartCoroutine(deInterestRoutine);
        }
    }

    IEnumerator DeInterestRoutine()
    {
        yield return new WaitForSeconds(loseInterestDelay);
        enemyState =EnemyState.BaseChasing;
    }

    void FixedUpdate()
    {
        // move based on the state ..
        Vector2 vectorDiff =new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (enemyState == EnemyState.AttackerChasing)
        {
            Vector2 attackerPosition =new Vector2(attackerRef!.transform.position.x, attackerRef!.transform.position.y);
            vectorDiff = attackerPosition - vectorDiff;
        }
        else
        {
            Vector2 basePosition =new Vector2(baseRef!.transform.position.x, baseRef!.transform.position.y);
            vectorDiff = basePosition -vectorDiff;
        }
        rigidBody!.AddForce(vectorDiff * acceleration, ForceMode2D.Impulse);
        if (Vector2.Dot(rigidBody!.velocity, vectorDiff) > movementSpeed)
        {
            rigidBody!.velocity = vectorDiff.normalized * movementSpeed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyState == EnemyState.AttackerChasing
            && collision.gameObject ==attackerRef)
        {
            damageRoutine =DoDamageRoutine(collision.gameObject);
            StartCoroutine(damageRoutine);
            StopCoroutine(deInterestRoutine);
            deInterestRoutine =null;
        }
        else if (enemyState == EnemyState.BaseChasing
            && collision.gameObject ==baseRef)
        {
            damageRoutine =DoDamageRoutine(collision.gameObject);
            StartCoroutine(damageRoutine);
        }
    }

    IEnumerator DoDamageRoutine(GameObject target)
    {
        Health targetHealth =target.GetComponent<Health>();
        while (true)
        {
            if (targetHealth.DoDamage(damage))
            {
                break;
            }
            yield return new WaitForSeconds(1);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (damageRoutine !=null)
        {
            StopCoroutine(damageRoutine);
            damageRoutine =null;
        }
        if (enemyState ==EnemyState.AttackerChasing
            && collision.gameObject ==attackerRef)
        {
            deInterestRoutine = DeInterestRoutine();
            StartCoroutine(deInterestRoutine);   
        }
    }

    void OnDestroy()
    {
        GameObject player =GameObject.FindWithTag("Player");
        if (player !=null)
        {
            Player playerComponent = player.GetComponent<Player>();
            playerComponent.AddExp(exp);
        }
    }
}
