using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grenade : MonoBehaviour
{
    private IEnumerator explosionDelayRoutine;
    private float damageRange;

    public int secondsDeplay;
    public int explosionRadius;
    public int maxDamage;
    public int minDamage;
    public int force;
    public GameObject hitEffect;

    [SerializeField]
    AudioClip explosionClip;

    void Start()
    {
        explosionDelayRoutine = ExplosionDelay();
        damageRange = (float)minDamage - (float)maxDamage;
        StartCoroutine(explosionDelayRoutine);
    }

    IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(secondsDeplay);
        Destroy(gameObject);
        Vector2 position =new Vector2(transform.position.x, transform.position.y);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.transform.localScale =new Vector2((float)explosionRadius*2, (float)explosionRadius*2);

        AudioManager.instance.PlaySoundEffect(explosionClip);
        
        Destroy(effect, 1f);
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
                Debug.Log("Did " +  Convert.ToString(iDamage) + " Damage.");
                float forceMagnitude = force;

                Rigidbody2D rigidBody = gameObj.GetComponent<Rigidbody2D>();
                rigidBody.AddForce(vectorDiff * forceMagnitude, ForceMode2D.Impulse);
            }
        }
        Destroy(gameObject);
    }
}
