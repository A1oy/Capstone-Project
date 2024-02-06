using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    PlayerUIController uiController;

    [SerializeField]
    Health health;

    [SerializeField]
    Texture2D aimCursor;

    void Awake()
    {
        SetAimCursor();
        uiController =GameObject.Find("PlayerUI")
            .GetComponent<PlayerUIController>();
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

    void OnDead()
    {
        SceneManager.LoadScene("Game Over");
    }

    void OnDamageTaken()
    {
        uiController.UpdateHealth(health);
    }
}