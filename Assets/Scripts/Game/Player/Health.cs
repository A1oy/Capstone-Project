using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;

    [SerializeField]
    GameObject damagePrefab;
    
    [SerializeField]
    int maxHealth;

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
        Instantiate(damagePrefab,
            transform, false);
        damagePrefab.GetComponent<IDamageValue>().text = $"-{damage}";
        damagePrefab.SetActive(true);
        if (health <=0)
        {
            SendMessage("OnDead");
            return true;
        }
        return false;
    }

    public int GetCurrentHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public bool IsDead()
    {
        return health<=0;
    }
}
