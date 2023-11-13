using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    GameObject gameObjLock =null;
    Vector3 [] rayVertices;
    LineRenderer lr;

    [SerializeField]
    GameObject bulletPrefab;
    
    public GameObject hitEffect;
    public Transform firePoint;
    public float detectRadius;
    public float force;
    public float delay;
    public int damage =1;

    float cooldownTick;

    void Awake()
    {
        cooldownTick =delay;
    }

    void Start()
    {
        rayVertices = new Vector3[2];
        lr = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
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
            Vector3 lookDir = gameObjLock.transform.position -firePoint.transform.position;

            // very inefficient, might optimize it later with line-nonAABB intersection later ..

            RaycastHit2D raycast =Physics2D.Raycast(firePoint.position, lookDir, detectRadius); 

            Vector2 firePoint2D =new Vector2(firePoint.transform.position.x, firePoint.transform.position.y);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().Shoot(raycast.point -firePoint2D, firePoint2D, raycast.point);
            bullet.SetActive(true);

            GameObject effect = Instantiate(hitEffect, new Vector3(raycast.point.x, raycast.point.y, 1.0f), Quaternion.identity);
            Destroy(effect, 2f);
            gameObjLock.GetComponent<Enemy>().DoAttack(damage);
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
}
