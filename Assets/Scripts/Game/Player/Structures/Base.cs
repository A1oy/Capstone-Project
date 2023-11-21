using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    [SerializeField]
    GameObject buyMenuUI;

    [SerializeField]
    GameUI gameUI;

    void OnInteracting()
    {
        if (Input.GetKeyDown(KeyCode.F)
            && gameUI.IsDayTime())
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