using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    int uses=3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy =collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.DoAttack(999);
        }
        uses--;
        if (uses==0)
        {
            Destroy(gameObject.GetComponent<Collider2D>());
        }
    }
}
