using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable enable

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private IEnumerator? damageRoutine=null;

    private Rigidbody2D? rigidBody;
    private Health? health;

    private GameObject? attackerRef;

    public float movementSpeed;
    public float acceleration;
    public int damage;
    public int honeyDrops =1;

    void Start()
    {
        health =gameObject.GetComponent<Health>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        attackerRef =GameObject.FindWithTag("Base");
    }

    public void DoAttack(int damage)
    {
        health!.DoDamage(damage);
    }

    float DetermineClosest(Vector3 currentPos, float bestDist, GameObject[] gameObjs, ref GameObject gameObjTarget)
    {
        Vector3 vectorDiff =new Vector3(0.0f, 0.0f, 0.0f);
        foreach (GameObject gameObj in gameObjs)
        {
            
            vectorDiff =currentPos-gameObj.transform.position;
            if (vectorDiff.magnitude < bestDist)
            {
                bestDist =vectorDiff.magnitude;
                gameObjTarget =gameObj;
            }
        }
        return bestDist;
    }

    void DetermineTarget()
    {
        Vector3 currentPos =gameObject.transform.position;

        GameObject baseRef =GameObject.FindWithTag("Base");
        GameObject[] playersRef =GameObject.FindGameObjectsWithTag("Player");
        GameObject[] turretsRef  =GameObject.FindGameObjectsWithTag("Turret");

        if (baseRef)
        {
            GameObject gameObjTarget =baseRef;
            float dist =(currentPos -baseRef.transform.position).magnitude;
            dist = DetermineClosest(currentPos, dist, playersRef, ref gameObjTarget);
            dist = DetermineClosest(currentPos, dist, turretsRef, ref gameObjTarget);
            
            attackerRef =gameObjTarget;
            Debug.Log(attackerRef);
        }
    }

    void FixedUpdate()
    {
        DetermineTarget();

        Vector2 vectorDiff =new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (attackerRef)
        {
            Vector2 attackerPosition =new Vector2(attackerRef!.transform.position.x, attackerRef!.transform.position.y);
            vectorDiff = attackerPosition -vectorDiff;
        }
        Debug.Log(vectorDiff);
        rigidBody!.AddForce(vectorDiff * acceleration, ForceMode2D.Impulse);
        if (Vector2.Dot(rigidBody!.velocity, vectorDiff) > movementSpeed)
        {
            rigidBody!.velocity = vectorDiff.normalized * movementSpeed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject ==attackerRef)
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
    }

    void OnDestroy()
    {
        GameObject player =GameObject.FindWithTag("Player");
        if (player)
        {
            Player playerComponent = player.GetComponent<Player>();
            playerComponent.GiveHoney(honeyDrops);
        }
    }
}
