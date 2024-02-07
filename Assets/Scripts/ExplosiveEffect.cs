using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEffect : MonoBehaviour
{
   [SerializeField]
    GameObject explosionPrefab;

    [SerializeField]
    int damage = 1;
    [SerializeField]
    PlayerData player;

    public void DoBulletHit(GameObject go){
        PushEnemies();
        GameObject go2 = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        go2.GetComponentInChildren<ParticleSystem>().Play();
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
            collision.GetComponent<Rigidbody2D>().AddForce(
                force,
                ForceMode2D.Impulse);
            collision.GetComponent<Animal>().DoAttack(damage, player);
        }
    }
}
