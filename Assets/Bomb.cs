using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullet
{
    override public void DoBulletTrigger(GameObject gameobj)
    {
        PushEnemies();
        GameObject go =BombExplodeFXPool.Instantiate(transform.position,
            Quaternion.identity);
        go.GetComponentInChildren<ParticleSystem>().Play();
    }

    void PushEnemies()
    {
        Collider2D[] collisions =Physics2D.OverlapCircleAll(transform.position,
            1.2f,
            1<<9);
        foreach (Collider2D collision in collisions)
        {
            Vector3 dir =collision.transform.position -transform.position;
            Vector3 force =dir.normalized /(dir.magnitude*dir.magnitude) * 17.2f;
            Debug.Log(force);
            collision.GetComponent<Rigidbody2D>().AddForce(
                force,
                ForceMode2D.Impulse);
        }
    }
}