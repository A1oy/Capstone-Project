using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : IPoolable
{
    [SerializeField]
    int damage =1;

    [SerializeField]
    float speed;

    [SerializeField]
    private GameObject explosion;

    void FixedUpdate()
    {
        transform.position += transform.up  *speed*Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        bool isEnemy =collider.gameObject.CompareTag("Enemy");
        if (isEnemy
            || collider.gameObject.CompareTag("Obstacle"))
        {
            if (isEnemy)
            {
                collider.gameObject.GetComponent<Health>().DoDamage(damage);
            }
            DoBulletTrigger(collider.gameObject);
            Release();
        }
    }
    
    override public void Release()
    {
        GetComponentInChildren<TrailRenderer>()?.Clear();
        base.Release();
    }
    
    public virtual void DoBulletTrigger(GameObject go)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
