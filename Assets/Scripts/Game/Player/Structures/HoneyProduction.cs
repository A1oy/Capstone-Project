using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyProduction : MonoBehaviour
{
    int honey =0;

    [System.NonSerialized]
    public int honeyProductionLvl =0;

    [SerializeField]
    int honeyEachRound;

    [SerializeField]
    AudioSource m_honeyDrainingSource;
    
    void OnDaylightChange(bool isDayTime)
    {
        if (isDayTime)
        {
            honey += honeyEachRound;
        }
    }

    void OnInteract(GameObject player)
    {
        if (honey>0)
        {
            m_honeyDrainingSource.Play();
            player.GetComponent<PlayerInventory>().AddHoney(honey); 
            honey =0;
        }
    }
}
