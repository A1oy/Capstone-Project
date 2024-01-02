using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerData")]
public class PlayerData : ScriptableObject
{
    public int animalsKilled;
    public int honeyCosumed;
    public int honeyCollected;

    public void AddAnimalKilled()
    {
        animalsKilled++;
    }
    
    public void AddHoneyCosumed(int honeyCosumed)
    {
        this.honeyCosumed +=honeyCosumed;
    }

    public void AddHoneyCollected(int honeyCollected)
    {
        this.honeyCollected +=honeyCollected;
    }
}
