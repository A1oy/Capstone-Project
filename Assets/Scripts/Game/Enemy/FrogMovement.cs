using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    UnityEngine.AI.NavMeshAgent agent;
    GameObject attackerRef;
    Animator animator;

    //movement related
    [SerializeField]
    float force;
    float idleTimer = 0.0f;
    public string stringDirection;

    //damage related
    [SerializeField]
    float attackDelay;
    float cooldown;
    float range = 4f;
    string attackDirection;

    //tongue related
    public GameObject tongue;
    public Transform tonguePos;

    //audio
    [SerializeField]
    AudioSource hitSource;


    // Start is called before the first frame update
    void Start()
    {
        attackerRef = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        idleTimer += Time.deltaTime;
        bool playerFound = playerDetection();
        Vector3 direction = (attackerRef.transform.position - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle >= -90 && angle <= 90)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            stringDirection = "JumpRight";
            attackDirection = "AttackRight";
        }
        else if (angle >= -180 && angle <= 180)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            stringDirection = "JumpLeft";
            attackDirection = "AttackLeft";
        }
        if ((attackerRef) && (idleTimer >= 1.5f) && (playerFound == false))
        {
            animator.SetTrigger(stringDirection);
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
        animator.SetTrigger(attackDirection);
        Instantiate(tongue, tonguePos.position, Quaternion.identity);
	}

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(transform.position, range);
    }

}
