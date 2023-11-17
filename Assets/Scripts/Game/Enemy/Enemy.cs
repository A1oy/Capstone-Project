using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#nullable enable

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private IEnumerator? damageRoutine=null;

    private Rigidbody2D? rigidBody;
    private Health? health;

    public GameObject? attackerRef;
    private NavMeshAgent agent =null!;

    public int damage;
    public float detectRadius =4.0f;

    void Start()
    {
        health =GetComponent<Health>();
        rigidBody = GetComponent<Rigidbody2D>();
        attackerRef =GameObject.FindWithTag("Base");
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation =false;
        agent.updateUpAxis =false;
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
        Vector3 currentPos =transform.position;

        Collider2D baitCollide =Physics2D.OverlapCircle(transform.position, detectRadius, 1<<8);
        if (baitCollide)
        {
            attackerRef =baitCollide.gameObject;
            return ;
        }

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
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(transform.position, detectRadius);
    }

    void FixedUpdate()
    {
        DetermineTarget();
        if (attackerRef)
        {
            agent.destination =attackerRef!.transform.position;
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
}
