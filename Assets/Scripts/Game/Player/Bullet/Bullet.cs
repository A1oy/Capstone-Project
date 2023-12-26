using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : IPoolable
{
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
        if (collider.gameObject.CompareTag("Enemy")
            || collider.gameObject.CompareTag("Obstacle"))
        {
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
