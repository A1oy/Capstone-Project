using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fox : MonoBehaviour
{

    float detectRadius =10.0f;

    NavMeshAgent agent =null!;
    void Start()
    {
        agent =gameObject.GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        Vector3 newVelocity = agent.desiredVelocity;
        ContactFilter2D contactFilter =new ContactFilter2D();
        contactFilter.useLayerMask =true;
        contactFilter.SetLayerMask(1<<6);
        RaycastHit2D[] res =new RaycastHit2D[10];

        if (gameObject.GetComponent<Rigidbody2D>().Cast(new Vector2(newVelocity.x, newVelocity.y).normalized,  contactFilter, res, newVelocity.magnitude) !=0)
        {
            float dice =Random.value;
            float rotRads =-90.0f *Mathf.Deg2Rad;
            if (dice<=0.5f)
            {
                rotRads =-rotRads;
            }
            
            float tempX =newVelocity.x;
            newVelocity.x = newVelocity.x * Mathf.Cos(rotRads) - newVelocity.y * Mathf.Sin(rotRads);
            newVelocity.y = tempX * Mathf.Sin(rotRads) + newVelocity.y * Mathf.Cos(rotRads);
            gameObject.GetComponent<Rigidbody2D>().AddForce(newVelocity.normalized * 1.42f, ForceMode2D.Impulse);
        }
    }
}
