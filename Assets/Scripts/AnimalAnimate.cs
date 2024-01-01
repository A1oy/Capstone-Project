using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalAnimate : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    NavMeshAgent agent;

    bool isRightDir =true;

    void Start()
    {
        if (agent.velocity.x <0f)
        {
            animator.SetTrigger("TurnsLeft");
            isRightDir =false;
        }
    }

    void FixedUpdate()
    {
        if (isRightDir)
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
        }
    }
}
