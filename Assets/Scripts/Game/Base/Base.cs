using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
public class Base : MonoBehaviour
{
    private Texture2D pixelTexture;
    private Health baseHealth;

    public Color color;

    void OnDestroy()
    {
        if (gameObject.GetComponent<Health>().isKilled)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
