using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [System.NonSerialized]
    public bool isKilled =false;
    public int health;
    
    int maxHealth;

    [SerializeField]
    HealthBar healthBar;

    void Start()
    {
        maxHealth =health;
    }

    public bool DoDamage(int damage)
    {
        health -=damage;
        if (health <=0)
        {
            isKilled =true;
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    void Update()
    {
        if (healthBar
            &&maxHealth>0)
        {
            healthBar.value = (float)health/(float)maxHealth;
        }
    }
}
