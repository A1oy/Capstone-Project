using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
public class Base : MonoBehaviour
{
    int honey =0;

    public GameObject gameUI =null!;
    public float touchRadius =2.0f;
    public int honeyEachRound =5;


    void Start()
    {
        honey += honeyEachRound;
    }

    void OnDestroy()
    {
        if (gameObject.GetComponent<Health>().isKilled)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void DispenseHoney()
    {
        honey += honeyEachRound;
    }

    void FixedUpdate()
    {
        Collider2D playerCollide =Physics2D.OverlapCircle(transform.position, touchRadius, 1<<7);
        if (playerCollide)
        {
            playerCollide.gameObject.GetComponent<Player>().honey += honey;
            honey =0;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color =new Color(1.0f, 1.0f, 0.6f, 0.3f);
        Gizmos.DrawSphere(transform.position, touchRadius);
    }
}
