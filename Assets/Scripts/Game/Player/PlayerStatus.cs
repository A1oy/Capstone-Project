using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    bool isBuildMode =false;
    bool canBuild =true;
    [SerializeField]

    Health health;

    [SerializeField]
    Placement placement;

    [SerializeField]
    GameUI gameUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBuild)
        {
            isBuildMode =!isBuildMode;
            placement.placer.SetActive(isBuildMode);
        }
    }

    public bool CanBuild()
    {
        return canBuild && isBuildMode;
    }

    void OnDaylightChange(bool isDayTime)
    {
        canBuild =isDayTime;
        if (isBuildMode && !canBuild)
        {
            isBuildMode=false;
            placement.placer.SetActive(isBuildMode);
        }
    }

    void OnDead()
    {
        SceneManager.LoadScene("Game Over");
    }
}