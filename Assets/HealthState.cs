using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HealthState : ISerializationCallbackReceiver
{
    [SerializeField]
    int health;
    int curHealth;

    public void OnBeforeSerialize() {}
    
    public void OnAfterDeserialize()
    {
        curHealth =health;
    }

    public float GetCurrentHealth()
    {
        return (float)curHealth/(float)health;
    }

    public bool IsDead()
    {
        return curHealth<=0;
    }

    public void Damage(int damage)
    {
        curHealth -=damage;
    }

    public void Heal(int heal)
    {
        curHealth +=heal;
    }
}
