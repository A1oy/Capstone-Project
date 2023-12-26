using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
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

    public float force;
    float range = 4f;
    float idleTimer = 0.0f;
    float jumpForceX = 4f;
    float jumpForceY = 4f;
    // Start is called before the first frame update
    void Start()
    {
        attackerRef = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        idleTimer += Time.deltaTime;
        bool playerFound = playerDetection();
        if ((attackerRef) && (idleTimer >= 2f) && (playerFound == false))
        {
            Vector3 direction = attackerRef.transform.position - transform.position.normalized;
            Debug.Log(direction);
            direction = direction * force;
            Debug.Log(direction);
            agent.velocity = direction;
            //transform.position = Vector2.MoveTowards(transform.position, attackerRef.transform.position, 0.5f);
            idleTimer = 0.0f;
        }
        else if (playerFound)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f)
            {
                cooldown = attackDelay;
                DoAttack();
            }
        }
    }

    private bool playerDetection()
	{
        Collider2D playerFound = Physics2D.OverlapCircle(transform.position, range, 1 << 7);
        if (playerFound)
        {
            return true;
        }
		else
		{
            return false;
        }
    }

    void DoAttack()
    {
        attackerRef.GetComponent<Health>().DoDamage(damage);
        hitSource.Play();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(transform.position, range);
    }

}
