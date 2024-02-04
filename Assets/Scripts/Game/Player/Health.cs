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

    [SerializeField]
    Invunerability invunerable;

    void OnEnable()
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

    public void DoDamage(int damage)
    {
        bool canAttack = invunerable ? invunerable.CanAttack() : true;
        if (canAttack)
        {
            health -=damage;
            if (invunerable)
            {
                invunerable.TriggerInvun();
            }
            SendMessage("OnDamageTaken", damage, SendMessageOptions.DontRequireReceiver);
            Instantiate(damagePrefab, transform, false);
            damagePrefab.GetComponent<IDamageValue>().text = $"-{damage}";
            damagePrefab.SetActive(true);
            if (health <=0)
            {
                SendMessage("OnDead", SendMessageOptions.DontRequireReceiver);
            }
        }
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
