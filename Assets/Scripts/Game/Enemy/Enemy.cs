using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    Health m_health;

    [SerializeField]
    int m_scoreGiven;

    void Awake()
    {
        m_health =GetComponent<Health>();
    }

    public void DoAttack(int damage)
    {
        m_health.DoDamage(damage);
    }


    void OnDead()
    {
        Destroy(gameObject);
        GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().AddScore(m_scoreGiven);
    }
}