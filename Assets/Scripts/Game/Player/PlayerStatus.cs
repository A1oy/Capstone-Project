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

    [SerializeField]
    Texture2D aimCursor;

    [SerializeField]
    Texture2D buildCursor;

    void Awake()
    {
        SetAimCursor();
    }

    void OnDestroy()
    {
        ClearCursor();
    }

    static public void ClearCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void SetAimCursor()
    {
        Cursor.SetCursor(aimCursor, new Vector2(16f, 16f), CursorMode.Auto);
    }

    void SetBuildCursor()
    {
        Cursor.SetCursor(buildCursor, new Vector2(8f, 8f), CursorMode.Auto);
    }

    public void SetCursor()
    {
        if (isBuildMode)
        {
            SetBuildCursor();
        }
        else
        {
            SetAimCursor();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBuild)
        {
            isBuildMode =!isBuildMode;
            SetCursor();
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
            SetAimCursor();
            placement.placer.SetActive(isBuildMode);
        }
    }

    void OnDead()
    {
        SceneManager.LoadScene("Game Over");
    }
}