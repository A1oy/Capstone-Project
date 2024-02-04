using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="PlayerData")]
public class PlayerData : ScriptableObject
{
    public int animalsKilled;
    public int honeyCosumed;
    public int honeyCollected;

    public UnityEvent animalKilledEvent = new UnityEvent();

    public void AddAnimalsKilledListener(UnityAction action)
    {
        animalKilledEvent.AddListener(action);
    }

    public void AddAnimalKilled()
    {
        animalsKilled++;
        animalKilledEvent.Invoke();
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
