using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    [System.NonSerialized]
    public bool isBuildMode =false;

    [SerializeField]
    Health health;

    [SerializeField]
    Placement placement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isBuildMode =!isBuildMode;
            placement.placer.SetActive(isBuildMode);
        }
    }

    void OnDead()
    {
        SceneManager.LoadScene("Game Over");
    }
}