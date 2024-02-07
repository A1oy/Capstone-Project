using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combust : MonoBehaviour
{
    public GameObject explosionPrefab;

    float Force =15f;

    int damage =1;

    public PlayerData player;

    static int burnedAnimals =0;

    public void OnBurnOut()
    {
        Destroy(this);
        
    }

    public void OnDead()
    {
        if (GetComponent<Burn>())
        {
            burnedAnimals++;
            if (burnedAnimals>3)
            {
                burnedAnimals -=3;
                DoExplode();
            }
        }
        Destroy(this);
    }

    void DoExplode()
    {
         Collider2D[] collisions =Physics2D.OverlapCircleAll(transform.position,
            1.2f,
            1<<9);
        foreach (Collider2D collision in collisions)
        {
            Vector3 dir =collision.transform.position -transform.position;
            Vector3 force =dir.normalized /(dir.magnitude*dir.magnitude) * Force;
            collision.GetComponent<Rigidbody2D>().AddForce(
                force,
                ForceMode2D.Impulse);
            collision.GetComponent<Animal>().DoAttack(damage, player);
        }
    }
}
