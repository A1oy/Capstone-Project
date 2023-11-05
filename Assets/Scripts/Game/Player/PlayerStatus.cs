using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public bool isBuildMode =false;

    [SerializeField]
    Health health;

    [SerializeField]
    Placement placement;

    void OnDestroy()
    {
        if (health.isKilled)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isBuildMode =!isBuildMode;
            placement.placer.SetActive(isBuildMode);
        }
    }
}