using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Texture2D pixelTexture;
    private GUIStyle rectStyle;
    private Health playerHealth;

    public Color color;

    void Start()
    {    
        pixelTexture = new Texture2D(1,1);
        pixelTexture.SetPixel(0, 0, color);
        pixelTexture.Apply();

        rectStyle = new GUIStyle();
        rectStyle.normal.background = pixelTexture;
        playerHealth =gameObject.GetComponent<Health>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 50, 20), "Health");
        GUI.Label(new Rect(110, 10, 100, 20),  Convert.ToString(playerHealth.health, 10));
    }

    void OnDestroy()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
