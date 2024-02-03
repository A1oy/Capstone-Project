using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalAnimate : MonoBehaviour
{
    /*[SerializeField]
    Animator animator;

    [SerializeField]
    NavMeshAgent agent;

    bool isRightDir =true;*/
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        /*if (agent.velocity.x <0f)
        {
            animator.SetTrigger("TurnsLeft");
            isRightDir =false;
        }*/
    }

    void FixedUpdate()
    {
        /*if (isRightDir)
        {
            if (agent.velocity.x <0f)
            {
                isRightDir =false;
                animator.SetTrigger("TurnsLeft");
            }
        }
        else if (agent.velocity.x >=0f)
        {
            isRightDir =true;
            animator.SetTrigger("TurnsRight");
        }*/

        Vector3 direction = (player.transform.position - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle >= -90 && angle <= 90)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (angle >= -180 && angle <= 180)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
