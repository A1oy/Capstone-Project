using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    UnityEngine.AI.NavMeshAgent agent;
    GameObject attackerRef;

    //movement related
    [SerializeField]
    float force;
    float idleTimer = 0.0f;

    //damage related
    [SerializeField]
    int damage;
    [SerializeField]
    float attackDelay;
    float cooldown;
    float range = 4f;

    //tongue related
    public GameObject tongue;
    public Transform tonguePos;

    [SerializeField]
    AudioSource hitSource;


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
        if ((attackerRef) && (idleTimer >= 1.5f) && (playerFound == false))
        {
            Vector3 direction = (attackerRef.transform.position - this.transform.position).normalized;
            direction = direction * force;
            agent.velocity = direction;
            idleTimer = 0.0f;
        }
        else if (playerFound)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f)
            {
                cooldown = attackDelay;
                shoot();
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

    void shoot()
	{
        Instantiate(tongue, tonguePos.position, Quaternion.identity);
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
