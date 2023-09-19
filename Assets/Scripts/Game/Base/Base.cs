using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    private Texture2D pixelTexture;
    private Health baseHealth;

    public Color color;

    void OnDestroy()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
