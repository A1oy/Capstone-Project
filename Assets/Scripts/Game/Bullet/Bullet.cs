using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject playerRef;

    public GameObject hitEffect;
    public int damage;

    void Start()
    {
        playerRef =GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy =collision.gameObject.GetComponent<Enemy>();
        if (enemy !=null)
        {
            enemy.DoAttack(playerRef, damage);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
