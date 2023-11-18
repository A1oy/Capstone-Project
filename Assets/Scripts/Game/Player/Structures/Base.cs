using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    int honey =0;

    [SerializeField]
    int honeyEachRound;

    [System.NonSerialized]
    public int honeyProductionLvl =-0;

    [SerializeField]
    GameObject buyMenuUI;

    [SerializeField]
    GameUI gameUI;

    [SerializeField]
    Interactable interactable;

    [SerializeField]
    Health health;

    [SerializeField]
    AudioClip honeyFillingClip;

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
            player.GetComponent<PlayerInventory>().honey += honey;
            AudioManager.instance.PlaySoundEffect(honeyFillingClip);
            honey =0;
        }
    }

    void OnInteracting()
    {
        if (Input.GetKeyDown(KeyCode.F)
            && gameUI.isDaytime)
        {
            buyMenuUI.SetActive(true);
            
        }
    }

    void OnLeaveInteract()
    {
        if (buyMenuUI.activeSelf)
        {
            buyMenuUI.SetActive(false);
        }
    }
    
    void OnDead()
    {
        SceneManager.LoadScene("Game Over");
    }
}