using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    GameObject gameObjLock=null;
    Vector3 [] rayVertices =new Vector3[2];

    [SerializeField]
    LineRenderer lr;

    [SerializeField]
    Weapon weapon;
    
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    float detectRadius;

    [SerializeField]
    float delay;

    [SerializeField]
    int damage;

    float cooldownTick;

    void Awake()
    {
        cooldownTick =delay;
    }

    void FixedUpdate()
    {
        UpdateTarget();
        if (!gameObjLock)
        {
            DisableRay();
        }
        cooldownTick -= Time.deltaTime;

        if(gameObjLock !=null
            && cooldownTick <=0)
        {
            cooldownTick =delay;
            weapon.Shoot(firePoint);
        }
    }

    void UpdateTarget()
    {
        Vector2 position =new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Collider2D[] collisions =Physics2D.OverlapCircleAll(position, detectRadius);
        const int layerMask =1<<3;
        float distance =Mathf.Infinity;
        GameObject objIntersect =null;

        foreach (Collider2D collision in collisions)
        {
            GameObject gameObj =collision.gameObject;
            if (gameObj.CompareTag("Enemy"))
            {
                Vector2 gameObjPos =new Vector2(gameObj.transform.position.x, gameObj.transform.position.y);
                Vector2 vectorDiff = gameObjPos -position;
                RaycastHit2D raycast =Physics2D.Linecast(position, vectorDiff, layerMask);
                if (raycast.collider
                    && raycast.collider !=gameObject)
                {
                    continue;
                }
                if (vectorDiff.magnitude < distance)
                {
                    objIntersect =gameObj;
                    distance =vectorDiff.magnitude;
                }
            } 
        }
        if (objIntersect !=null)
        {
            RotateToObject(objIntersect);
            UpdateRay(objIntersect);
        }
        gameObjLock =objIntersect;
    }

    void UpdateRay(GameObject object0)
    {
        rayVertices[0] =firePoint.transform.position;
        rayVertices[1] =object0.transform.position;
        lr.SetPositions(rayVertices);
    }

    void DisableRay()
    {
        rayVertices[0] = new Vector3(0.0f, 0.0f, 0.0f);
        rayVertices[1] = new Vector3(0.0f, 0.0f, 0.0f);
        lr.SetPositions(rayVertices);
    }

    void RotateToObject(GameObject object0)
    {
        Vector2 lookDir = gameObject.transform.position -object0.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg +90.0f;
        transform.rotation =Quaternion.Euler(0, 0, angle);
    }

    void OnDrawGizmos()
    {
        Gizmos.color =new Color(1f, 0f, 0f, 0.3f);
        Gizmos.DrawSphere(transform.position, detectRadius);
    }

    void OnDead()
    {
        Destroy(gameObject);
    }
}
