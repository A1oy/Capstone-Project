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
    float force = 5f;
    float idleTimer = 0.0f;

    //damage related
    [SerializeField]
    float attackDelay;
    float cooldown;
    float range = 3.5f;

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
        cooldown = attackDelay;

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool playerFound = playerDetection();
        Vector3 direction = (attackerRef.transform.position - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle >= -90 && angle <= 90)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (angle >= -180 && angle <= 180)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if ((attackerRef) && (playerFound == false) && (animator.GetBool("Attack") == false))
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= 1.5f)
			{
                animator.SetTrigger("Jump");
                direction = direction * force;
                agent.velocity = direction;
                idleTimer = 0.0f;
            }
        }
        else if (playerFound)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f)
            {
                animator.SetTrigger("Attack");
                StartCoroutine(shoot());
                cooldown = attackDelay;
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

    IEnumerator shoot()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.5f);
        Instantiate(tongue, tonguePos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Attack", false);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(transform.position, range);
    }

}
    