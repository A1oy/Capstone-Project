using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#nullable enable

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Bear : MonoBehaviour
{
    private Rigidbody2D? rigidBody;
    private Health? health;

    public GameObject? attackerRef;
    private NavMeshAgent agent = null!;

    [SerializeField]
    int damage;

    private float honeyRange = 7.0f;

    [SerializeField]
    AudioSource hitSource;

    [SerializeField]
    float attackDelay;
    
    float cooldown;

    bool isAttacking =false;

    void Awake()
    {
        health = GetComponent<Health>();
        rigidBody = GetComponent<Rigidbody2D>();
        attackerRef = GameObject.FindWithTag("Base");
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void DoAttack(int damage)
    {
        health!.DoDamage(damage);
    }

    float DetermineClosest(Vector3 currentPos, float bestDist, GameObject[] gameObjs, ref GameObject gameObjTarget)
    {
        Vector3 vectorDiff = new Vector3(0.0f, 0.0f, 0.0f);
        foreach (GameObject gameObj in gameObjs)
        {
            vectorDiff = currentPos - gameObj.transform.position;
            if (vectorDiff.magnitude < bestDist
                && !gameObj.GetComponent<Health>().IsDead())
            {
                bestDist = vectorDiff.magnitude;
                gameObjTarget = gameObj;
            }
        }
        return bestDist;
    }

    void DetermineTarget()
    {
        Vector3 currentPos = transform.position;
        float shortestDist = 10000000.0f;

        Collider2D[] honeyDetected = Physics2D.OverlapCircleAll(transform.position, honeyRange, 1 << 8);
        if (honeyDetected.Length != 0)
		{
            foreach (Collider2D collider in honeyDetected)
            {
                Debug.Log(collider.gameObject.name);
                float distance = Vector3.Distance(currentPos, collider.gameObject.transform.position);
                if (distance < shortestDist)
                {
                    shortestDist = distance;
                    attackerRef = collider.gameObject;
                }
            }
            return;
        }

        GameObject[] playersRef =GameObject.FindGameObjectsWithTag("Player");

        GameObject gameObjTarget = null;
        float dist = Mathf.Infinity;
        dist = DetermineClosest(currentPos, dist, playersRef, ref gameObjTarget);

        attackerRef = gameObjTarget;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(transform.position, honeyRange);
    }

    void FixedUpdate()
    {
        DetermineTarget();
        if (attackerRef)
        {
            agent.destination =attackerRef!.transform.position;
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
            cooldown =attackDelay;
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
