using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkunkMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    UnityEngine.AI.NavMeshAgent agent;
    GameObject attackerRef;
    Animator animator;
    PlayerController playerScript;

    //damage related
    int damage = 1;
    [SerializeField]
    float attackDelay;
    float cooldown = 1.5f;
    float range = 3.5f;

    //poison gas related
    [SerializeField]
    public GameObject gas;
    [SerializeField]
    public Transform gasPosition;

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
        playerScript = attackerRef.GetComponent<PlayerController>();

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
        if ((attackerRef) && (playerFound == false))
        {
            agent.speed = 2.5f;
            agent.destination = attackerRef!.transform.position;
        }
        else if (playerFound)
        {
            agent.speed = 0;
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f)
            {
                cooldown = attackDelay;
                //DoAttack();
                //playerScript.poison();
                Instantiate(gas, gasPosition.position, Quaternion.identity);
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

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
        Gizmos.DrawSphere(transform.position, range);
    }
}
