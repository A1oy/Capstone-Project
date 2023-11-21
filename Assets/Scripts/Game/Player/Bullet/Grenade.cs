using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grenade : MonoBehaviour
{
    private float damageRange;

    [SerializeField]
    float secondsDelay;
    
    [SerializeField]
    int explosionRadius;
    
    [SerializeField]
    int maxDamage;
    
    [SerializeField]
    int minDamage;

    [SerializeField]
    int force;

    [SerializeField]
    GameObject hitEffect;

    void Awake()
    {
        damageRange = (float)minDamage - (float)maxDamage;
    }

    void FixedUpdate()
    {
        secondsDelay -=Time.deltaTime;
        if (secondsDelay <=0f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
        Vector2 position =new Vector2(transform.position.x, transform.position.y);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        
        effect.transform.localScale =new Vector2((float)explosionRadius*2, (float)explosionRadius*2);
        
        Collider2D[] collisions =Physics2D.OverlapCircleAll(position, explosionRadius);
        foreach (Collider2D collision in collisions)
        {
            GameObject gameObj =collision.gameObject;
            Enemy enemy = gameObj.GetComponent<Enemy>();
            if (enemy !=null)
            {
                Vector2 vectorDiff = new Vector2(gameObj.transform.position.x, gameObj.transform.position.y)-position;
                float distance =vectorDiff.magnitude;
                vectorDiff = vectorDiff.normalized;
                float fDamage = damageRange * ((float)distance/(float)explosionRadius)  + (float) minDamage;

                int iDamage =(int)fDamage +1;

                enemy.DoAttack(iDamage);
                float forceMagnitude = force;

                Rigidbody2D rigidBody = gameObj.GetComponent<Rigidbody2D>();
                rigidBody.AddForce(vectorDiff * forceMagnitude, ForceMode2D.Impulse);
            }
        }
        Destroy(gameObject);
    }
}
