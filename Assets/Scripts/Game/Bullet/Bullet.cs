using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bullet collision!");
        Enemy enemy =collision.gameObject.GetComponent<Enemy>();
        if (enemy !=null)
        {
            enemy.DoAttack(damage);
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
