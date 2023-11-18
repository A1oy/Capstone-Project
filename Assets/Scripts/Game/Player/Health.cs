using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    int health;
    
    [SerializeField]
    int maxHealth;

    [SerializeField]
    HealthBar healthBar;

    void Awake()
    {
        health =maxHealth;
    }

    //Players heals up when honey is consumed
    public void Heal(int healed) 
    {
        health += healed; 
        if (health > maxHealth)
        {
            health = maxHealth; 
        }
    }

    public bool DoDamage(int damage)
    {
        health -=damage;
        if (health <=0)
        {
            SendMessage("OnDead");
            return true;
        }
        return false;
    }

    public int GetHealth() { return health; }

    void Update()
    {
        if (healthBar
            &&maxHealth>0)
        {
            healthBar.value = (float)health/(float)maxHealth;
        }
    }
}
