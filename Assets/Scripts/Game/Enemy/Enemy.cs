using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    public int movementSpeed;
    public int damage;
    private IEnumerator? damageRoutine=null;

    void Update()
    {
        transform.position = transform.position + new Vector3(-movementSpeed *Time.deltaTime, 0.0f, 0.0f);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player collision!");
            damageRoutine =DoDamageRoutine(collision.gameObject);
            StartCoroutine(damageRoutine);
        }
    }

    IEnumerator DoDamageRoutine(GameObject player)
    {
        Health playerHealth =player.GetComponent<Health>();
        while (true)
        {
            playerHealth.DoDamage(damage);
            yield return new WaitForSeconds(1);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (damageRoutine!=null)
        {
            StopCoroutine(damageRoutine);
        }
    }
}
