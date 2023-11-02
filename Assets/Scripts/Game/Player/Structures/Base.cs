using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Interactable))]
public class Base : MonoBehaviour
{
    int honey =0;
    int prevDay=-1;

    public int honeyEachRound =5;
    public int honeyProductionLvl =0;


    public GameObject buyMenuUI;

    [SerializeField]
    Interactable interactable;

    [SerializeField]
    Health health;

    [SerializeField]
    Interactable healthbar;

    void OnDestroy()
    {
        if (health.isKilled)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void Update()
    {
        if (prevDay <GameUI.day)
        {
            honey += honeyEachRound;
            prevDay =GameUI.day;
        }
        if (GameUI.isDaytime == !interactable.isEnabled)
        {
            interactable.isEnabled =GameUI.isDaytime;
            healthbar.isEnabled =GameUI.isDaytime;
        }
    }

    void OnInteract(GameObject player)
    {
        player.GetComponent<PlayerInventory>().honey += honey;
        honey =0;
    }

    void OnInteracting()
    {
        if (Input.GetKeyDown(KeyCode.F)
            && GameUI.isDaytime)
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
}