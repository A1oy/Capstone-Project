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
    Interactable interactable;

    public float touchRadius =2.0f;
    public int honeyEachRound =5;
    public GameObject buyMenuUI;

    void Start()
    {
        interactable =GetComponent<Interactable>();
    }

    void OnDestroy()
    {
        if (gameObject.GetComponent<Health>().isKilled)
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
        }
    }

    void OnInteract(GameObject player)
    {
        player.GetComponent<Player>().honey += honey;
        honey =0;
    }

    void OnInteracting()
    {
        if (Input.GetKeyDown(KeyCode.E)
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

    void OnDrawGizmos()
    {
        Gizmos.color =new Color(1.0f, 1.0f, 0.6f, 0.3f);
        if (interactable)
        {
            Gizmos.DrawSphere(transform.position, interactable.touchRadius);
        }
    }
}