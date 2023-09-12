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
        PlayerChasing =1
    };
    private IEnumerator? damageRoutine=null;
    private IEnumerator? deInterestRoutine=null;

    private Rigidbody2D? rigidBody;
    private Health? health;

    private EnemyState enemyState;
    private GameObject? baseRef;
    private GameObject? playerRef;

    public float movementSpeed;
    public float acceleration;
    public int damage;
    public int loseInterestDelay;

    void Start()
    {
        enemyState =EnemyState.BaseChasing;
        health =gameObject.GetComponent<Health>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerRef =GameObject.FindWithTag("Player");
        baseRef =GameObject.FindWithTag("Base");
    }

    public void DoAttack(int damage)
    {
        health!.DoDamage(damage);
        if (enemyState ==EnemyState.BaseChasing)
        {
            enemyState = EnemyState.PlayerChasing;
            deInterestRoutine =DeInterestRoutine();
            StartCoroutine(deInterestRoutine);
        }
        else if (enemyState == EnemyState.PlayerChasing
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

    void Update()
    {
        // move based on the state ..
        Vector2 vectorDiff =new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (enemyState == EnemyState.PlayerChasing)
        {
            Vector2 playerPosition =new Vector2(playerRef!.transform.position.x, playerRef!.transform.position.y);
            vectorDiff = playerPosition - vectorDiff;
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
        if (enemyState == EnemyState.PlayerChasing
            && collision.gameObject ==playerRef)
        {
            damageRoutine =DoDamageRoutine(collision.gameObject);
            StartCoroutine(damageRoutine);
            StopCoroutine(deInterestRoutine);
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
            targetHealth.DoDamage(damage);
            yield return new WaitForSeconds(1);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (enemyState ==EnemyState.PlayerChasing
            && collision.gameObject ==playerRef)
        {
            deInterestRoutine = DeInterestRoutine();
            StartCoroutine(deInterestRoutine);   
        }
    }
}
