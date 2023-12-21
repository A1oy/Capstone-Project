using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    GameObject explosion;

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
            Destroy(gameObject);
        }
    }

    virtual public void DoBulletTrigger(GameObject gameobj)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
