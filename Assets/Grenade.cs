using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    float Force;

    [SerializeField]
    float explodeInSeconds;

    [SerializeField]
    GameObject explosionPrefab;

    [SerializeField]
    int damage;

    public PlayerData player;

    float countdown =0;

    // Update is called once per frame
    void FixedUpdate()
    {
        countdown +=Time.deltaTime;
        if (countdown>=explodeInSeconds)
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider2D[] collisions =Physics2D.OverlapCircleAll(transform.position,
            2f,
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
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        bool isEnemy =collider.gameObject.CompareTag("Enemy");
        if (isEnemy
            || collider.gameObject.CompareTag("Obstacle"))
        {
            if (isEnemy)
            {
                collider.gameObject.GetComponent<Animal>().DoAttack(damage, player);
            }
            Explode();
        }
    }
}
