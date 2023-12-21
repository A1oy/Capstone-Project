using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    Health health;

    [SerializeField]
    PlayerUI playerUI;

    [SerializeField]
    Texture2D aimCursor;

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

    public void SetAimCursor()
    {
        Cursor.SetCursor(aimCursor, new Vector2(16f, 16f), CursorMode.Auto);
    }
    
    public void SetUI(PlayerUI playerUI)
    {
        this.playerUI =playerUI;
    }

    void OnDead()
    {
        SceneManager.LoadScene("Game Over");
    }
}