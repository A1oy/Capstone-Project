using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    IEnumerator shootRoutine;
    GameObject gameObjLock =null;

    public GameObject projectile;
    public GameObject hitEffect;
    public Transform firePoint;
    public float detectRadius;
    public float force;
    public float delay;

    void Awake()
    {
        shootRoutine =Shoot();
        StartCoroutine(shootRoutine);
    }

    void Update()
    {
        if (gameObjLock)
        {
            Debug.DrawLine(gameObject.transform.position, gameObjLock.transform.position, Color.green);
        }
    }

    void FixedUpdate()
    {
        if (gameObjLock)
        {
            RotateToObject(gameObjLock);
        }
    }

    void RotateToObject(GameObject object0)
    {
        Vector2 lookDir = gameObject.transform.position -object0.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg +90.0f;
        gameObject.GetComponent<Rigidbody2D>().rotation =angle;
    }

    IEnumerator Shoot()
    {
        Vector2 position =new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        while (true)
        {
            yield return new WaitForSeconds(delay);

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
            RotateToObject(objIntersect);
            gameObjLock =objIntersect;
            if(gameObjLock !=null)
            {
                Vector3 lookDir = gameObjLock.transform.position -firePoint.transform.position;

                // very inefficient, might optimize it later with line-nonAABB intersection later ..

                RaycastHit2D raycast =Physics2D.Raycast(firePoint.position, lookDir, detectRadius); 
                Debug.Log(raycast.point);
                GameObject effect = Instantiate(hitEffect, new Vector3(raycast.point.x, raycast.point.y, 1.0f), Quaternion.identity);
                Destroy(effect, 2f);
                gameObjLock.GetComponent<Enemy>().DoAttack(1);
            }
        }
    }

    void DoShoot()
    {
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Bullet bulletComponent =bullet.GetComponent<Bullet>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }

    void OnDestroy()
    {
        if (shootRoutine !=null)
        {
            StopCoroutine(shootRoutine);
        }
    }
}
